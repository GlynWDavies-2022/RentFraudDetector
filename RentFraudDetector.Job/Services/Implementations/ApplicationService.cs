using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Job.Services.Implementations;

public class ApplicationService : IApplicationService
{
    private readonly IConfiguration _configuration;
    private readonly IDownloadService _downloadService;
    private readonly IFileReaderService _fileReaderService;

    private byte[] Key { get; init; }
    private byte[] Vector { get; init; }

    public ApplicationService(IDownloadService downloadService, IConfiguration configuration, IFileReaderService fileReaderService)
    {
        _downloadService = downloadService;
        _configuration = configuration;
        _fileReaderService = fileReaderService;

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
        
        var employees = _fileReaderService.ReadEmployees();

        // ----------------------------------------------------------------------------------------
        // Delete Employee Files From Download Directory
        // ----------------------------------------------------------------------------------------
        
        DeleteEmployeeFiles();
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