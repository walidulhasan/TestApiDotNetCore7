using TestApi.Core;
using TestApi.ModelRsDto.OrderMaster;
using TestApi.Models.Orders;
using TestApi.ModelVM.Orders;

namespace TestApi.Interface.Repositories.Orders
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<bool> CreateOrder(OrderVM model, bool saveChange = true);

        Task<List<OrderMasterRM>> GetAllDataOfOrderMaster(CancellationToken cancellationToken);

        Task<OrderMasterRM> GetSingleOrderMaster(int id,CancellationToken cancellationToken);
    }
}
