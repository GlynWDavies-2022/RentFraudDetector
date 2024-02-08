using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class EmployeeDb
{
    [Key]
    public int Id { get; init; }
    public int CompanyDbId { get; init; }
    public CompanyDb? Company { get; init; }
    [MaxLength(10)]
    public string? StaffNumber { get; init; }
    [MaxLength(50)]
    public string? FirstName { get; init; }
    [MaxLength(50)]
    public string? Surname { get; init; }
    [MaxLength(6)]
    public string? SortCode { get; init; }
    [MaxLength(50)]
    public string? BranchName { get; init; }
    [MaxLength(8)]
    public string? AccountNumber { get; init; }
    [MaxLength(50)]
    public string? AccountName { get; init; }
    [MaxLength(16)]
    public string? RollNumber { get; init; }
}