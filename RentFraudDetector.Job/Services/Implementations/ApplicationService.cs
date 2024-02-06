using Microsoft.Extensions.Configuration;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Job.Services.Implementations;

public class ApplicationService : IApplicationService
{
    private readonly IConfiguration _configuration;
    private readonly IDownloadService _downloadService;
    private readonly IFileReaderService _fileReaderService;

    public ApplicationService(IDownloadService downloadService, IConfiguration configuration, IFileReaderService fileReaderService)
    {
        _downloadService = downloadService;
        _configuration = configuration;
        _fileReaderService = fileReaderService;
    }

    public void Run()
    {
        _downloadService.Download();

        var employees = _fileReaderService.ReadEmployees();
    }
}