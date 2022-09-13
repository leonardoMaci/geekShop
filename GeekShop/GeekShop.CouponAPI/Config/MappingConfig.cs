using AutoMapper;
using GeekShop.CouponAPI.Data.DTOs;
using GeekShop.CouponAPI.Model;

namespace GeekShop.CouponAPI.Config
{
    public class MapConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CouponDTO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
