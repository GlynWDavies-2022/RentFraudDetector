using RentFraudDetector.Shared.Models;

namespace RentFraudDetector.Shared.Services.Contracts;

public interface IRepository<T>
{
    public IEnumerable<T> Read();
    public void Write(IEnumerable<EmployeeDb> newEmployeesEncrypted);
}