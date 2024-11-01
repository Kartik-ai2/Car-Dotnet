namespace Entities.DbSet
{
    public  class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }    
        public string Description { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
