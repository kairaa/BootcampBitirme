using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models.Entities
{
    public class ShoppingList
    {
        [Key]
        public int ListId { get; set; }
        public string ListName { get; set; }
        public string? Description { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingListDetail> ShoppingListDetails { get; set; }
        
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [DefaultValue(false)]
        public bool GoingToShopping { get; set; }
    }
}
