using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Orders;
using TestApi.ModelRsDto.OrderMaster;
using TestApi.Models.Orders;
using TestApi.ModelVM.Orders;

namespace TestApi.InterfaceImplementation.Repositories.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly IMapper _mapper;

    public OrderRepository(TestApiDbContext context, ILogger logger, IMapper mapper) : base(context, logger)
    {
        _mapper = mapper;
    }

    public async Task<bool> CreateOrder(OrderVM model, bool saveChange = true)
    {
        try
        {
            var entity = _mapper.Map<OrderVM, Order>(model);
            var obj = await this.InsertAsync(entity, saveChange);

            return true;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<List<OrderMasterRM>> GetAllDataOfOrderMaster(CancellationToken cancellationToken)
    {

        var dbEntity = await _context.Order
                       .Include(x => x.OrderDetail.Where(x => x.IsActive == true && x.IsDeleted == false))
                       .Include(x => x.Shipment)
                       .Include(x => x.PaymentDetail)
                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                       .ToListAsync(cancellationToken);
        var entity = _mapper.Map<List<OrderMasterRM>>(dbEntity);
        return entity;
    }

    public async Task<OrderMasterRM> GetSingleOrderMaster(int id, CancellationToken cancellationToken)
    {
        var dbEntity = await _context.Order
                           .Include(x => x.OrderDetail.Where(x => x.IsActive == true && x.IsDeleted == false))
                           .Include(x => x.Shipment)
                           .Include(x => x.PaymentDetail)
                           .Where(x => x.IsActive == true && x.IsDeleted == false && x.OrderId == id)
                           .FirstOrDefaultAsync(cancellationToken);
        var entity = _mapper.Map<Order, OrderMasterRM>(dbEntity);
        return entity;
    }
}
