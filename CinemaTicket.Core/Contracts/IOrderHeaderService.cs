
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface IOrderHeaderService : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus=null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentItentId);
    }
}
