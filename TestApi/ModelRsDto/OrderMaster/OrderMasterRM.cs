using TestApi.Common.Mappings;
using TestApi.Models.OrderDetails;
using TestApi.Models.Orders;
using TestApi.Models.PaymentDetails;
using TestApi.Models.Shipments;

namespace TestApi.ModelRsDto.OrderMaster;

public class OrderMasterRM : IMapFrom<Order>
{
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
    public int UserId { get; set; }
    public List<OrderDetailRM> OrderDetail { get; set; }
    public PaymentDetailRM? PaymentDetail { get; set; }
    public ShipmentRM Shipment { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<Order, OrderMasterRM>();
    }
}

public class OrderDetailRM : IMapFrom<OrderDetail>
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<OrderDetail, OrderDetailRM>();
    }
}

public class PaymentDetailRM : IMapFrom<PaymentDetail>
{
    public int PaymentDetailId { get; set; }
    public int OrderId { get; set; }
    public string CardNumber { get; set; }
    public double PaidAmount { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<PaymentDetail, PaymentDetailRM>();
    }
}

public class ShipmentRM : IMapFrom<Shipment>
{
    public int ShipmentId { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Division { get; set; }
    public string Location { get; set; }
    public int OrderId { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<Shipment, ShipmentRM>();
    }
}
