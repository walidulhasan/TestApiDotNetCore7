

using TestApi.Common.Mappings;
using TestApi.ModelRsDto.Users.UserDtos;
using TestApi.Models.Products;
using TestApi.Models.Users;

namespace TestApi.ModelRsDto.Products.ProductsDTO;

public class ProductDTO:IMapFrom<Product>
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<ProductDTO, Product>().ReverseMap();
    }
}
