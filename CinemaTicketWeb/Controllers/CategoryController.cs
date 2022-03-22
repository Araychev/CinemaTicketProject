using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Controllers
{
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
        public IActionResult Edit(Guid? id)
        {

            if (id == null )
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
        public IActionResult Delete(Guid? id)
        {
            
           
            if (id == null )
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
        public IActionResult DeletePost(Guid? id)
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
