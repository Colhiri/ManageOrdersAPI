using System.ComponentModel.DataAnnotations;

namespace ManageOrdersAPI.Database
{
    public class OrderModel
    {
        [Key] 
        public int IdOrder { get; set; }
        public string NameClient { get; set; }
        public string NameExecutor { get; set; }
        public string PickupAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; } = "Новая";
        public string? CancelReason { get; set; }
    }
}
