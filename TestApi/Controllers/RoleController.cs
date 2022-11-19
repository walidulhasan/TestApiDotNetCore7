using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;

        public RoleController(IUnitOfWork unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWorks.Roles.GetAll());

        }
    }
}
