using System.Text;

namespace RentFraudDetector.Shared.Models;

public class ExemptionReason : BaseModel,IEquatable<ExemptionReason>
{
    public string? Description { get; init; }

    public bool Equals(ExemptionReason? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Description == other.Description;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ExemptionReason)obj);
    }

    public override int GetHashCode()
    {
        return (Description != null ? Description.GetHashCode() : 0);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Id: {Id}");
        builder.AppendLine($"Description: {Description}");
        return builder.ToString();
    }
}