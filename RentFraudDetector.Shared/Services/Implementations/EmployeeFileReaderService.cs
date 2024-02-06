using Microsoft.Extensions.Configuration;
using RentFraudDetector.Shared.Domain;
using RentFraudDetector.Shared.Exceptions;
using RentFraudDetector.Shared.Services.Contracts;
using Serilog;

namespace RentFraudDetector.Shared.Services.Implementations;

public class EmployeeFileReaderService : IFileReaderService
{
    private readonly IConfiguration _configuration;

    public EmployeeFileReaderService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Employee> ReadEmployees()
    {
        var employeeDownloadDirectory = _configuration["Directories:Downloads"];
        
        if (!Directory.Exists(employeeDownloadDirectory))
        {
            throw new DirectoryNotFoundException($"Directory {employeeDownloadDirectory} does not exist.");
        }
        
        Log.Information($"Scanning {Path.GetDirectoryName(employeeDownloadDirectory)} for files.");

        var employeeFile = Directory.GetFiles(employeeDownloadDirectory).MaxBy(f => f);
        
        if (string.IsNullOrEmpty(employeeFile))
        {
            throw new NoFilesToProcessException("There were no employee files to process.");
        }
        
        return null!;
    }
}