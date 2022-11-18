using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.Orders;

namespace TestApi.Models.Shipments
{
    public class Shipment: DefaultEntityModelProperty
    {
        [Key]
        public int ShipmentId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Division { get; set; }
        public string Location { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } 
    }
}
