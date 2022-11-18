using TestApi.Data;
using TestApi.Interface.Repositories.Users;
using TestApi.InterfaceImplementation.Repositories;

namespace TestApi.Core.Repositories
{
    public class UnitOfWorks : IUnitOfWork, IDisposable
    {
        private readonly TestApiDbContext _context;

        public IUserRepository Users { get; private set; }
        public UnitOfWorks(TestApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger(categoryName: "logs");
            Users = new UserRepository(_context, _logger);
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
