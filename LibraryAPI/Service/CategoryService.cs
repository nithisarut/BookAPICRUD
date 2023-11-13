using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Library.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext dataContext;

        public CategoryService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Create(Category category)
        {
            dataContext.Category.AddAsync(category);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            dataContext.Remove(category);
            await dataContext.SaveChangesAsync();
        }

     

        public async Task<ICollection<Category>> GetAll()
        {
            var data = await dataContext.Category.ToListAsync();
            return data;
        }

    

        public async Task<Category> GetById(int id)
        {
            var result = await dataContext.Category.FirstAsync(x => x.CategoryId.Equals(id));
            return result;
        }

        public async Task Update(Category category)
        {
            dataContext.Category.Update(category);
            await dataContext.SaveChangesAsync();
        }
    }
}
