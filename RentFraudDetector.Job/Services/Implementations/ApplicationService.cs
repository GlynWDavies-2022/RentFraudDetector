using Microsoft.Extensions.Configuration;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Job.Services.Implementations;

public class ApplicationService : IApplicationService
{
    private readonly IConfiguration _configuration;
    private readonly IDownloadService _downloadService;

    public ApplicationService(IDownloadService downloadService, IConfiguration configuration)
    {
        _downloadService = downloadService;
        _configuration = configuration;
    }

    public void Run()
    {
        _downloadService.Download();
    }
}