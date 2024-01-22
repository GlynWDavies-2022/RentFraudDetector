using Microsoft.EntityFrameworkCore;
using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Data;

public class RentFraudDetectorDbContext : DbContext
{
    public DbSet<Company>? Companies { get; init; }
    
    public RentFraudDetectorDbContext(DbContextOptions<RentFraudDetectorDbContext> options)
        : base(options)
    {
    }
}