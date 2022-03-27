
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class ApplicationUserService : Repository<ApplicationUser>, IApplicationUserService
    {
        private ApplicationDbContext _db;

        public ApplicationUserService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
