using Refit;
using Solution.Data.Models.ProductModels;

namespace CustomersSite.Services
{
    public interface IProductApiClient
    {
        [Get("/Products/GetProducts")]
        Task<List<LiteProductDto>> GetAllProducts();

        [Get("/Products/{productId}")]
        Task<LiteProductDto> GetProductById(int productId);
    }
}
