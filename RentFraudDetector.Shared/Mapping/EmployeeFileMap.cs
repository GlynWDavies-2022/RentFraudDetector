using CsvHelper.Configuration;
using RentFraudDetector.Shared.Domain;

namespace RentFraudDetector.Shared.Mapping;

public sealed class EmployeeFileMap : ClassMap<Employee>
{
    public EmployeeFileMap()
    {
        Map(e => e.CompanyName).Name("CompanyName");
        Map(e => e.StaffNumber).Name("StaffNumber");
        Map(e => e.FirstName).Name("FirstName");
        Map(e => e.Surname).Name("Surname");
        Map(e => e.SortCode).Name("SortCode");
        Map(e => e.BranchName).Name("BranchName");
        Map(e => e.AccountNumber).Name("AccountNumber");
        Map(e => e.AccountName).Name("AccountName");
        Map(e => e.RollNumber).Name("RollNumber");
    }
}