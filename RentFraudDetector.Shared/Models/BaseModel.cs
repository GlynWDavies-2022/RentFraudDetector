using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class BaseModel
{
    [Key]
    public int Id { get; init; }
}