using TestApi.Common.Mappings;
using TestApi.Models.Roles;

namespace TestApi.ModelRsDto.Roles.RoleDtoModel;

public class RoleDTO : IMapFrom<Role>
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public bool IsSupperAdmin { get; set; } = false;

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<RoleDTO, Role>().ReverseMap();
    }
}
