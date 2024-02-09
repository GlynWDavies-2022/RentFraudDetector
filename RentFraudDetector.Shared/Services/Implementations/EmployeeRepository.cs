using RentFraudDetector.Shared.Data;
using RentFraudDetector.Shared.Models;
using RentFraudDetector.Shared.Services.Contracts;

namespace RentFraudDetector.Shared.Services.Implementations;

public class EmployeeRepository : IRepository<EmployeeDb>
{
    private readonly RentFraudDetectorDbContext _context;

    public EmployeeRepository(RentFraudDetectorDbContext context)
    {
        _context = context;
    }

    public IEnumerable<EmployeeDb> Read()
    {
        var employees = _context.Employees.ToList();
        
        return employees;
    }

    public void Write(IEnumerable<EmployeeDb> newEmployeesEncrypted)
    {
        _context.AddRange(newEmployeesEncrypted);
        
        _context.SaveChanges();
    }
}