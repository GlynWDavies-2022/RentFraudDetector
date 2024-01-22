using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            .WriteTo.Console()
            .WriteTo.File($"{configuration["Directories:Logs"]}\\RentFraudDetector.Job\\Log-.log", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Information()
            .CreateLogger();
        
        Log.Logger.Information("Application starting.");
        
        try
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(hostContext, services);
                })
                .UseSerilog()
                .Build()
                .Services.GetRequiredService<IApplicationService>()
                .Run();
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message, e);
        }

        Log.Logger.Information("Application shutting down.");
    }
    
    private static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
    {
        services.AddSingleton<IApplicationService,ApplicationService>();

        services.BuildServiceProvider();
    }
}