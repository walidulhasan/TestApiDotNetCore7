using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApi.Core;
using TestApi.ModelRsDto.Products.ProductsDTO;
using TestApi.Models.Products;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWorks,IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWorks.Products.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var Product = await _unitOfWorks.Products.GetById(id);
            if (Product == null) return NotFound();

            return Ok(Product);
        }
        [HttpPost]
        [Route(template: "CreateProduct")]
        public async Task<IActionResult> CreateUser(ProductDTO productDTO)
        {
            var entity = _mapper.Map<Product>(productDTO);
            await _unitOfWorks.Products.Add(entity);
            await _unitOfWorks.CompleteAsync();
            return Ok(productDTO);
        }

        [HttpPut]
        [Route(template: "UpdateProduct")]
        public async Task<IActionResult> UpdateUser(ProductDTO productDTO)
        {
            var existUser = await _unitOfWorks.Products.GetById(productDTO.ProductId);
            if (existUser == null) return NotFound();

            existUser.Name=productDTO.Name;
            existUser.Slug = productDTO.Slug;
            existUser.ImageUrl = productDTO.ImageUrl;
            existUser.CategoryId = productDTO.CategoryId;
            existUser.Price = productDTO.Price;
            existUser.Stock = productDTO.Stock;

            await _unitOfWorks.Products.Update(existUser);
            await _unitOfWorks.CompleteAsync();
            return Ok(productDTO);
        }
        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var existData = await _unitOfWorks.Products.GetById(id);
            if (existData == null) return NotFound();
            existData.IsDeleted = true;
            existData.IsActive = false;
            await _unitOfWorks.Products.Update(existData);
            await _unitOfWorks.CompleteAsync();
            return Ok(existData);
        }
    }
}
