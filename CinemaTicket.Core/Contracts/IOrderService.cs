using System.Security.Claims;
using CinemaTicket.Models;
using CinemaTicket.Models.ViewModels;
using Stripe.Checkout;


namespace CinemaTicket.Core.Contracts
{
    public interface IOrderService
    {
        OrderVM OrderDetail(int orderId);

        OrderHeader OrderHeader();

        IEnumerable<OrderDetail> OrderDetails();

        IEnumerable<OrderHeader> OrderHeadersAdminOrEmploye();
        IEnumerable<OrderHeader> OrderHeadersUser(Claim claim);

        Session StripePayNow();

        void ConfirmPayment(int orderHeaderid);

        int UpdateOrderDetail();

        void StartProcessing();

        void ShipOrder();

        void CancelOrder();
    }
}
