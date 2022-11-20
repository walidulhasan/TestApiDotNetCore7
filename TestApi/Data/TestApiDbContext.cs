using Microsoft.EntityFrameworkCore;
using TestApi.Models.Categorys;
using TestApi.Models.OrderDetails;
using TestApi.Models.Orders;
using TestApi.Models.PaymentDetails;
using TestApi.Models.Products;
using TestApi.Models.Roles;
using TestApi.Models.Shipments;
using TestApi.Models.Users;

namespace TestApi.Data;

public class TestApiDbContext : DbContext
{
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Category> Categorie { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Shipment> Shipment { get; set; }
    public DbSet<PaymentDetail> PaymentDetail { get; set; }
    public TestApiDbContext(DbContextOptions<TestApiDbContext> options) : base(options)
    {

    }
}
