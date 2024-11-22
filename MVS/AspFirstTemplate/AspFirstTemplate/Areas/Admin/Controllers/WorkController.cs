using AspFirstTemplate.Data;
using AspFirstTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {

        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Work> works = _context.Works.ToList();
            return View(works);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Sjsjsjsj");
            }

            _context.Works.Add(work);   
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }


        public IActionResult Edit(int id) 
        { 
            return View();
        }

        public IActionResult Delete(int id) 
        { 
            Work? work = _context.Works.Find(id);
           
            _context.Works.Remove(work);
            _context.SaveChanges();
            
           


            return RedirectToAction(nameof(Index));
        }
    }
}
