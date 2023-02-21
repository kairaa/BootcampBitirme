using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;

namespace Mvc.Services.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GetProductDto>> GetProductsAsync()
        {
            return await _context.Products.Select(a => new GetProductDto
            {
                ProductId = a.ProductId,
                CategoryName = a.Category.CategoryName,
                ProductName = a.ProductName,
                ProductImage = a.ProductImage
            }).ToListAsync();
        }
    }
}
