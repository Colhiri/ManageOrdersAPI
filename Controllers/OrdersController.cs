using ManageOrdersAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ManageOrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ManageOrdersDbContext _context;

        public OrdersController(ManageOrdersDbContext context)
        {
            _context = context;
        }

        // 1. ��������� ���� ������
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        
        
        // 3. ����������� ����� ������
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            order.Status = "�����";
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrders), new { id = order.IdOrder }, order);
        }

        // 4. ���������� ������� ������
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 5. �������������� ������
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderModel updatedOrder)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            if (order.Status != "�����")
                return BadRequest("������������� ����� ������ ������ �� �������� '�����'.");

            order.NameClient = updatedOrder.NameClient;
            order.NameExecutor= updatedOrder.NameExecutor;
            order.PickupAddress = updatedOrder.PickupAddress;
            order.DeliveryAddress = updatedOrder.DeliveryAddress;
            order.PickupAddress = updatedOrder.PickupAddress;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. �������� ������
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