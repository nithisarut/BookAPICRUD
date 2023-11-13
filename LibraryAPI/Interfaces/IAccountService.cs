using Library.Models;

namespace LibraryAPI.Interfaces
{
    public interface IAccountService
    {
        Task<ICollection<Account>> GetAll();
        Task Register(Account account);
    }
}
