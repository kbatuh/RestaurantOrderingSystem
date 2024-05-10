using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.OrderDetailDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet("OrderDetailListWithProduct/{id}")]
        public IActionResult OrderDetailListWithProduct(int id)
        {
            var values = _mapper.Map<List<ResultOrderDetailWithProductDto>>(_orderDetailService.TGetOrderDetailsWithProducts(id));
            return Ok(values);
        }

        [HttpGet("OrderDetailsByCustomerCodeWithProducts/{code}")]
        public IActionResult OrderDetailsByCustomerCodeWithProducts(string code)
        {
            var values = _mapper.Map<List<ResultOrderDetailWithProductDto>>(_orderDetailService.TGetOrderDetailsByCustomerCodeWithProducts(code));
            return Ok(values);
        }

        [HttpGet("ChangeDescription/{id}")]
        public IActionResult ChangeDescription(int id)
        {
            _orderDetailService.TChangeDescription(id);
            return Ok("Sipariş Durumu Değiştirildi");
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
        {
            _orderDetailService.TAdd(new OrderDetail()
            {
                Count = createOrderDetailDto.Count,
                TotalPrice = createOrderDetailDto.TotalPrice,
                Description = createOrderDetailDto.Description,
                CustomerCode = createOrderDetailDto.CustomerCode,
                ProductID = createOrderDetailDto.ProductID,
                OrderID = createOrderDetailDto.OrderID,
            });
            return Ok("Sipariş Detayı Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var value = _orderDetailService.TGetByID(id);
            _orderDetailService.TDelete(value);
            return Ok("Sipariş Detayı Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            var value = _orderDetailService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
        {
            _orderDetailService.TUpdate(new OrderDetail()
            {
                OrderDetailID = updateOrderDetailDto.OrderDetailID,
                Count = updateOrderDetailDto.Count,
                TotalPrice = updateOrderDetailDto.TotalPrice,
                Description = updateOrderDetailDto.Description,
                CustomerCode = updateOrderDetailDto.CustomerCode,
                ProductID = updateOrderDetailDto.ProductID,
                OrderID = updateOrderDetailDto.OrderID,
            });
            return Ok("Sipariş Detayı Güncellendi");
        }
    }
}
