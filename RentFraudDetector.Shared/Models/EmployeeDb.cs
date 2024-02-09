using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class EmployeeDb
{
    [Key]
    public int Id { get; init; }
    public int CompanyDbId { get; init; }
    public byte[]? StaffNumber { get; init; }
    public byte[]? FirstName { get; init; }
    public byte[]? Surname { get; init; }
    public byte[]? SortCode { get; init; }
    public byte[]? BranchName { get; init; }
    public byte[]? AccountNumber { get; init; }
    public byte[]? AccountName { get; init; }
    public byte[]? RollNumber { get; init; }
    public byte[]? Key { get; init; }
    public byte[]? Vector { get; init; }
}