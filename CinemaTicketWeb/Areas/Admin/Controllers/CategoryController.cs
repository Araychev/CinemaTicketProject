using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            
            return View(categoryService.GetAllCategories());
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
            if (categoryService.IfCategoryExit(obj))
            {
                ModelState.AddModelError("name", "This category name exist!");
            }
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                
                categoryService.AddCategory(obj);

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

            var categoryFromDb = categoryService.GetCategory(id);
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
            //if (categoryService.IfCategoryExit(obj))
            //{
            //    ModelState.AddModelError("name", "This category name exist!");
            //}
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
               categoryService.UpdateCategory(obj);

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

            var categoryFromDb = categoryService.GetCategory(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {


            var obj = categoryService.GetCategory(id);
            if (obj == null)
            {
                return NotFound();
            }
                categoryService.DeleteCategory(obj);
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            
        }
    }
}
