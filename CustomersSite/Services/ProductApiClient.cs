using Solution.Data.Models.ProductModels;

namespace CustomersSite.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IProductApiClient _productApiClient;
        public ProductApiClient(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<List<LiteProductDto>> GetAllProducts()
        {
            return await _productApiClient.GetAllProducts();
        }

        public async Task<LiteProductDto> GetProductById(int productId)
        {
            return await _productApiClient.GetProductById(productId);
        }
    }
}
