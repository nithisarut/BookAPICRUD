using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOS.Role
{
    public class RoleRequest
    {
        public int? RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
