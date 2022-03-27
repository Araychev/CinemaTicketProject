using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface IApplicationUserService : IRepository<ApplicationUser>
    {
    }
}
