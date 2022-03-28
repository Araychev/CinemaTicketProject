using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
