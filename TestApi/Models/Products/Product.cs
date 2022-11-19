using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.Categorys;
using TestApi.Models.OrderDetails;

namespace TestApi.Models.Products
{
    public class Product: DefaultEntityModelProperty
    {
        public Product()
        {
            OrderDetail = new List<OrderDetail>();
        }
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
