
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface IGenreService : IRepository<Genre>
    {
        void Update(Genre obj);
    }
}
