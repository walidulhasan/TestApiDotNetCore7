
using TestApi.Common.Mappings;
using TestApi.Models.Users;

namespace TestApi.ModelRsDto.Users.UserDtos
{
    public class UserDTO: IMapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UserDTO, User>().ReverseMap();
        }

    }
}
