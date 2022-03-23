

namespace CinemaTicket.Core.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryService Category { get; }
        IGenreService Genre { get; }
        void Save();
    }
}
