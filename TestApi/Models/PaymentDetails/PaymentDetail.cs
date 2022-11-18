using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.Orders;

namespace TestApi.Models.PaymentDetails
{
    public class PaymentDetail: DefaultEntityModelProperty
    {
        [Key]
        public int PaymentDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string CardNumber { get; set; }
        public double PaidAmount { get; set; }
        public virtual Order Order { get; set; }
    }
}
