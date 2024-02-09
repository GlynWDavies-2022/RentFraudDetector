using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentFraudDetector.Shared.Data;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Job.Services.Implementations;
using RentFraudDetector.Shared.Models;
using RentFraudDetector.Shared.Services.Contracts;
using RentFraudDetector.Shared.Services.Implementations;
using Serilog;

namespace RentFraudDetector.Job;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        try
        {
            Log.Information("Starting application");

            var services = new ServiceCollection();

            ConfigureServices(services, configuration);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var applicationService = serviceProvider.GetRequiredService<IApplicationService>();
                applicationService.Run();
            }

            Log.Information("Stopping application.");
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Application startup failed.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RentFraudDetectorDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RentFraudDetectorConnectionString"));
        });
        services.AddSingleton(configuration);
        services.AddSingleton<IApplicationService, ApplicationService>();
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog();
        });
        services.AddSingleton<IDownloadService, SFTPDownloadService>();
        services.AddSingleton<IEncryptionService<EmployeeDb, Employee>, EmployeeEncryptionService>();
        services.AddSingleton<IFileReaderService, EmployeeFileReaderService>();
        services.AddSingleton<IRepository<EmployeeDb>, EmployeeRepository>();
        services.BuildServiceProvider();
    }
}