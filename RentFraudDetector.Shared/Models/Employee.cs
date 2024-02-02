using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentFraudDetector.Shared.Models;

public class Employee : BaseModel, IEquatable<Employee>
{
    public bool Equals(Employee? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(Company, other.Company) && EmployeeNumber == other.EmployeeNumber &&
               FirstName == other.FirstName && Surname == other.Surname && SortCode == other.SortCode &&
               AccountNumber == other.AccountNumber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Company, EmployeeNumber, FirstName, Surname, SortCode, AccountNumber);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Id: {Id}");
        builder.AppendLine($"Company: {Company!.Name}");
        builder.AppendLine($"Employee Number: {EmployeeNumber}");
        builder.AppendLine($"First Name: {FirstName}");
        builder.AppendLine($"Surname: {Surname}");
        builder.AppendLine($"Sort Code: {SortCode}");
        builder.AppendLine($"Branch Name: {BranchName}");
        builder.AppendLine($"Account Number: {AccountNumber}");
        builder.AppendLine($"Account Name: {AccountName}");
        builder.AppendLine($"Roll Number: {RollNumber ?? "0"}");
        return builder.ToString();
    }

    public int CompanyId { get; init; }
    public Company? Company { get; init; }
    [MaxLength(10)]
    public string? EmployeeNumber { get; init; }
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