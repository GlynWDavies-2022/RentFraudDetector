using RentFraudDetector.Shared.Domain;

namespace RentFraudDetector.Shared.Services.Contracts;

public interface IFileReaderService
{
    public IEnumerable<Employee> ReadEmployees();
}