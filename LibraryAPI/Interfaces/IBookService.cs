using Library.Models;

namespace LibraryAPI.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetByID(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Book book);
        Task<IEnumerable<Book>> Search(string name);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
        Task DeleteImage(string fileName);
    }
}
