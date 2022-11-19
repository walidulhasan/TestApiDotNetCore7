using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;

        public ProductController(IUnitOfWork unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWorks.Products.GetAll());
        }
    }
}
