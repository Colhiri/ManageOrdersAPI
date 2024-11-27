using System.ComponentModel.DataAnnotations;

namespace ManageOrdersAPI.Database
{
    public class CourierModel
    {
        [Key]
        public int IdCourier { get; set; }
        public string NameCourier { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
