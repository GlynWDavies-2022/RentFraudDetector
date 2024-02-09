using System.Security.Cryptography;
using RentFraudDetector.Shared.Data;
using RentFraudDetector.Shared.Models;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Shared.Services.Implementations;

public class EmployeeEncryptionService : IEncryptionService<EmployeeDb,Employee>
{
    private readonly RentFraudDetectorDbContext _context;

    private readonly List<CompanyDb> _companies;

    public EmployeeEncryptionService(RentFraudDetectorDbContext context)
    {
        _context = context;
        _companies = _context.Companies.ToList();
    }

    public IEnumerable<EmployeeDb> Encrypt(IEnumerable<Employee> employees, byte[] key, byte[] iv)
    {
        var encryptedEmployees = new List<EmployeeDb>();
        
        employees.ToList().ForEach(e =>
        {
            var companyId = _companies.Where(c => c.Name == e.CompanyName).Select(c => c.Id).FirstOrDefault();
            var staffNumberEncrypted = EncryptStringToBytes(e.StaffNumber!, key, iv);
            var firstNameEncrypted = EncryptStringToBytes(e.FirstName!, key, iv);
            var surnameEncrypted = EncryptStringToBytes(e.Surname!, key, iv);
            var sortCodeEncrypted = EncryptStringToBytes(e.SortCode!, key, iv);
            var branchNameEncrypted = EncryptStringToBytes(e.BranchName!, key, iv);
            var accountNumberEncrypted = EncryptStringToBytes(e.AccountNumber!, key, iv);
            var accountNameEncrypted = EncryptStringToBytes(e.AccountName!, key, iv);
            var rollNumberEncrypted = EncryptStringToBytes(e.RollNumber!, key, iv);
            
            encryptedEmployees.Add(new EmployeeDb
            {
                CompanyDbId = companyId,
                StaffNumber = staffNumberEncrypted,
                FirstName = firstNameEncrypted,
                Surname = surnameEncrypted,
                SortCode = sortCodeEncrypted,
                BranchName = branchNameEncrypted,
                AccountNumber = accountNumberEncrypted,
                AccountName = accountNameEncrypted,
                RollNumber = rollNumberEncrypted,
                Key = key,
                Vector = iv
            });
        });

        return encryptedEmployees;
    }

    public IEnumerable<Employee> Decrypt(IEnumerable<EmployeeDb> encryptedEmployees)
    {
        var decryptedEmployees = new List<Employee>();
        
        encryptedEmployees.ToList().ForEach(e =>
        {
            var company = e.CompanyDbId;
            var staffNumber = DecryptStringFromBytes(e.StaffNumber!, e.Key!, e.Vector!);
            var firstName = DecryptStringFromBytes(e.FirstName!, e.Key!, e.Vector!);
            var surname = DecryptStringFromBytes(e.Surname!, e.Key!, e.Vector!);
            var sortCode = DecryptStringFromBytes(e.SortCode!, e.Key!, e.Vector!);
            var branchName = DecryptStringFromBytes(e.BranchName!, e.Key!, e.Vector!);
            var accountNumber = DecryptStringFromBytes(e.AccountNumber!, e.Key!, e.Vector!);
            var accountName = DecryptStringFromBytes(e.AccountName!, e.Key!, e.Vector!);
            var rollNumber = DecryptStringFromBytes(e.RollNumber!, e.Key!, e.Vector!);
            
            decryptedEmployees.Add(new Employee
            {
                CompanyName = _companies.Where(c => c.Id == e.CompanyDbId).Select(c => c.Name).FirstOrDefault(),
                StaffNumber = staffNumber,
                FirstName = firstName,
                Surname = surname,
                SortCode = sortCode,
                BranchName = branchName,
                AccountNumber = accountNumber,
                AccountName = accountName,
                RollNumber = rollNumber
            });
        });

        return decryptedEmployees;
    }
    
    private static byte[] EncryptStringToBytes(string text, byte[] key, byte[] iv)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(iv);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using MemoryStream memoryStream = new();
        using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
        using (StreamWriter streamWriter = new(cryptoStream))
        {
            streamWriter.Write(text);
        }

        var encrypted = memoryStream.ToArray();

        return encrypted;
    }
    
    private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
    {
        ArgumentNullException.ThrowIfNull(cipherText);
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(iv);

        string? plainText = null;

        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream memoryStream = new(cipherText);
        using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream);
        plainText = streamReader.ReadToEnd();

        return plainText;
    }
}