using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Library.Service
{
    public class AccountService : IAccountService
    {
        public readonly DataContext DataContext;
        public AccountService(DataContext DataContext)
        {
            this.DataContext = DataContext;
        }

        public async Task<ICollection<Account>> GetAll()
        {
            var data = await DataContext.Account.Include(e => e.Role).ToListAsync();
            return data;
        }

        public async Task Register(Account account)
        {
            var result = await DataContext.Account.AsNoTracking().FirstOrDefaultAsync(e => e.Email == account.Email);
            if (result != null) throw new Exception("Existing account");
          
            
            await DataContext.Account.AddAsync(account);
            await DataContext.SaveChangesAsync();
        }

      

    }
}
