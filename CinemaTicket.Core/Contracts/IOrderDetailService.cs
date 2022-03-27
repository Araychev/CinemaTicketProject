using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface IOrderDetailService : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
}
