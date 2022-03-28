using CinemaTicket.Core.Constants;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _db;

        public GenreController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> ganre = _db.Genre.GetAll();
            return View(ganre);
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
            if (_db.Genre.GetAll().Any(x=>x.Name == obj.Name))
            {
                ModelState.AddModelError("name", "This genre name exist!");
            }
            if (ModelState.IsValid)
            {
                _db.Genre.Add(obj);
                _db.Save();

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
            var genreFromDb = _db.Genre.GetFirstOrDefault(u=>u.Id==id);;
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
                _db.Genre.Update(obj);
                _db.Save();

                TempData["success"] = "Genre updated successfully";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            
           
            if (id is null or 0 )
            {
                return NotFound();
            }

            var genreFromDb = _db.Genre.GetFirstOrDefault(u=>u.Id==id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {


            var obj = _db.Genre.GetFirstOrDefault(u=>u.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Genre.Remove(obj);
                _db.Save();
                TempData["success"] = "Genre deleted successfully";
                return RedirectToAction("Index");
            
        }
    }
}
