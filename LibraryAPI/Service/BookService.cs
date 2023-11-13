using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class BookService : IBookService
    {
        public readonly DataContext db;
        private readonly IUploadFileService us;
        public BookService(DataContext databaseContext, IUploadFileService uploadFileService)
        {
            db = databaseContext;
            us = uploadFileService;
        }
        public async Task Create(Book book)
        {
            db.Book.AddAsync(book);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            db.Remove(book);
            await db.SaveChangesAsync();
        }

        public  async Task DeleteImage(string fileName)
        {
            await us.DeleteImage(fileName);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var data = await db.Book.Include(e => e.Category).ToListAsync();
            return data;
        }

        public async Task<Book> GetByID(string id)
        {
            var result = await db.Book.Include(e => e.Category).FirstAsync(x => x.BookId.Equals(id));
            return result;
        }

        public async Task<Book> GetByID(int id)
        {
            var result = await db.Book.Include(e => e.Category).FirstAsync(x => x.BookId.Equals(id));
            return result;
        }

        public async Task<IEnumerable<Book>> Search(string name)
        {
            var data = await db.Book.Where(p => p.Name.Contains(name)).Include(e => e.Category).ToListAsync();
            return data;
        }

        public async Task Update(Book book)
        {
            db.Book.Update(book);
            await db.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var errorMessage = string.Empty;

            var imageName = string.Empty;
            if (us.IsUpload(formFiles))
            {
                errorMessage = us.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    imageName = (await us.UploadImages(formFiles))[0];
                }
            }
            return (errorMessage, imageName);
        }
    }
}
