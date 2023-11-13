using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId {  get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
