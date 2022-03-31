using CinemaTicket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Authorization;

namespace CinemaTicketWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
        public IActionResult Upsert(int? id)
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

            if (id is null or 0)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["GenreList"] = GenreList;
                return View(ticketVM);
            }
            else
            {
                ticketVM.Ticket = _db.Ticket.GetFirstOrDefault(t => t.Id == id);
                return View(ticketVM);
            }


        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TicketVM obj, IFormFile? file)
        {


            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\tickets");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Ticket.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj
                            .Ticket.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.Ticket.ImageUrl = @"\images\tickets\" + fileName + extention;

                }

                if (obj.Ticket.Id == 0)
                {
                    _db.Ticket.Add(obj.Ticket);
                }
                else
                {
                    _db.Ticket.Update(obj.Ticket);
                }


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
            var ticketList = _db.Ticket.GetAll(includeProperties: "Category,Genre");
            return Json(new { data = ticketList });


        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Ticket.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _db.Ticket.Remove(obj);
            _db.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion


    }
}
