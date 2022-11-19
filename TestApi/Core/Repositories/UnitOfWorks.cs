using TestApi.Data;
using TestApi.Interface.Repositories.Products;
using TestApi.Interface.Repositories.Roles;
using TestApi.Interface.Repositories.Users;
using TestApi.InterfaceImplementation.Repositories;
using TestApi.InterfaceImplementation.Repositories.Products;
using TestApi.InterfaceImplementation.Repositories.Roles;
using TestApi.InterfaceImplementation.Repositories.Users;

namespace TestApi.Core.Repositories
{
    public class UnitOfWorks : IUnitOfWork, IDisposable
    {
        private readonly TestApiDbContext _context;

        public IUserRepository Users {get; private set;}

        public IRoleRepository Roles { get; private set; }

        public IProductRepository Products { get; private set; }

        public UnitOfWorks(TestApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger(categoryName: "logs");
            Users = new UserRepository(_context, _logger);
            Roles=new RoleRepository(_context, _logger);
            Products = new ProductRepository(_context, _logger);

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
