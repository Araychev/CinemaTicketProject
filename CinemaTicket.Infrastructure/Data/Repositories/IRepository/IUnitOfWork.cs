

namespace CinemaTicket.Infrastructure.Data.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IGenreRepository Genre { get; }

        ITicketRepository Ticket { get; }

        ICompanyRepository Company { get; }

        IShoppingCartRepository ShoppingCart {  get; }
        IApplicationUserRepository ApplicationUser {  get; }
        IOrderDetailRepository OrderDetail {  get; }
        IOrderHeaderRepository OrderHeader {  get; }
        void Save();
    }
}
