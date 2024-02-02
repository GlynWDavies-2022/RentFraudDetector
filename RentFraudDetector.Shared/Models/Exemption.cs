using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentFraudDetector.Shared.Models;

public class Exemption : BaseModel,IEquatable<Exemption>
{
    public int ProviderId { get; init; }
    public Provider? Provider { get; init; }
    public string? SortCode { get; init; }
    public string? AccountNumber { get; init; }
    public string? RollNumber { get; init; }
    public string? Name { get; init; }
    public string? Reference { get; init; }
    public int ExemptionReasonId { get; init; }
    public ExemptionReason? ExemptionReason { get; init; }
    [ForeignKey("Authorizer")]
    public int AuthorizerId { get; init; }
    public Employee? Authorizer { get; init; }
    public DateTime DateAuthorized { get; init; } = DateTime.UtcNow;

    public bool Equals(Exemption? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ProviderId == other.ProviderId && SortCode == other.SortCode && AccountNumber == other.AccountNumber &&
               RollNumber == other.RollNumber && Name == other.Name && Reference == other.Reference &&
               ExemptionReasonId == other.ExemptionReasonId;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Exemption)obj);
    }
    
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Id: {Id}");
        builder.AppendLine($"Provider: {Provider!.Name}");
        builder.AppendLine($"Sort Code: {SortCode}");
        builder.AppendLine($"Account Number: {AccountNumber}");
        builder.AppendLine($"Roll Number: {RollNumber ?? "0"}");
        builder.AppendLine($"Name: {Name}");
        builder.AppendLine($"Reference: {Reference}");
        builder.AppendLine($"Exemption Reason: {ExemptionReason!.Description}");
        builder.AppendLine($"Authorizer: {Authorizer!.FirstName} {Authorizer!.Surname}");
        builder.AppendLine($"Date Authorized: {DateAuthorized}");
        return builder.ToString();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProviderId, SortCode, AccountNumber, RollNumber, Name, Reference, ExemptionReasonId);
    }
}