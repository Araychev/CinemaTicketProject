using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;


namespace CinemaTicket.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _db;

        public GenreService(IUnitOfWork db)
        {
            _db = db;
        }
        public void AddGenre(Genre obj)
        {
            _db.Genre.Add(obj);
            _db.Save();
        }

       

        public void DeleteGenre(Genre model)
        {
            _db.Genre.Remove(model);
            _db.Save();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _db.Genre.GetAll();
        }

        public Genre GetGenre(int? id) => _db.Genre.GetFirstOrDefault(u => u.Id == id);

        public bool IfGenreExit(Genre model)
        {
            if (_db.Genre.GetAll().Any(x => x.Name == model.Name))
            {

                return true;
            }
            return false;
        }

        public void UpdateGenre(Genre obj)
        {
            _db.Genre.Update(obj);
            _db.Save();
        }
    }
}
