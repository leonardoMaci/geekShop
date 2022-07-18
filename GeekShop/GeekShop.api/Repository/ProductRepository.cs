using AutoMapper;
using GeekShop.api.Data.DTOs;
using GeekShop.api.Model;
using GeekShop.api.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.api.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO product)
        {
            var productMap = _mapper.Map<Product>(product);
            _context.Add(productMap);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(productMap);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);

                if (product == null)
                    return false;
                else 
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            var product = await _context.Products.Where(p => p.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO product)
        {
            var productMap = _mapper.Map<Product>(product);
            _context.Update(productMap);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(productMap);
        }
    }
}
