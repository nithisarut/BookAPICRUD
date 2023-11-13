using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOS.Account
{
    public class AccountRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        // ขั้นต่ำ 8 ตัว
        [MinLength(8)]
        public string Password { get; set; }
        public int RoleId { get; set; }

    }
}
