using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using RentFraudDetector.Shared.Domain;
using RentFraudDetector.Shared.Exceptions;
using RentFraudDetector.Shared.Mapping;
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
        
        Log.Information("Configuring CSV reader.");

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            NewLine = Environment.NewLine,
            ShouldSkipRecord = record => string.IsNullOrEmpty(record.Row.GetField(0))
        };

        var employees = new List<Employee>();
        
        Log.Information($"Reading {employeeFile}.");

        using var reader = new StreamReader(employeeFile);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<EmployeeFileMap>();

        employees = csv.GetRecords<Employee>().ToList();

        if (employees.Count == 0)
        {
            throw new NoRecordsToProcessException("There were no employee records in the file.");
        }

        Log.Information($"Read {employees.Count} employee records.");
        
        return employees;
    }
}