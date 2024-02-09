using System.Collections;

namespace RentFraudDetector.Shared.Services.Contracts;

public interface IEncryptionService<T,U>
{
    public IEnumerable<T> Encrypt(IEnumerable<U> entities, byte[] key, byte[] iv);

    public IEnumerable<U> Decrypt(IEnumerable<T> entities);
}