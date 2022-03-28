using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    public class TicketRepository : Repository<Ticket>,ITicketRepository
    {
        private ApplicationDbContext _db;
        public TicketRepository(ApplicationDbContext db) : base(db)
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
