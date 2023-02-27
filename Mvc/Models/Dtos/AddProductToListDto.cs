using Mvc.Models.Entities;

namespace Mvc.Models.Dtos
{
    public class AddProductToListDto
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public List<Product> Products { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}
