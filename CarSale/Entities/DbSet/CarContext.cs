using Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace Entities.Dbset
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
           : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<UsersRoles> UsersRoles { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseSqlServer("Server=KARTIK;Database=Car;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
         }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(key => key.UserId).HasName("PK_UN");
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.ToTable("UsersRoles");
                entity.HasKey(key => new { key.RoleId, key.UserId }).HasName("PK_COMPOSITE_ROLEID_UserId");
                entity.HasOne(prop => prop.User).WithMany(prop => prop.UserRoles).HasForeignKey(prop => prop.UserId);
                entity.HasOne(prop => prop.Roles).WithMany(prop => prop.UsersRoles).HasForeignKey(prop => prop.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(key => key.RoleId).HasName("PK_RoleId");
            });
        }
    }
}
