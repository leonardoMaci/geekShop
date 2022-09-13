using GeekShop.CouponAPI.Data.DTOs;
using System.Threading.Tasks;

namespace GeekShop.CouponAPI.Services
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCouponCode(string couponCode);
    }
}
