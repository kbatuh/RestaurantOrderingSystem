using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.CouponDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public IActionResult CouponList()
        {
            var values = _couponService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCoupon(CreateCouponDto createCouponDto)
        {
            Coupon coupon = new Coupon()
            {
                CouponCode = createCouponDto.CouponCode,
                Amount = createCouponDto.Amount,
                Status = true
            };

            _couponService.TAdd(coupon);
            return Ok("Kupon kodu başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(int id)
        {
            var value = _couponService.TGetByID(id);
            _couponService.TDelete(value);
            return Ok("Kupon kodu silindi");
        }

        [HttpPut]
        public IActionResult UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            Coupon coupon = new Coupon()
            {
                CouponID = updateCouponDto.CouponID,
                CouponCode = updateCouponDto.CouponCode,
                Amount = updateCouponDto.Amount,
                Status = updateCouponDto.Status,
            };
            _couponService.TUpdate(coupon);
            return Ok("Kupon kodu güncellendi ");
        }

        [HttpGet("{id}")]
        public IActionResult GetCoupon(int id)
        {
            var value = _couponService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _couponService.TChangeStatus(id);
            return Ok("Kupon Durumu Değiştirildi");
        }

        [HttpGet("GetAmountByCouponCode")]
        public IActionResult GetAmountByCouponCode(string couponCode)
        {
            var value = _couponService.TGetAmountByCouponCode(couponCode);
            return Ok(value);
        }
    }
}
