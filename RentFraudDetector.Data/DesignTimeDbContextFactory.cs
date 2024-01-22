using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RentFraudDetector.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentFraudDetectorDbContext>
{
    public RentFraudDetectorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentFraudDetectorDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=RentFraudDetector;Trusted_Connection=True;TrustServerCertificate=true");

        return new RentFraudDetectorDbContext(optionsBuilder.Options);
    }
}