using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;

namespace Mvc.Services.Repositories
{
    public class ShoppingListDetailsRepository : GenericRepository<ShoppingListDetail>, IShoppingListDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListDetailsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GetListProductsDto>> GetProductsAsync(int listId)
        {
            /*
             * return await _context.Products.Select(a => new GetProductDto
            {
                ProductId = a.ProductId,
                CategoryName = a.Category.CategoryName,
                ProductName = a.ProductName,
                ProductImage = a.ProductImage
            }).ToListAsync();
             */
            return await _context.ShoppingListDetail.Where(a => a.ShoppingListId == listId).Select(a => new GetListProductsDto
            {
                Product = a.Product,
                IsBought = a.IsBought,
                Amount = a.Amount,
                Description = a.Description
            }).ToListAsync();
        }
    }
}
