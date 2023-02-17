using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.CategoryModels;
using Solution.Data.Models.Query;

namespace ECommerceAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddOneCategory(CategoryDto category)
        {
            var newCategory = _mapper.Map<Category>(category);
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            category.Id = newCategory.Id;
            return category;
        }

        public async Task<ReturnStatus> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return ReturnStatus.Success;
            }
            return ReturnStatus.Failure;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _context.Categories.ToListAsync());
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesByPage(PaginationParameters parameters)
        {
            var categories = await _context.Categories
                .Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetOneCategory(int categoryId)
        {
            return _mapper.Map<CategoryDto>(await _context.Categories.FindAsync(categoryId));
        }

        public async Task<ReturnStatus> UpdateCategory(CategoryDto category)
        {
            var newCategory = await _context.Categories.FindAsync(category.Id);
            if (newCategory != null)
            {
                newCategory.Name = category.Name;
                newCategory.Description = category.Description;
                await _context.SaveChangesAsync();
                return ReturnStatus.Success;
            }
            return ReturnStatus.Failure;
        }
    }
}
