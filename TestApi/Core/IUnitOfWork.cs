using TestApi.Interface.Repositories.Orders;
using TestApi.Interface.Repositories.Products;
using TestApi.Interface.Repositories.Roles;
using TestApi.Interface.Repositories.Users;

namespace TestApi.Core
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task CompleteAsync();
    }
}
