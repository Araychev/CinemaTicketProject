
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class GenreService : Repository<Genre>, IGenreService
    {
        private ApplicationDbContext _db;
        public GenreService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Genre obj)
        {
            _db.Genres.Update(obj);
        }
    }
}
