using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using CinemaTicket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TicketController(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
           
            return View();
        }



        //Get
        public IActionResult Upsert(Guid? id)
        {
            TicketVM ticketVM = new()
            {
                Ticket = new(),
                CategoryList = _db.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                GenreList = _db.Genre.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })

            };

            if (id == null)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["GenreList"] = GenreList;
                return View(ticketVM);
            }
            else
            {

            }

            return View(ticketVM);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TicketVM obj, IFormFile file)
        {


            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\tickets");
                    var extention = Path.GetExtension(file.FileName);
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.Ticket.ImageUrl = @"\images\tickets" + fileName + extention;

                }
                 _db.Ticket.Add(obj.Ticket);
                _db.Save();

                TempData["success"] = "Ticket added successfully";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var ticketList = _db.Ticket.GetAll();
            return Json(new { data = ticketList });
        }

        #endregion


    }
}
