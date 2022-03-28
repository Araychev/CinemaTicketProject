using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
