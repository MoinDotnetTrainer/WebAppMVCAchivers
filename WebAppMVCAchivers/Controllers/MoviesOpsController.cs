using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;

namespace WebAppMVCAchivers.Controllers
{
    public class MoviesOpsController : Controller
    {
        private readonly IMovies _Imovies;
        public MoviesOpsController(IMovies movies)
        {
            _Imovies = movies;
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie(Movies data)
        {
            await _Imovies.AddMovies(data);
            return View();
        }
    }
}
