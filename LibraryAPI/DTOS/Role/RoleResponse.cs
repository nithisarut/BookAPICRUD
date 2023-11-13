using Library.Models;

namespace LibraryAPI
{
    public class RoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        static public RoleResponse FromRole(Role role)
        {

            return new RoleResponse
            { RoleId = role.RoleId, RoleName = role.RoleName };
            
        }
    }
}
