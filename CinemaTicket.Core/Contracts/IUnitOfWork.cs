

namespace CinemaTicket.Core.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryService Category { get; }
        IGenreService Genre { get; }

        ITicketService Ticket { get; }

        ICompanyService Company { get; }
        void Save();
    }
}
