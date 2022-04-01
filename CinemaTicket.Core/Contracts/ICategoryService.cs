using CinemaTicket.Models;


namespace CinemaTicket.Core.Contracts
{
    public interface ICategoryService
    {
        void AddCategory(Category model);

        bool IfCategoryExit(Category model);

        IEnumerable<Category> GetAllCategories();

       Category GetCategory(int? id);

        void UpdateCategory(Category model);
        
        void DeleteCategory(Category model);
    }
}
