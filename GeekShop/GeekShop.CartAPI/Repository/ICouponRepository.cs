using GeekShop.CartAPI.Data.DTOs;

namespace GeekShop.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCoupon(string couponCode, string token);
    }
}
