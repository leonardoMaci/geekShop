﻿using GeekShop.web.Models;
using GeekShop.web.Utils;
using System.Net.Http.Headers;

namespace GeekShop.web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Product> CreateProduct(Product product, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Product>();
            else
                throw new Exception("Something went wrong calling the API");
        }

        public async Task<bool> DeleteProduct(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong calling the API");
        }

        public async Task<IEnumerable<Product>> FindAllProducts(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<Product>>();
        }

        public async Task<Product> FindByIdProduct(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<Product>();
        }

        public async Task<Product> UpdateProduct(Product product, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Product>();
            else
                throw new Exception("Something went wrong calling the API");
        }
    }
}
