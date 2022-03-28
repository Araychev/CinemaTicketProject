using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
