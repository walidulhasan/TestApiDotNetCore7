using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;
using TestApi.ModelRsDto.Users.UserDtos;
using TestApi.Models.Users;

namespace TestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWorks;
    private readonly IMapper _mapper;

    public UserController(IUnitOfWork unitOfWorks, IMapper mapper)
    {
        _unitOfWorks = unitOfWorks;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWorks.Users.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _unitOfWorks.Users.GetById(id);
        if (user == null) return NotFound();

        return Ok(user);
    }
    [HttpPost]
    [Route(template: "CreateUser")]
    public async Task<IActionResult> CreateUser(UserDTO user)
    {
        var entity = _mapper.Map<User>(user);
        await _unitOfWorks.Users.Add(entity);
        await _unitOfWorks.CompleteAsync();
        return Ok(user);
    }

    [HttpPut]
    [Route(template: "UpdateUser")]
    public async Task<IActionResult> UpdateUser(UserDTO user)
    {
        var existUser = await _unitOfWorks.Users.GetById(user.Id);
        if (existUser == null) return NotFound();
        existUser.Name = user.Name;
        existUser.UserName = user.UserName;
        existUser.Email = user.Email;
        existUser.Password = user.Password;
        existUser.RoleId = user.RoleId;
        await _unitOfWorks.Users.Update(existUser);
        await _unitOfWorks.CompleteAsync();
        return Ok(user);
    }
    [HttpDelete]
    [Route("RemoveUser")]
    public async Task<IActionResult> RemoveUser(int id)
    {
        var existUser = await _unitOfWorks.Users.GetById(id);
        if (existUser == null) return NotFound();
        existUser.IsDeleted = true;
        existUser.IsActive = false;
        await _unitOfWorks.Users.Update(existUser);
        await _unitOfWorks.CompleteAsync();
        return Ok(existUser);
    }
}
