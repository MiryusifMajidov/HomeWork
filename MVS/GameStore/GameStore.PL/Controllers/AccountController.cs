using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs.User;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            AppUser user = new AppUser
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Username,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(userDto);
            }

            
            await _userManager.AddToRoleAsync(user, "User");

            
            await _signInManager.SignInAsync(user, isPersistent: false);

           
            await _emailSender.SendEmailAsync(user.Email, "Qeydiyyat Uğurludur",
                "<h1>Sizə salamlar!</h1><p>Qeydiyyatınız uğurla tamamlandı.</p>");

            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            var user = await _userManager.FindByEmailAsync(userDto.UsernameOrEmail) ?? await _userManager.FindByEmailAsync(userDto.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "user or password not found");
                return View(userDto);

            }
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                ModelState.AddModelError(string.Empty, "You do not have the required role.");
                return View(userDto);
            }


            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.isPersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(userDto);
            }

            return RedirectToAction(nameof(Index), "Home");


        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


    }
}
