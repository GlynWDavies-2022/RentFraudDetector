using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Shared.Models;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Job.Services.Implementations;

public class ApplicationService : IApplicationService
{
    private readonly IConfiguration _configuration;
    private readonly IDownloadService _downloadService;
    private readonly IEncryptionService<EmployeeDb, Employee> _encryptionService;
    private readonly IFileReaderService _fileReaderService;
    private readonly IRepository<EmployeeDb> _employeeRepository; 

    private byte[] Key { get; init; }
    private byte[] Vector { get; init; }

    public ApplicationService(IDownloadService downloadService, IConfiguration configuration,
        IFileReaderService fileReaderService, IRepository<EmployeeDb> employeeRepository,
        IEncryptionService<EmployeeDb, Employee> encryptionService)
    {
        _downloadService = downloadService;
        _configuration = configuration;
        _fileReaderService = fileReaderService;
        _employeeRepository = employeeRepository;
        _encryptionService = encryptionService;

        using var aes = Aes.Create();
        Key = aes.Key;
        Vector = aes.IV;
    }

    public void Run()
    {
        // ----------------------------------------------------------------------------------------
        // Download Employee File
        // ----------------------------------------------------------------------------------------
        
        _downloadService.Download();

        // ----------------------------------------------------------------------------------------
        // Read Employee File
        // ----------------------------------------------------------------------------------------
        
        var decryptedEmployeesFromDownload = _fileReaderService.ReadEmployees();

        // ----------------------------------------------------------------------------------------
        // Delete Employee Files From Download Directory
        // ----------------------------------------------------------------------------------------
        
        DeleteEmployeeFiles();
        
        // ----------------------------------------------------------------------------------------
        // Read Employees From Database
        // ----------------------------------------------------------------------------------------

        var encryptedEmployeesFromDatabase = _employeeRepository.Read();
    }

    private void DeleteEmployeeFiles()
    {
        var employeeFiles = Directory.GetFiles(_configuration["Directories:Downloads"]!);
        
        foreach (var file in employeeFiles)
        {
            File.Delete(file);
        }
    }
}