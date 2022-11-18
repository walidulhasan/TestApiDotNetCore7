using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Models.Roles;

namespace TestApi.Models.Users;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}
