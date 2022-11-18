using Microsoft.EntityFrameworkCore;
using TestApi.Models.Roles;
using TestApi.Models.Users;

namespace TestApi.Data
{
    public class TestApiDbContext:DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public TestApiDbContext(DbContextOptions<TestApiDbContext>options):base(options)
        {

        }
    }
}
