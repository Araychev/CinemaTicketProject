

namespace CinemaTicket.Core.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryService Category { get; }
        void Save();
    }
}
