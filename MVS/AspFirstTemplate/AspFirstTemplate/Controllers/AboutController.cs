using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
