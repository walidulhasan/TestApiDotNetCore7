using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;
        public UserController(IUnitOfWork unitOfWorks)
        {
            _unitOfWorks= unitOfWorks;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWorks.Users.GetAll());
        }
    }
}
