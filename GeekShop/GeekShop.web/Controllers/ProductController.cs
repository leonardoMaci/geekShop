using GeekShop.web.Models;
using GeekShop.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<ActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();

            return View(products);
        }

        public async Task<ActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ProductCreate(Product product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);

                if(response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        public async Task<ActionResult> ProductUpdate(long id)
        {
            var response = await _productService.FindByIdProduct(id);

            if (response != null)
                return View(response);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> ProductUpdate(Product product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        public async Task<ActionResult> ProductDelete(long id)
        {
            var response = await _productService.FindByIdProduct(id);
            
            if (response != null)
                return View(response);

            return NotFound();
        }
        
        [HttpPost]
        public async Task<ActionResult> ProductDelete(Product product)
        {
            var response = await _productService.DeleteProduct(product.ID);

            if(response) 
                return RedirectToAction(nameof(ProductIndex));

            return View(product);
        }
    }
}
