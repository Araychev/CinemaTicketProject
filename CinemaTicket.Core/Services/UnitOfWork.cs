
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;

namespace CinemaTicket.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryService(_context);
        }
        public ICategoryService Category { get; private set; }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
