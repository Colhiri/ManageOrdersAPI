using ManageOrdersAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageOrdersAPI.Controllers
{
    /// <summary>
    /// ���������� �������� API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ManageOrdersDbContext _context;

        public OrdersController(ManageOrdersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// �������� ��� ������
        /// </summary>
        /// <returns>��� ������</returns>
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Ok(await _context.Orders.Take(1000).ToListAsync());
        }

        /// <summary>
        /// �������� ��� ������ � ��������
        /// </summary>
        /// <returns>��� ������</returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilterOrdersAsync([FromQuery] string? searchText)
        {
            if (searchText == null)
            {
                return BadRequest();
            }
            return Ok(await _context.Orders
                .Join(_context.Couriers,
                order => order.IdCourier,
                courier => courier.IdCourier,
                (order, courier) => new { order, courier })
                .Join(_context.OrderStatuses,
                combined => combined.order.IdStatus,
                status => status.IdStatus,
                (combined, status) => new 
                {
                    combined.order.IdOrder,
                    combined.order.NameClient,
                    NameExecutor = combined.courier.NameCourier,
                    combined.order.PickupAddress,
                    combined.order.PickupTime,
                    Status = status.Status.NameStatus,
                    combined.order.CancelReason,
                })
                .Where(o =>  
                (
                o.IdOrder.ToString() + " " +
                o.NameClient + " " +
                o.NameExecutor + " " +
                o.PickupAddress + " " +
                o.PickupTime.ToString() + " " +
                o.Status + " " +
                o.CancelReason + " "
                ).Contains(searchText))
                .Take(1000)
                .ToListAsync());
        }

        /// <summary>
        /// �������� ����� ������
        /// </summary>
        /// <param name="order">�������� ��� ����� ������</param>
        /// <returns>������</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderModel order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// �������� �� ����������
        /// </summary>
        /// <param name="id">������������� ������</param>
        /// <param name="status">����� ������</param>
        /// <returns>������</returns>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ExecuteOrderStatusAsync(int id, [FromQuery] int newStatus, int? newExecutor)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.IdStatus = newStatus;
            order.IdCourier = newExecutor;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// ������������� ������
        /// </summary>
        /// <param name="id">������������� ������</param>
        /// <param name="updatedOrder">����� �������� ��� ������</param>
        /// <returns>������</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, OrderModel updatedOrder)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.NameClient = updatedOrder.NameClient;
            order.NameExecutor= updatedOrder.NameExecutor;
            order.PickupAddress = updatedOrder.PickupAddress;
            order.DeliveryAddress = updatedOrder.DeliveryAddress;
            order.PickupAddress = updatedOrder.PickupAddress;
            order.Status = updatedOrder.Status;
            order.CancelReason = updatedOrder.CancelReason;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// ������� ������
        /// </summary>
        /// <param name="id">������������� ������</param>
        /// <returns>������</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}