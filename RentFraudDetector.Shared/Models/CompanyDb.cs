using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class CompanyDb
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    
}