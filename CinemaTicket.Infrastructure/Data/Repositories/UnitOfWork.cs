using CinemaTicket.Infrastructure.Data.Repositories.IRepository;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
      private  ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Genre = new GenreRepository(_context);
            Ticket = new TicketRepository(_context);
            Company=new CompanyRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
        }
        public ICategoryRepository Category { get; private set; }
        public IGenreRepository Genre { get; private set; }

        public ITicketRepository Ticket { get; private set; }
        public ICompanyRepository Company { get; private set;}

        public IShoppingCartRepository ShoppingCart {  get; private set; }

        public IApplicationUserRepository ApplicationUser {  get; private set; }
        public IOrderHeaderRepository OrderHeader {  get; private set; }
        public IOrderDetailRepository OrderDetail {  get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
