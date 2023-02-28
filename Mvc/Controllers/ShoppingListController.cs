using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;
using Mvc.Services.Repositories;
using System.Text.Json;

namespace Mvc.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListsRepository _shoppingListsRepository;
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        private readonly UserManager<User> _userManager;
        private readonly IShoppingListDetailsRepository _shoppingListDetailsRepository;
        public ShoppingListController(IShoppingListsRepository shoppingListsRepository, IMapper mapper, IProductsRepository productsRepository, UserManager<User> userManager, IShoppingListDetailsRepository shoppingListDetailsRepository)
        {
            _shoppingListsRepository = shoppingListsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _userManager = userManager;
            _shoppingListDetailsRepository = shoppingListDetailsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cookieUser = JsonSerializer.Deserialize<CookieUser>(Request.Cookies["User"]);
            var lists = await _shoppingListsRepository.GetListsByUserId(cookieUser.Id);
            return View(lists);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            var cookieUser = JsonSerializer.Deserialize<CookieUser>(Request.Cookies["User"]);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(CreateShoppingListDto createShoppingListDto)
        {
            var cookieUser = JsonSerializer.Deserialize<CookieUser>(Request.Cookies["User"]);
            var user = await _userManager.FindByEmailAsync(cookieUser.UserName);
            createShoppingListDto.User = user;
            /*
             * var category = _mapper.Map<Category>(createCategoryDto);
                await _categoryRepository.AddAsync(category);
                return RedirectToAction(nameof(Index));
             * */
            var shoppingList = _mapper.Map<ShoppingList>(createShoppingListDto);
            await _shoppingListsRepository.AddAsync(shoppingList);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct(int listId)
        {
            var list = await _shoppingListsRepository.GetAsync(listId);
            if (list is not null)
            {
                Response.Cookies.Append("ListId", JsonSerializer.Serialize(new
                {
                    ListId = listId
                }));
                var products = await _productsRepository.GetAllAsync();
                return View(new AddProductToListDto
                {
                    Products = products
                });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductToListDto addProductToListDto)
        {
            var listId = JsonSerializer.Deserialize<CookieListId>(Request.Cookies["ListId"]);
            Response.Cookies.Delete("ListId");
            var product = await _productsRepository.GetAsync(addProductToListDto.ProductId);
            //var shoppingList = await _shoppingListsRepository.GetAsync(addProductToListDto.ShoppingListId);
            var shoppingList = await _shoppingListsRepository.GetAsync(listId.ListId);
            if (product is not null && shoppingList is not null)
            {
                addProductToListDto.Product = product;
                addProductToListDto.ShoppingList = shoppingList;
                var shoppingListDetail = _mapper.Map<ShoppingListDetail>(addProductToListDto);
                await _shoppingListDetailsRepository.AddAsync(shoppingListDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "Ürün eklemede sorun meydana geldi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts(int listId)
        {
            var list = await _shoppingListsRepository.GetListAsync(listId);
            var cookieUser = JsonSerializer.Deserialize<CookieUser>(Request.Cookies["User"]);
            if (list is not null)
            {
                if (list.User.Id != cookieUser.Id)
                {
                    return View("ErrorPage");
                }
                Response.Cookies.Append("ListId", JsonSerializer.Serialize(new
                {
                    ListId = listId
                }));
                var listProducts = await _shoppingListDetailsRepository.GetProductsAsync(listId);
                return View(listProducts);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductFromList(int listDetailId)
        {
            var listId = JsonSerializer.Deserialize<CookieListId>(Request.Cookies["ListId"]);
            Response.Cookies.Delete("ListId");
            await _shoppingListDetailsRepository.RemoveProductFromList(listDetailId);
            return RedirectToAction(nameof(GetListProducts), new { listId = listId.ListId });
        }

        [HttpPost]
        public async Task<IActionResult> GoShoppingForList(int listId)
        {
            var list = await _shoppingListsRepository.GetAsync(listId);
            if (list == null)
            {
                return RedirectToAction(nameof(Index));
            }
            await _shoppingListsRepository.GoShoppingForList(list);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> BuyProduct(int productId)
        {
            var listId = JsonSerializer.Deserialize<CookieListId>(Request.Cookies["ListId"]);
            Response.Cookies.Delete("ListId");
            var product = await _productsRepository.GetAsync(productId);
            if (product is not null)
            {
                await _shoppingListDetailsRepository.BuyProduct(productId, listId.ListId);
                return RedirectToAction(nameof(GetListProducts), new { listId = listId.ListId });
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int listId)
        {
            var list = await _shoppingListsRepository.GetAsync(listId);
            if (list == null)
            {
                return RedirectToAction(nameof(Index));
            }
            await _shoppingListsRepository.DeleteAsync(listId);
            return RedirectToAction(nameof(Index));
        }
    }
}
