using Microsoft.EntityFrameworkCore;
using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Data;

public class RentFraudDetectorDbContext(DbContextOptions<RentFraudDetectorDbContext> options) : DbContext(options)
{
    public DbSet<CompanyDb> Companies => Set<CompanyDb>();
    public DbSet<EmployeeDb> Employees => Set<EmployeeDb>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyDb>().HasData(
            new CompanyDb { Id = 1, Name = "Conway"},
            new CompanyDb { Id = 2, Name = "Countryside"}
        );
    }
}