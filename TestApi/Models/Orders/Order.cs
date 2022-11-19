using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.OrderDetails;
using TestApi.Models.PaymentDetails;
using TestApi.Models.Shipments;
using TestApi.Models.Users;

namespace TestApi.Models.Orders
{
    public class Order: DefaultEntityModelProperty
    {
        public Order()
        {
            OrderDetail = new List<OrderDetail>();
            Shipment = new Shipment();
            PaymentDetail=new PaymentDetail();
        }
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        public double ShipmentCost { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual PaymentDetail? PaymentDetail { get; set; }
        
    }
}
