using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Solution.Data.Entities;
using Solution.Data.Enums;
using Solution.Data.Models.ProductModels;
using Solution.Data.Models.Query;

namespace ECommerceAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DetailProductDto> AddOneProduct(LiteProductDto product)
        {
            var category = await _context.Categories.FindAsync(product.CategoryId);
            if (category == null)
            {
                return null;
            }
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPercent = product.DiscountPercent,
                ImagePath = product.ImagePath,
                Category = category,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<DetailProductDto>(newProduct);
        }

        public async Task<ReturnStatus> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return ReturnStatus.Success;
            }
            return ReturnStatus.Failure;
        }

        public async Task<IEnumerable<DetailProductDto>> GetAllProducts()
        {
            var productList = await _context.Products.Include(p => p.Category).ToListAsync();
            return _mapper.Map<IEnumerable<DetailProductDto>>(productList);
        }

        public async Task<LiteProductDto> GetOneProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<LiteProductDto>(product);
        }

        public async Task<IEnumerable<DetailProductDto>> GetProductsByPage(PaginationParameters parameters)
        {
            var productList = await _context.Products
                .Include(p => p.Category)
                .Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize)
                .ToListAsync();
            return _mapper.Map<IEnumerable<DetailProductDto>>(productList);
        }

        public async Task<ReturnStatus> UpdateProduct(DetailProductDto product)
        {
            var category = await _context.Categories.FindAsync(product.CategoryId);
            if (category == null)
            {
                return ReturnStatus.Failure;
            }
            var newProduct = await _context.Products.FindAsync(product.Id);
            if (newProduct == null)
            {
                return ReturnStatus.Failure;
            }
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Category = category;
            newProduct.UpdatedDate = DateTime.Now;
            newProduct.CreatedDate = product.CreatedDate;
            newProduct.ImagePath = product.ImagePath;
            newProduct.DiscountPercent = product.DiscountPercent;
            newProduct.Price = product.Price;
            await _context.SaveChangesAsync();
            return ReturnStatus.Success;
        }
    }
}
