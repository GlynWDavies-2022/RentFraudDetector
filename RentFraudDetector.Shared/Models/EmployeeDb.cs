using System.ComponentModel.DataAnnotations;

namespace RentFraudDetector.Shared.Models;

public class EmployeeDb : IEquatable<EmployeeDb>
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

    public bool Equals(EmployeeDb? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CompanyDbId == other.CompanyDbId && Equals(StaffNumber, other.StaffNumber) &&
               Equals(FirstName, other.FirstName) && Equals(Surname, other.Surname) &&
               Equals(SortCode, other.SortCode) && Equals(AccountNumber, other.AccountNumber) &&
               Equals(RollNumber, other.RollNumber);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EmployeeDb)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CompanyDbId, StaffNumber, FirstName, Surname, SortCode, AccountNumber, RollNumber);
    }
}