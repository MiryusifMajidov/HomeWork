using GameStore.BL.Services.Implementations;
using GameStore.BL.Services.Interfaces;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        

        private readonly IService<Game> _gameContext;

        public GameController(IService<Game> gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameContext.GetAllAsync();
            
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
