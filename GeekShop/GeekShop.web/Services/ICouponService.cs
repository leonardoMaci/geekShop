using GeekShop.web.Models;

namespace GeekShop.web.Services
{
    public interface ICouponService
    {
        public Task<Coupon> GetCoupon(string code, string token);
    }
}
