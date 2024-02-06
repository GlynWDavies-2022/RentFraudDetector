using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentFraudDetector.Data;
using RentFraudDetector.Job.Services.Contracts;
using RentFraudDetector.Job.Services.Implementations;
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

    private static void ConfigureServices(ServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddDbContext<RentFraudDetectorDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LettingsFraudConnectionString"));
        });
        services.AddSingleton(configuration);
        services.AddSingleton<IApplicationService, ApplicationService>();
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog();
        });
        services.BuildServiceProvider();
    }
}