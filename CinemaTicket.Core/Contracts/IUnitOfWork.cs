

namespace CinemaTicket.Core.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryService Category { get; }
        IGenreService Genre { get; }

        ITicketService Ticket { get; }

        ICompanyService Company { get; }

        IShoppingCartService ShoppingCart {  get; }
        IApplicationUserService ApplicationUser {  get; }
        IOrderDetailService OrderDetail {  get; }
        IOrderHeaderService OrderHeader {  get; }
        void Save();
    }
}
