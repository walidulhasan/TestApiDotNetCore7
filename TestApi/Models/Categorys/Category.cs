using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.Categorys
{
    public class Category: DefaultEntityModelProperty
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
