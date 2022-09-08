using AutoMapper;
using GeekShop.CartAPI.Data.DTOs;
using GeekShop.CartAPI.Model;

namespace GeekShop.CartAPI.Config
{
    public class MapConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config => 
            {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
                config.CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailDTO, CartDetail>().ReverseMap();
                config.CreateMap<CartDTO, Cart>().ReverseMap();
            });

            return mappingConfiguration;
        }
    }
}
