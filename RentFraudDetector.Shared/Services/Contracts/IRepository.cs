namespace RentFraudDetector.Shared.Services.Contracts;

public interface IRepository<T>
{
    public IEnumerable<T> Read();
}