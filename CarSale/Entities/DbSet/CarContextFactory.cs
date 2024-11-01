using Entities.Dbset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class CarContextFactory : IDesignTimeDbContextFactory<CarContext>
{
    public CarContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarContext>();

        // Provide the connection string here
        
        optionsBuilder.UseSqlServer("Server=KARTIK;Database=Car;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

        return new CarContext(optionsBuilder.Options);
    }
}
