using TestApi.Common.Mappings;
using TestApi.Models.OrderDetails;
using TestApi.Models.Orders;
using TestApi.Models.PaymentDetails;
using TestApi.Models.Shipments;

namespace TestApi.ModelVM.Orders;

public class OrderVM : IMapFrom<Order>
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public double Tax { get { return (Amount*0.15); } }
    public double ShipmentCost { get { return Amount < 300 ? 15 : 0; } }
    public double TotalAmount { get { return Amount + Tax + ShipmentCost; } }
    public bool IsPaid { get; set; }
    public DateTime PaidDate { get; set; }
    public bool IsDelivered { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int UserId { get; set; }
    public List<OrderDetailVM> OrderDetail { get; set; }
    public PaymentDetailVM? PaymentDetail { get; set; }
    public ShipmentVM Shipment { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<OrderVM, Order>().ReverseMap();
    }
}
public class OrderDetailVM : IMapFrom<OrderDetail>
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<OrderDetailVM, OrderDetail>();
    }
}

public class PaymentDetailVM : IMapFrom<PaymentDetail>
{
    public int PaymentDetailId { get; set; }
    public int OrderId { get; set; }
    public string CardNumber { get; set; }
    public double PaidAmount { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<PaymentDetailVM, PaymentDetail>();
    }
}

public class ShipmentVM : IMapFrom<Shipment>
{
    public int ShipmentId { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Division { get; set; }
    public string Location { get; set; }
    public int OrderId { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<ShipmentVM, Shipment>();
    }
}
