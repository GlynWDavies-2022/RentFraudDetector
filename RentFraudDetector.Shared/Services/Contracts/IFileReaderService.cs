using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Shared.Services.Contracts;

public interface IFileReaderService
{
    public IEnumerable<Employee> ReadEmployees();
}