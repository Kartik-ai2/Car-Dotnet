using Entities.Dbset;

namespace Entities.DbSet
{
    public class UsersRoles
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Roles Roles { get; set; }    
    }
}
