using Microsoft.EntityFrameworkCore;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Roles;
using TestApi.Models.Roles;
using TestApi.Models.Users;

namespace TestApi.InterfaceImplementation.Repositories.Roles
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(TestApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Role.Where(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();

        }
    }
}
