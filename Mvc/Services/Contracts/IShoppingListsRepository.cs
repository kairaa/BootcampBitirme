using Mvc.Models.Dtos;
using Mvc.Models.Entities;

namespace Mvc.Services.Contracts
{
    public interface IShoppingListsRepository : IGenericRepository<ShoppingList>
    {
        Task<ShoppingList> GetListAsync(int id);
        Task<List<ShoppingList>> GetListsByUserId(int userId);
        Task GoShoppingForList(ShoppingList list);
        Task CompleteShopping(ShoppingList list);
    }
}
