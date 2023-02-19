using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models.Entities
{
    public class ShoppingListDetail
    {
        [Key]
        public int ShoppingListDetailId { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        [DefaultValue(false)]
        public bool IsBought { get; set; }

        public Product Product { get; set; }

        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
