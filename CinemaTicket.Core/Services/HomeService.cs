using System.Security.Claims;
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class HomeService : IHomeService
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Ticket> TicketList() => _unitOfWork.Ticket.GetAll(includeProperties: "Category,Genre");
        public ShoppingCart ShoppingCart(int ticketId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                TicketId = ticketId,
                Ticket = _unitOfWork.Ticket.GetFirstOrDefault(u => u.Id == ticketId,
                    includeProperties: "Category,Genre"),
            };

            return cartObj;
        }

        public ShoppingCart CartFromDb(ShoppingCart? shoppingCart, Claim claim)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                u => shoppingCart != null && u.ApplicationUserId == claim.Value && u.TicketId == shoppingCart.TicketId);

            return cartFromDb;
        }

        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
        }

        public int ShoppingCartCount(Claim claim)
        {
            var count = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;

           return count;
        }
    }
}
