using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.OrderDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("OrderListWithMenuTableName")]
        public IActionResult OrderListWithMenuTableName()
        {
            var values = _mapper.Map<List<ResultOrderWithMenuTableNameDto>>(_orderService.TGetOrdersWithMenuTableNames());
            return Ok(values);
        }

        [HttpGet("FindOrderByMenuTableId/{id}")]
        public IActionResult FindOrderByMenuTableId(int id)
        {
            var value = _mapper.Map<ResultOrderWithMenuTableNameDto>(_orderService.TFindOrderByMenuTableId(id));
            return Ok(value);
        }

        [HttpGet("FindOrderWithMenuTableName/{id}")]
        public IActionResult FindOrderWithMenuTableName(int id)
        {
            var value = _mapper.Map<ResultOrderWithMenuTableNameDto>(_orderService.TFindOrderWithMenuTableName(id));
            return Ok(value);
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("CloseAccount/{id}")]
        public IActionResult CloseAccount(int id)
        {
            _orderService.TCloseAccount(id);
            return Ok("Hesap Kapatıldı");
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            _orderService.TAdd(new Order()
            {
                OrderDate = createOrderDto.OrderDate,
                TotalPrice = createOrderDto.TotalPrice,
                TotalDiscount = createOrderDto.TotalDiscount,
                FinalPrice = createOrderDto.FinalPrice,
                Status = true,
                MenuTableID = createOrderDto.MenuTableID,
            });
            return Ok("Sipariş Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            _orderService.TDelete(value);
            return Ok("Sipariş Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            _orderService.TUpdate(new Order()
            {
                OrderID = updateOrderDto.OrderID,
                OrderDate = updateOrderDto.OrderDate,
                TotalPrice = updateOrderDto.TotalPrice,
                TotalDiscount = updateOrderDto.TotalDiscount,
                FinalPrice = updateOrderDto.FinalPrice,
                Status = updateOrderDto.Status,
                MenuTableID = updateOrderDto.MenuTableID,
            });
            return Ok("Sipariş Bilgisi Güncellendi");
        }

    }
}
