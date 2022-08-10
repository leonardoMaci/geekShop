using AutoMapper;
using GeekShop.api.Data.DTOs;
using GeekShop.api.Model;

namespace GeekShop.api.Config
{
    public class MapConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(Config => 
            { 
                Config.CreateMap<ProductDTO, Product>(); 
                Config.CreateMap<Product, ProductDTO>();
            });

            return mappingConfiguration;
        }
    }
}
