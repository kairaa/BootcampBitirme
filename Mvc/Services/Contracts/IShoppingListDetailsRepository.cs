using Mvc.Models.Dtos;
using Mvc.Models.Entities;

namespace Mvc.Services.Contracts
{
    public interface IShoppingListDetailsRepository : IGenericRepository<ShoppingListDetail>
    {
        Task<List<GetListProductsDto>> GetProductsAsync(int listId);
        Task RemoveProductFromList(int productId, int listId);
        Task BuyProduct(int productId, int listId);
    }
}
