using Microsoft.EntityFrameworkCore;

namespace RentFraudDetector.Data;

public class RentFraudDetectorDbContext : DbContext
{
    public RentFraudDetectorDbContext(DbContextOptions<RentFraudDetectorDbContext> options)
        : base(options)
    { }
}