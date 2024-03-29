﻿using AutoMapper;
using GeekShop.api.Data.DTOs;
using GeekShop.api.Model;

namespace GeekShop.api.Config
{
    public class MapConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config => 
            {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
            });

            return mappingConfiguration;
        }
    }
}
