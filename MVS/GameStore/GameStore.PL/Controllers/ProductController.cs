using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs.Comment;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore.PL.Controllers
{
    public class ProductController : Controller
    {

        private readonly IService<Game> _gameContext;
        private readonly IService<Comment> _commentContext;

        public ProductController(IService<Game> gameContext, IService<Comment> commentContext)
        {
            _gameContext = gameContext;
            _commentContext = commentContext;
        }

        public async Task<IActionResult> Index()
        {
            var games =await _gameContext.GetAllAsync();
            return View(games);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Product = await _gameContext.GetByIdAsync(id);
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDto commentDto, int Id)
        {


            Comment comment = new Comment()
            {
                CommentMessage = commentDto.CommentMessage,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                ProductId = Id
            };


            await _commentContext.AddAsync(comment);
            ViewBag.Product = await _gameContext.GetByIdAsync(Id);
            return RedirectToAction(nameof(Detail));
        }
    }
}
