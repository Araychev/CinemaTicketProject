using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Infrastructure.Data.Repositories.IRepository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        void Update(Ticket obj);
    }
}
