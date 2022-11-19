using Microsoft.EntityFrameworkCore;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Products;
using TestApi.Models.Products;
using TestApi.Models.Users;

namespace TestApi.InterfaceImplementation.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TestApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.Where(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();
        }
    }
}
