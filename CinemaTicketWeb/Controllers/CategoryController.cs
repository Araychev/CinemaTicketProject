using CinemaTicketWeb.Data;
using CinemaTicketWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
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
            if (_db.Categories.Any(x=>x.Name == obj.Name))
            {
                ModelState.AddModelError("name", "This category name exist!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();

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

            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
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
            if (_db.Categories.Any(x=>x.Name == obj.Name))
            {
                ModelState.AddModelError("name", "This category name exist!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();

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

            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
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


            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(categoryFromDb);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            
        }
    }
}
