using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using System.Text.Json;

namespace Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if(user != null) 
                {
                    //üçüncü parametre rememberme, dördüncü parametre fazla hatalı girişte profili bloklamak için
                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        Response.Cookies.Append("User", JsonSerializer.Serialize(new
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Id = user.Id,
                            UserName = user.UserName
                        }));
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eposta veya şifre hatalı");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresi veya sifre hatali");
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(registerDto);
                user.UserName = registerDto.Email;
                user.NormalizedEmail = registerDto.Email.ToUpper();
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                await _userManager.AddToRoleAsync(user, "User");
                if(user != null)
                {
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View("Register", registerDto);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "hata");
                    return View("Index");
                }
            }
            else
            {
                return View("Register");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("User");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
