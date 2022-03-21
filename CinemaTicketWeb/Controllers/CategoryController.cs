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

        //Get
        public IActionResult Edit()
        {
            
            return View();
        }


        //Get
        public IActionResult Delete()
        {
            
            return View();
        }
    }
}
