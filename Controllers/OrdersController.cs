using ManageOrdersAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageOrdersAPI.Controllers
{
    /// <summary>
    /// Управление заявками API
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
        /// Получить все заявки
        /// </summary>
        /// <returns>Все заявки</returns>
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Ok(await _context.Orders.Take(1000).ToListAsync());
        }

        /// <summary>
        /// Получить все заявки с фильтром
        /// </summary>
        /// <returns>Все заявки</returns>
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
        /// Создание новой заявки
        /// </summary>
        /// <param name="order">Значения для новой заявки</param>
        /// <returns>Ничего</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderModel order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Передача на исполнение
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="status">Новый статус</param>
        /// <returns>Ничего</returns>
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
        /// Редактировать заявку
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="updatedOrder">Новые значения для заявки</param>
        /// <returns>Ничего</returns>
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
        /// Удалить заявку
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns>Ничего</returns>
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