using GeekShop.web.Models;

namespace GeekShop.web.Services
{
    public interface IProductServices
    {
        Task<Product> CreateProduct(Product product);
        Task<bool> DeleteProduct(long id);
        Task<Product> UpdateProduct(Product product);
        Task<Product> FindByIdProduct(long id);
        Task<IEnumerable<Product>> FindAllProducts();
    }
}
