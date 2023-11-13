using Library.Models;

namespace LibraryAPI
{
    public class AccountResponse
    {

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }


       
        static public AccountResponse FromAccount(Account account)
        {
            // return ตัวมันเอง
            return new AccountResponse
            {
                AccountId = account.AccountId, 
                Name = account.Name, 
                Email = account.Email,
                Password = account.Password,
                
                RoleId = account.Role.RoleId,
                RoleName = account.Role.RoleName
            };
        }
    }
}
