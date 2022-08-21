using GeekShop.web.Models;

namespace GeekShop.web.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product, string token);
        Task<bool> DeleteProduct(long id, string token);
        Task<Product> UpdateProduct(Product product, string token);
        Task<Product> FindByIdProduct(long id, string token);
        Task<IEnumerable<Product>> FindAllProducts(string token);
    }
}
