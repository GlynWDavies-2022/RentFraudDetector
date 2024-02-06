namespace RentFraudDetector.Shared.Exceptions;

public class NoRecordsToProcessException : Exception
{
    public NoRecordsToProcessException() { }

    public NoRecordsToProcessException(string message) : base(message) { }

    public NoRecordsToProcessException(string message,  Exception innerException) : base(message, innerException) { }
}