using ECommerceAPI.Data;
using ECommerceAPI.Interface;
using ECommerceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.CategoryModels;
using Solution.Data.Models.ProductModels;
using Solution.Data.Models.Query;
using System.Collections.Generic;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProducts()
        {
            var categoryList = await _productRepository.GetAllProducts();
            return Ok(categoryList);
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProductsByPage([FromQuery] PaginationParameters parameters)
        {
            var validPagingatonParameters = new PaginationParameters(parameters.PageNumber, parameters.PageSize);

            var categoryList = await _productRepository.GetProductsByPage(validPagingatonParameters);
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LiteProductDto>> GetProduct(int id)
        {
            var product = await _productRepository.GetOneProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, DetailProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }
            var result = await _productRepository.UpdateProduct(productDto);
            if (result == ReturnStatus.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<DetailProductDto>> PostProduct(LiteProductDto liteProduct)
        {
            
            var product = await _productRepository.AddOneProduct(liteProduct);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProduct(id);
            if (result == ReturnStatus.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
