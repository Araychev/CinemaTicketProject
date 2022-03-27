
using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.Common;
using CinemaTicket.Models;

namespace CinemaTicket.Core.Services
{
    public class ShoppingCartService : Repository<ShoppingCart>, IShoppingCartService
    {
        private ApplicationDbContext _db;

        public ShoppingCartService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
