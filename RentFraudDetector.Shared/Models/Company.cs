﻿using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentFraudDetector.Shared.Models;

public class Company : BaseModel, IEquatable<Company>
{
    public bool Equals(Company? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Company)obj);
    }

    public override int GetHashCode()
    {
        return (Name != null ? Name.GetHashCode() : 0);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Id: {Id}");
        builder.AppendLine($"Name: {Name}");
        return builder.ToString();
    }

    [MaxLength(50)]
    public string? Name { get; init; }
    public ICollection<Employee>? Employees { get; init; }
}