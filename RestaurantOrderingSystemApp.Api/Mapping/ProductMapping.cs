using AutoMapper;
using RestaurantOrderingSystemApp.DtoLayer.ProductDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>()
                .ForMember(e => e.CategoryName, o => o.MapFrom(d => d.Category.CategoryName))
                .ReverseMap();
        }
    }
}
