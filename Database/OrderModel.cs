using System.ComponentModel.DataAnnotations;

namespace ManageOrdersAPI.Database
{
    public class OrderModel
    {
        [Key]
        public int IdOrder { get; set; }
        public string NameClient { get; set; }
        public int IdCourier { get; set; }
        public CourierModel Courier { get; set; }
        public string PickupAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime PickupTime { get; set; }
        public int IdStatus { get; set; }
        public OrderStatusModel Status { get; set; }
        public string? CancelReason { get; set; }
    }
}
