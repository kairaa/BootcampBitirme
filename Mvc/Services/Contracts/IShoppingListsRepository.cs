using Mvc.Models.Dtos;
using Mvc.Models.Entities;

namespace Mvc.Services.Contracts
{
    public interface IShoppingListsRepository : IGenericRepository<ShoppingList>
    {
        Task<List<ShoppingList>> GetListsByUserId(int userId);
        Task GoShoppingForList(ShoppingList list);
    }
}
