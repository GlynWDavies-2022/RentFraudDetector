using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class Company : BaseModel
{
    [MaxLength(50)]
    public string? Name { get; init; }
    public ICollection<Employee>? Employees { get; set; }
}