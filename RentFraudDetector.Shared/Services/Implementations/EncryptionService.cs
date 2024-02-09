using RentFraudDetector.Shared.Models;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Shared.Services.Implementations;

public class EncryptionService : IEncryptionService<EmployeeDb,Employee>
{
    public IEnumerable<EmployeeDb> Encrypt(IEnumerable<Employee> entities, byte[] key, byte[] iv)
    {
        // Todo...

        return null!;
    }
}