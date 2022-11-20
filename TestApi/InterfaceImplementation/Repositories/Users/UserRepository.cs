using Microsoft.EntityFrameworkCore;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Users;
using TestApi.Models.Users;

namespace TestApi.InterfaceImplementation.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(TestApiDbContext context, ILogger logger) : base(context, logger)
    {
    }
    public override async Task<IEnumerable<User>> GetAll()
    {
        return await _context.User.Where(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();
    }
}
