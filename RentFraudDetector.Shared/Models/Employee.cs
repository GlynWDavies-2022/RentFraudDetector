namespace RentFraudDetector.Shared.Models;

public class Employee : IEquatable<Employee>
{
    public string? CompanyName { get; init; }
    public string? StaffNumber { get; init; }
    public string? FirstName { get; init; }
    public string? Surname { get; init; }
    public string? SortCode { get; init; }
    public string? BranchName { get; init; }
    public string? AccountNumber { get; init; }
    public string? AccountName { get; init; }
    public string? RollNumber { get; init; }

    public bool Equals(Employee? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CompanyName == other.CompanyName && StaffNumber == other.StaffNumber && FirstName == other.FirstName &&
               Surname == other.Surname && SortCode == other.SortCode && AccountNumber == other.AccountNumber &&
               RollNumber == other.RollNumber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CompanyName, StaffNumber, FirstName, Surname, SortCode, AccountNumber, RollNumber);
    }
}