
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class TicketService : Repository<Ticket>,ITicketService
    {
        private ApplicationDbContext _db;
        public TicketService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Ticket obj)
        {
            var objFromDb = _db.Tickets.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb == null)
            {
                objFromDb.TitleOfMovie = obj.TitleOfMovie;
                objFromDb.Actors = obj.Actors;
                objFromDb.Category = obj.Category;
                objFromDb.Genre = obj.Genre;
                objFromDb.Country = obj.Country;
                objFromDb.Description = obj.Description;
                objFromDb.Director = obj.Director;
                objFromDb.OriginalLanguage = obj.OriginalLanguage;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price10 = obj.Price10;
                objFromDb.Price20 = obj.Price20;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl= obj.ImageUrl;
                }
            }
            
        }
    }
}
