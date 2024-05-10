using AutoMapper;
using RestaurantOrderingSystemApp.DtoLayer.BasketDto;

using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketWithProductDto>()
                .ForMember(e => e.Price, o => o.MapFrom(d => d.Product.Price))
                .ForMember(e => e.ProductName, o => o.MapFrom(d => d.Product.ProductName))
                .ReverseMap();

            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            
        }
    }
}
