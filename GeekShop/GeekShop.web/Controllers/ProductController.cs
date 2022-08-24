using GeekShop.web.Models;
using GeekShop.web.Services;
using GeekShop.web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public async Task<ActionResult> ProductIndex()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAllProducts(token);

            return View(products);
        }

        public async Task<ActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ProductCreate(Product product)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProduct(product, token);

                if(response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        public async Task<ActionResult> ProductUpdate(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.FindByIdProduct(id, token);

            if (response != null)
                return View(response);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ProductUpdate(Product product)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct(product, token);

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        [Authorize]
        public async Task<ActionResult> ProductDelete(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.FindByIdProduct(id, token);
            
            if (response != null)
                return View(response);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ProductDelete(Product product)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProduct(product.ID, token);

            if(response) 
                return RedirectToAction(nameof(ProductIndex));

            return View(product);
        }
    }
}
