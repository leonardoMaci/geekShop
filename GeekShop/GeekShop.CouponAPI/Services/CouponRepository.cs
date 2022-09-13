using AutoMapper;
using GeekShop.CouponAPI.Data.DTOs;
using GeekShop.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.CouponAPI.Services
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDTO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponDTO>(coupon);
        }
    }
}
