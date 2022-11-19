using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Orders;
using TestApi.Models.Orders;
using TestApi.ModelVM.Orders;

namespace TestApi.InterfaceImplementation.Repositories.Orders
{
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
    }
}
