using Microsoft.EntityFrameworkCore;
using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Data;

public class RentFraudDetectorDbContext : DbContext
{
    public DbSet<Company>? Companies { get; init; }
    public DbSet<ExemptionReason>? ExemptionReasons { get; init; }
    public DbSet<Provider>? Providers { get; init; }
    
    public RentFraudDetectorDbContext(DbContextOptions<RentFraudDetectorDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ----------------------------------------------------------------------------------------
        // Company
        // ----------------------------------------------------------------------------------------
        
        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Conway"
            },
            new Company {
                Id = 2,
                Name = "Countryside"
            }
        );
        
        // ----------------------------------------------------------------------------------------
        // ExemptionReason
        // ----------------------------------------------------------------------------------------

        modelBuilder.Entity<ExemptionReason>().HasData(
            new ExemptionReason
            {
                Id = 1,
                Description = "Employee Rental Income"
            }
        );
        
        // ----------------------------------------------------------------------------------------
        // Provider
        // ----------------------------------------------------------------------------------------

        modelBuilder.Entity<Provider>().HasData(
            new Provider
            {
                Id = 1,
                Name = "ARC-Colchester"
            },
            new Provider
            {
                Id = 2,
                Name = "ARC-Weymouth"
            },
            new Provider
            {
                Id = 3,
                Name = "Hamcrest"
            },
            new Provider
            {
                Id = 4,
                Name = "LosersWeepers"
            }
        );
    }
}