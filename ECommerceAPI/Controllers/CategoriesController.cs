using ECommerceAPI.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.CategoryModels;
using Solution.Data.Models.Query;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoryList = await _categoryRepository.GetAllCategories();
            return Ok(categoryList);
        }
        
        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesByPage([FromQuery] PaginationParameters parameters)
        {
            var validPagingatonParameters = new PaginationParameters(parameters.PageNumber, parameters.PageSize);

            var categoryList = await _categoryRepository.GetCategoriesByPage(validPagingatonParameters);
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetOneCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            var result = await _categoryRepository.UpdateCategory(category);
            if (result == ReturnStatus.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto category)
        {
            _ = await _categoryRepository.AddOneCategory(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategory(id);
            if (result == ReturnStatus.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
