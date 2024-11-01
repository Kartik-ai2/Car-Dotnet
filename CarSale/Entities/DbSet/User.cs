using Entities.DbSet;

namespace Entities.Dbset
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string MobileNumber { get; set; }
        public bool IsDelete { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<UsersRoles> UserRoles { get; set; }
    }

}
