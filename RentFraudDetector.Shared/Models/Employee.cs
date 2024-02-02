using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class Employee : BaseModel
{
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    [MaxLength(10)]
    public string? EmployeeNumber { get; set; }
    [MaxLength(50)]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    public string? Surname { get; set; }
    [MaxLength(6)]
    public string? SortCode { get; set; }
    [MaxLength(50)]
    public string? BranchName { get; set; }
    [MaxLength(8)]
    public string? AccountNumber { get; set; }
    [MaxLength(50)]
    public string? AccountName { get; set; }
    [MaxLength(16)]
    public string? RollNumber { get; set; }
}