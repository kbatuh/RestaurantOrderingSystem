using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.BasketDto;
using RestaurantOrderingSystemApp.DtoLayer.CategoryDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("GetBasketByCustomerCodeWithProductName/{code}")]
        public IActionResult GetBasketByMenuTableNumberWithProductName(string code)
        {
            var values = _mapper.Map<List<ResultBasketWithProductDto>>(_basketService.TGetBasketByCustomerCodeWithProductName(code));
            return Ok(values);
        }

        [HttpDelete("DeleteBasketByCustomerCode/{code}")]
        public IActionResult DeleteBasketByCustomerCode(string code)
        {
            _basketService.TDeleteBasketByCustomerCode(code);
            return Ok("Sepet Boşaltıldı");
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAdd(new Basket()
            {
                Count=createBasketDto.Count,
                TotalPrice = createBasketDto.TotalPrice,
                CustomerCode = createBasketDto.CustomerCode,
                ProductID=createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID
            });
            return Ok("Ürün Sepete Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Seçilen Ürün Sepetten Silindi");
        }
    }
}
