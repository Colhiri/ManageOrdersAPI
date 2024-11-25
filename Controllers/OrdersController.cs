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
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        /// <summary>
        /// Создание новой заявки
        /// </summary>
        /// <param name="order">Значения для новой заявки</param>
        /// <returns>Ничего</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            order.Status = "Новая";
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrders), new { id = order.IdOrder }, order);
        }

        /// <summary>
        /// Передача на исполнение
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="status">Новый статус</param>
        /// <returns>Ничего</returns>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderModel updateOrder)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = updateOrder.Status;
            order.NameExecutor = updateOrder.NameExecutor;

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
        public async Task<IActionResult> UpdateOrder(int id, OrderModel updatedOrder)
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
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}