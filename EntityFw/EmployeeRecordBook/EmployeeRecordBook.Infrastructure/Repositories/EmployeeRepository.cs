using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }

        // Method to get all employees without any filter
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            // One way
            //return await _employeeContext.Employees.ToListAsync(); 

            var employeeQuery = from employee in _employeeContext.Employees
                                select employee;
            return await employeeQuery.ToListAsync();
        }
        // Method to get single employees using id
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _employeeContext.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefaultAsync();
        }
        // Update data
        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var employeeToBeUpdate = await GetEmployeeAsync(employeeId);
            employeeToBeUpdate.Name = employee.Name;
            employeeToBeUpdate.Salary = employee.Salary;
            employeeToBeUpdate.EmailId = employee.EmailId;
            //employeeToBeUpdate.EmployeeId = employee.EmployeeId;
            employeeToBeUpdate.DepartmentId = employee.DepartmentId;
            _employeeContext.Employees.Update(employeeToBeUpdate);
            _employeeContext.SaveChanges();
            return employeeToBeUpdate;
        }
        public async Task DeleteAsync(int employeeId)
        {
            var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
            _employeeContext.Employees.Remove(employeeToBeDeleted);
            await _employeeContext.SaveChangesAsync();


        }
    }
}
