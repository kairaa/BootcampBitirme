using Mvc.Models.Entities;

namespace Mvc.Models.Dtos
{
    public class GetListProductsDto
    {
        public Product Product { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool IsBought { get; set; }
    }
}
