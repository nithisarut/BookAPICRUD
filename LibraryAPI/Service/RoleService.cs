using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class RoleService : IRoleService
    {
        private readonly DataContext dataContext;

        public RoleService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Create(Role role)
        {
           dataContext.Roles.AddAsync(role);
           await dataContext.SaveChangesAsync();
        }

        public async Task Delete(Role role)
        {
            dataContext.Remove(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Role>> GetAll()
        {
            var data = await dataContext.Roles.ToListAsync();
            return data;
        }

        public async Task<Role> GetById(int id)
        {
            var result = await dataContext.Roles.FirstAsync(x => x.RoleId.Equals(id));
            return result;
        }

        public async Task Update(Role role)
        {
            dataContext.Roles.Update(role);
            await dataContext.SaveChangesAsync();
        }
    }
}
