using System.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Renci.SshNet;
using Renci.SshNet.Common;
using RentFraudDetector.Shared.Services.Contracts;
using Serilog;

namespace RentFraudDetector.Shared.Services.Implementations;

public class SFTPDownloadService : IDownloadService
{
    private readonly IConfiguration _configuration;

    public SFTPDownloadService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Download()
    {
        var host = _configuration["SFTP:Host"];
        var userName = _configuration["SFTP:UserName"];
        var password = _configuration["SFTP:Password"];
        var remoteDirectory = $"{_configuration["SFTP:Root"]}{_configuration["ZelloPay:Downloads"]}";
        var localDirectory = _configuration["Directories:Downloads"];
        var downloadedFile = $"{localDirectory}\\{_configuration["Files:Employee"]}-{DateTime.Now:yyyy-MM-dd}.csv";

        if (!Directory.Exists(localDirectory))
        {
            CreateLocalDownloadDirectory();
        }

        using var sftp = new SftpClient(host, userName, password);

        try
        {
            Log.Information($"Connecting to {host} as {userName}");
            sftp.Connect();
            Log.Information($"Connected to {host} as {userName}");
            var files = sftp.ListDirectory(remoteDirectory);
            foreach (var file in files)
            {
                if (!file.Name.EndsWith(".csv") || file.Name == "." || file.Name == "..") continue;

                using Stream csvFile = File.Create(downloadedFile);

                Log.Information($"Downloading {file} from {host}/{remoteDirectory}");

                sftp.DownloadFile($"{file.FullName}", csvFile);

                Log.Information($"Downloaded {file} to {downloadedFile}");

                break;
            }

        }
        catch (SocketException)
        {
            Log.Fatal($"Could not connect to {host} as {userName}");
            throw;
        }
        catch (SftpPathNotFoundException)
        {
            Log.Fatal($"Remote path {host}/{remoteDirectory} could not be found.");
        }
        catch (Exception e)
        {
            Log.Error($"An error occurred while downloading: {e.Message}");
        } 
    }

    public void CreateLocalDownloadDirectory()
    {
        if (!Directory.Exists(_configuration["Directories:Downloads"]))
        {
            Directory.CreateDirectory("C:\\Temp\\Downloads");
        }
    }
}