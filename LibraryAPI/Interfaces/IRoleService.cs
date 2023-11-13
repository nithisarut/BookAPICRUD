using Library.Models;

namespace LibraryAPI.Interfaces
{
    public interface IRoleService
    {
        Task<ICollection<Role>> GetAll();
        Task<Role> GetById(int id);
        Task Create(Role role);
        Task Update(Role role);
        Task Delete(Role role);
    }
}
