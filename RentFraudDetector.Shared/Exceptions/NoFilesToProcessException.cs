namespace RentFraudDetector.Shared.Exceptions;

public class NoFilesToProcessException : Exception
{
    public NoFilesToProcessException() { }

    public NoFilesToProcessException(string message) : base(message) { }

    public NoFilesToProcessException(string message, Exception innerException) : base(message, innerException) { }
}