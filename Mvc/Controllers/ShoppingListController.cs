using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ShoppingListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
