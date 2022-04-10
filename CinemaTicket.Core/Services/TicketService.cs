using System.Globalization;
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;
using CinemaTicket.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaTicket.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TicketService(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }


        public TicketVM GetTicketVM()
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

            return ticketVM;
        }

        public Ticket GetTicketFirst(int? id) => _db.Ticket.GetFirstOrDefault(t => t.Id == id);
        public void AddTicket(TicketVM obj, IFormFile? file)
        {
            _db.Ticket.Add(obj.Ticket);
        }

        public void UpdateTicket(TicketVM obj, IFormFile? file)
        {
            _db.Ticket.Update(obj.Ticket);
        }

        public void SaveTicket()
        {
            _db.Save();
        }

        public void DeleteTicket(Ticket obj)
        {
            _db.Ticket.Remove(obj);
        }

        public IEnumerable<Ticket> GetAll() => _db.Ticket.GetAll(includeProperties: "Category,Genre");
    }
}
