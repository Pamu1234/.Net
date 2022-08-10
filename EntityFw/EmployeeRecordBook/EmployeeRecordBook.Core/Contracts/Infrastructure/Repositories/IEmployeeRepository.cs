using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Core.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task DeleteAsync(int employeeId);
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
    }
}