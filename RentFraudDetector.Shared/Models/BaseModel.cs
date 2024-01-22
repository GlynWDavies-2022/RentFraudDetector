using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class BaseModel
{
    [Key]
    public int Id { get; init; }

    public DateTime DateCreated { get; init; } = DateTime.UtcNow;

    public DateTime DateUpdated { get; init; } = DateTime.UtcNow;
}