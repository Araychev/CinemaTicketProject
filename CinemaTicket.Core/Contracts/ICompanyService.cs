using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface ICompanyService : IRepository<Company>
    {
        void Update(Company obj);
    }
}
