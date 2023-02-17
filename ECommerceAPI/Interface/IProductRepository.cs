using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.ProductModels;
using Solution.Data.Models.Query;

namespace ECommerceAPI.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<DetailProductDto>> GetAllProducts();
        Task<IEnumerable<DetailProductDto>> GetProductsByPage(PaginationParameters parameters);
        Task<LiteProductDto> GetOneProduct(int id);
        Task<ReturnStatus> UpdateProduct(DetailProductDto product);
        Task<DetailProductDto> AddOneProduct(LiteProductDto product);
        Task<ReturnStatus> DeleteProduct(int productId);
    }
}
