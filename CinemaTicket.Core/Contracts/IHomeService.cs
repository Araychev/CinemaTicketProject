using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Contracts
{
    public interface IHomeService
    {
        IEnumerable<Ticket> TicketList();

        ShoppingCart ShoppingCart(int ticketId);

        ShoppingCart CartFromDb(ShoppingCart? shoppingCart, Claim claim);

        void AddShoppingCart(ShoppingCart shoppingCart);

        int ShoppingCartCount(Claim claim);
    }
}
