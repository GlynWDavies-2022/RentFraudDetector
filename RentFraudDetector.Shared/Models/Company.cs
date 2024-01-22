using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class Company
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
}