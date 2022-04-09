using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;


namespace CinemaTicket.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _db;
       

        public CategoryService(IUnitOfWork db)
        {
            _db = db;
            
        }
        public void AddCategory(Category model)
        {
                _db.Category.Add(model);
                _db.Save(); 
        }

        public IEnumerable<Category> GetAllCategories() => _db.Category.GetAll();

           
        

        public Category GetCategory(int? id)=>_db.Category.GetFirstOrDefault(u => u.Id == id); 
            
        

        public bool IfCategoryExit(Category model) 
        {
            if (_db.Category.GetAll().Any(x => x.Name == model.Name))
            {
                
                return true;
            }
            return false;
           
        }

        public void UpdateCategory(Category model)
        {
            _db.Category.Update(model);
            _db.Save();
        }
        
        public void DeleteCategory(Category model)
        {
            _db.Category.Remove(model);
            _db.Save();
        }
    }
}
