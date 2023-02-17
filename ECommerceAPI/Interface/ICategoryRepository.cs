using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.CategoryModels;
using Solution.Data.Models.Query;

namespace ECommerceAPI.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetOneCategory(int categoryId);
        Task<ReturnStatus> UpdateCategory(CategoryDto category);
        Task<CategoryDto> AddOneCategory(CategoryDto category);
        Task<ReturnStatus> DeleteCategory(int categoryId);
        Task<IEnumerable<CategoryDto>> GetCategoriesByPage(PaginationParameters parameters);
    }
}
