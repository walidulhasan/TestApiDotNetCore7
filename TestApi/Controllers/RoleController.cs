using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;
using TestApi.ModelRsDto.Roles.RoleDtoModel;
using TestApi.ModelRsDto.Users.UserDtos;
using TestApi.Models.Roles;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public RoleController(IUnitOfWork unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWorks.Roles.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _unitOfWorks.Roles.GetById(id);
            if (role == null) return NotFound();
            return Ok(role);
        }
        [HttpPost]
        [Route(template: "CreateRole")]
        public async Task<IActionResult> CreateUser(RoleDTO roleDTO)
        {
            var entity = _mapper.Map<Role>(roleDTO);
            await _unitOfWorks.Roles.Add(entity);
            await _unitOfWorks.CompleteAsync();
            return Ok(entity);
        }

        [HttpPut]
        [Route(template: "UpdateRole")]
        public async Task<IActionResult> UpdateUser(RoleDTO roleDTO)
        {
            var existUser = await _unitOfWorks.Roles.GetById(roleDTO.RoleId);
            if (existUser == null) return NotFound();
            existUser.Name = roleDTO.Name;
            existUser.IsSupperAdmin=roleDTO.IsSupperAdmin;
            await _unitOfWorks.Roles.Update(existUser);
            await _unitOfWorks.CompleteAsync();
            return Ok(roleDTO);
        }
        [HttpDelete]
        [Route("RemoveRole")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var existData = await _unitOfWorks.Roles.GetById(id);
            if (existData == null) return NotFound();
            existData.IsDeleted = true;
            existData.IsActive = false;
            await _unitOfWorks.Roles.Update(existData);
            await _unitOfWorks.CompleteAsync();
            return Ok(existData);
        }
    }
}
