using System.ComponentModel.DataAnnotations;

namespace ManageOrdersAPI.Database
{
    public class OrderStatusModel
    {
        [Key] 
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
