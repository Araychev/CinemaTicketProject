
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface ITicketService : IRepository<Ticket>
    {
        void Update(Ticket obj);
    }
}
