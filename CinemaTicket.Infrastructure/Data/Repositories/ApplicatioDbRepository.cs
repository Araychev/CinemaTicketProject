
using CinemaTicket.Infrastructure.Data.Common;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    internal class ApplicatioDbRepository<T>: Repository<T> where T : class, IApplicatioDbRepository<T>
    {
        public ApplicatioDbRepository(ApplicationDbContext db) : base(db)
        {
           
        }
    }
}
