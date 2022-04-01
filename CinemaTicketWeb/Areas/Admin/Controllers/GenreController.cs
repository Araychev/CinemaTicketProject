using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService _genreService)
        {
            genreService = _genreService;
        }
        public IActionResult Index()
        {

            return View(genreService.GetAllGenres());
        }

        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre obj)
        {
            if (genreService.IfGenreExit(obj))
            {
                ModelState.AddModelError("name", "This genre name exist!");
            }
            if (ModelState.IsValid)
            {
                genreService.AddGenre(obj);

                TempData["success"] = "Genre created successfully";

                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var genreFromDb = genreService.GetGenre(id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre obj)
        {

            if (ModelState.IsValid)
            {
                genreService.UpdateGenre(obj);

                TempData["success"] = "Genre updated successfully";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {


            if (id is null or 0)
            {
                return NotFound();
            }

            var genreFromDb = genreService.GetGenre(id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {


            var obj = genreService.GetGenre(id);
            if (obj == null)
            {
                return NotFound();
            }
            genreService.DeleteGenre(obj);
            TempData["success"] = "Genre deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
