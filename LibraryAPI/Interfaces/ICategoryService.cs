
using Library.Models;

namespace LibraryAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);


       
    }
}
