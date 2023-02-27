using Mvc.Models.Entities;

namespace Mvc.Models.Dtos
{
    public class CreateShoppingListDto
    {
        public string ListName { get; set; }
        public string? Description { get; set; }
        public User User { get; set; }
    }
}
