using CinemaTicket.Core.Contracts;
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
        private readonly ITicketService ticketService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TicketController(ITicketService _ticketService, IWebHostEnvironment hostEnvironment)
        {
            ticketService = _ticketService;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }



        //Get
        public IActionResult Upsert(int? id)
        {
            var ticketVM = ticketService.GetTicketVM();

            if (id is null or 0)
            {
                //create ticket
                //ViewBag.CategoryList = CategoryList;
                //ViewData["GenreList"] = GenreList;
                return View(ticketVM);
            }
            else
            {
                //update ticket
                ticketVM.Ticket = ticketService.GetTicketFirst(id);
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
                   ticketService.AddTicket(obj,file);
                }
                else
                {
                    ticketService.UpdateTicket(obj,file);
                }


                ticketService.SaveTicket();

                TempData["success"] = "Ticket added successfully";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Json(new { data = ticketService.GetAll() });


        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = ticketService.GetTicketFirst(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

          ticketService.DeleteTicket(obj);
            ticketService.SaveTicket();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion


    }
}
