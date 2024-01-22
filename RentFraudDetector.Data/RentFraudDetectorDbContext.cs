using Microsoft.EntityFrameworkCore;
using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Data;

public class RentFraudDetectorDbContext : DbContext
{
    public DbSet<Company>? Companies { get; init; }
    
    public RentFraudDetectorDbContext(DbContextOptions<RentFraudDetectorDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }
}