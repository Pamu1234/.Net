using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task DeleteAsync(int employeeId);
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task CreateRangeAsync(IEnumerable<Employee> employees);

        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> UpdateAsync(int employeeId, Employee employee);


        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize,  string sortField, string sortOrder = "asc", string filterText = null);
        //Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    }
}