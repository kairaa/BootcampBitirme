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
            return await _context.ShoppingListDetail.Where(a => a.ShoppingListId == listId)
                .Select(a => new GetListProductsDto
                {
                    ListDetailId = a.ShoppingListDetailId,
                    Product = a.Product,
                    IsBought = a.IsBought,
                    Amount = a.Amount,
                    Description = a.Description
                }).ToListAsync();
        }

        public async Task RemoveProductFromList(int listDetailId)
        {
            /*
             * var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
             */
            var listDetail = await _context.ShoppingListDetail
                .Where(a => a.ShoppingListDetailId == listDetailId).SingleOrDefaultAsync();
            _context.ShoppingListDetail.Remove(listDetail);
            await _context.SaveChangesAsync();
        }

        public async Task BuyProduct(int productId, int listId)
        {
            var listDetail = await _context.ShoppingListDetail.Where(a => a.Product.ProductId == productId && a.ShoppingListId == listId).FirstOrDefaultAsync();
            listDetail.IsBought = true;
            _context.ShoppingListDetail.Update(listDetail);
            await _context.SaveChangesAsync();
        }
    }
}
