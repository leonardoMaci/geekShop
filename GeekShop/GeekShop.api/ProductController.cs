using AutoMapper;
using GeekShop.api.Data.DTOs;
using GeekShop.api.Model;
using GeekShop.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(Repository));
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromBody]ProductDTO product)
        {

            if (product == null)
                return BadRequest();

            var productResponse = await _productRepository.Create(product);

            return Ok(productResponse);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(long id)
        {
            var state = await _productRepository.Delete(id);

            if (!state) return BadRequest();

            return Ok(state);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO product)
        {

            if (product == null)
                return BadRequest();

            var productResponse = await _productRepository.Update(product);

            return Ok(productResponse);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

    }
}
