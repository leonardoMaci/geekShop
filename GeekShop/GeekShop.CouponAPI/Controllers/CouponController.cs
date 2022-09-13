using GeekShop.CouponAPI.Data.DTOs;
using GeekShop.CouponAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CouponController : Controller
    {
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("{couponCode}")]
        [Authorize]
        public async Task<ActionResult<CouponDTO>> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }
    }
}
