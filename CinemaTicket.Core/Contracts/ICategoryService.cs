
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface ICategoryService : IRepository<Category>
    {
        void Update(Category obj);
    }
}
