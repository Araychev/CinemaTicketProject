using CinemaTicket.Core.Constants;
using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Category.GetAll();
            return View(objCategoryList);
        }
        
        //Get
        public IActionResult Create()
        {
            
            return View();
        } 
        
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (_db.Category.GetAll().Any(x=>x.Name == obj.Name))
            {
                ModelState.AddModelError("name", "This category name exist!");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.Save();

                TempData["success"] = "Category created successfully";

                    return RedirectToAction("Index");
            }


            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {

            if (id is null or 0 )
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.GetFirstOrDefault(u=>u.Id==id);;
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.Save();

                TempData["success"] = "Category updated successfully";
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

            var categoryFromDb = _db.Category.GetFirstOrDefault(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {


            var obj = _db.Category.GetFirstOrDefault(u=>u.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Category.Remove(obj);
                _db.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            
        }
    }
}
