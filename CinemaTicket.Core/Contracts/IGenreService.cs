using CinemaTicket.Models;



namespace CinemaTicket.Core.Contracts
{
    public interface IGenreService
    {
        void AddGenre(Genre obj);

        IEnumerable<Genre> GetAllGenres();

        bool IfGenreExit(Genre model);
        Genre GetGenre(int? id);

        void UpdateGenre(Genre obj);

        void DeleteGenre(Genre model);
    }
}
