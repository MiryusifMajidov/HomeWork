using InanceBL.Services;
using InanceModels.DTOs.UserDtos;
using InanceModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Inance.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService _emailService;




        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }


        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto userDto) 
        {
            AppUser appUser = new AppUser
            {
                FirtsName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Username,
                
            };


          

            var result = await _userManager.CreateAsync(appUser, userDto.Password);

            if (!result.Succeeded) 
            { 
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);

                }

                return View(userDto);

            }

            await _userManager.AddToRoleAsync(appUser, "User");
            await _signInManager.SignInAsync(appUser, isPersistent: false);

            try
            {
                string subject = "Qeydiyyat təsdiqi";
                string body = $"Salam {userDto.FirstName},<br/>Qeydiyyatınız uğurla tamamlandı!";
                _emailService.SendMail(userDto.Email, subject, body);

                ViewBag.Message = "E-poçt uğurla göndərildi.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "E-poçt göndərilməsində problem var: " + ex.Message;
            }

            return RedirectToAction(nameof(Index),"Home"); 
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginDto userDto) 
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


            var result = await _signInManager.PasswordSignInAsync(user,userDto.Password, userDto.isPersistant, true);

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
