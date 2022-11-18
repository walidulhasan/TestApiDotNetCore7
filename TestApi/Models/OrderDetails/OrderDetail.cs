using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.OrderDetails
{
    public class OrderDetail: DefaultEntityModelProperty
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
