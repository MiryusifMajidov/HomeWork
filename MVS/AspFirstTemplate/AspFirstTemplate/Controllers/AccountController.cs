using AspFirstTemplate.Data;
using AspFirstTemplate.DTOs.UserDTOs;
using AspFirstTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        //public AccountController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _context = appDbContext;
             _userManager = userManager;
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
        public async Task<IActionResult> Register(CreateUserDto UserDto)
        {
           

            AppUser user = new AppUser();

            user.FirstName = UserDto.FirstName;
            user.LastName = UserDto.LastName;
            user.Email = UserDto.Email;
            user.UserName = UserDto.Username;

            var result = await _userManager.CreateAsync(user, UserDto.Password);

            if (!result.Succeeded) {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

                return View(UserDto);

            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
