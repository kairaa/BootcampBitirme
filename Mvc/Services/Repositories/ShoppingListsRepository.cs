using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;

namespace Mvc.Services.Repositories
{
    public class ShoppingListsRepository : GenericRepository<ShoppingList>, IShoppingListsRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingListsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShoppingList> GetListAsync(int listId)
        {
            return await _context.ShoppingList.Include(a => a.User)
                .Where(a => a.ListId == listId)
                .SingleOrDefaultAsync();
        }

        public async Task<List<ShoppingList>> GetListsByUserId(int userId)
        {
            return await _context.ShoppingList.Where(a => a.User.Id == userId).ToListAsync();
        }

        public async Task GoShoppingForList(ShoppingList list)
        {
            list.GoingToShopping = true;
            _context.ShoppingList.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task CompleteShopping(ShoppingList list)
        {
            list.GoingToShopping = false;
            _context.ShoppingList.Update(list);
            await _context.SaveChangesAsync();
        }
    }
}
