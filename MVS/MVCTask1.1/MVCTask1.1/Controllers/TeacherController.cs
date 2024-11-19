using Microsoft.AspNetCore.Mvc;
using MVCTask1._1.Data;
using MVCTask1._1.Models;

namespace MVCTask1._1.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            //if (string.IsNullOrEmpty(teacher.Description))
            //{
            //    teacher.Description = "Təsvir yoxdur";
            //}
            //if (string.IsNullOrEmpty(teacher.Name))
            //{
            //    teacher.Name = "test";
            //}
            AppDbContext _context1 = new();

            _context1.Teachers.Add(teacher);
            _context1.SaveChanges();
            
            
            return View(teacher);
        }
    }
}
