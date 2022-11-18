using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.Roles
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsSupperAdmin { get; set; } = false;
    }
}
