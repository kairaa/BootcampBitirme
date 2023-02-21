using Mvc.Models.Dtos;
using Mvc.Models.Entities;

namespace Mvc.Services.Contracts
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<List<GetProductDto>> GetProductsAsync();
    }
}
