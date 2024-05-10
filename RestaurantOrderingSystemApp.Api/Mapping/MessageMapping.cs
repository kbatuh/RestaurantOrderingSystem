using AutoMapper;
using RestaurantOrderingSystemApp.DtoLayer.MessageDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {

            CreateMap<Message ,ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();



        }

    }
}
