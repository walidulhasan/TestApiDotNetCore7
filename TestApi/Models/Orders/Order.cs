using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.Users;

namespace TestApi.Models.Orders
{
    public class Order: DefaultEntityModelProperty
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        public int Shipment { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
