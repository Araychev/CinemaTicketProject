using System.Diagnostics;
using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ticket> tickets = _db.Ticket.GetAll(includeProperties:"Category,Genre");
            return View(tickets);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Details(int ticketId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                TicketId = ticketId,
                Ticket = _db.Ticket.GetFirstOrDefault(t => t.Id == ticketId, includeProperties: "Category,Genre"),

            };
            return View(cartObj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}