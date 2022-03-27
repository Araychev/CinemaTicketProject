using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class CompanyService : Repository<Company>, ICompanyService
    {
        private ApplicationDbContext _db;

        public CompanyService(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
