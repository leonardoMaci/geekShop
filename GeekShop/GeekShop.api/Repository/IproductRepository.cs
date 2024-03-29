﻿using GeekShop.api.Data.DTOs;

namespace GeekShop.api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Create(ProductDTO product);
        Task<ProductDTO> Update(ProductDTO product);
        Task<bool> Delete(long id);
    }
}
