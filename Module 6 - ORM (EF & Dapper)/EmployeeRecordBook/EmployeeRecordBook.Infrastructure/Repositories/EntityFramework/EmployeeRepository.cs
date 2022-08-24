using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories.EntityFramework
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

        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {

            _employeeContext.Employees.AddRange(employees);
            await _employeeContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string filterText = null)
        {
            var employeesList = await (from employee in _employeeContext.Employees.Include(e => e.Department)
                                 .Where(emp => emp.Name.ToLower().Contains(filterText) || emp.Email.ToLower().Contains(filterText) || filterText.Equals(null))
                                       select new EmployeeDto
                                       {
                                           Id = employee.Id,
                                           Name = employee.Name,
                                           Salary = employee.Salary,
                                           DepartmentName = employee.Department.Name
                                       }).ToListAsync();

            IEnumerable<EmployeeDto> employeeQuery = new List<EmployeeDto>();
            if (sortOrder == "desc")
            {

                switch (sortField)
                {

                    case "Id":
                        employeeQuery = employeesList.OrderByDescending(emp => emp.Id);
                        break;

                    case "Name":
                        employeeQuery = employeesList.OrderByDescending(emp => emp.Name);
                        break;

                    case "Email":
                        employeeQuery = employeesList.OrderByDescending(emp => emp.Email);
                        break;

                    case "Salary":
                        employeeQuery = employeesList.OrderByDescending(emp => emp.Salary);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
            else
            {
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = employeesList.OrderBy(emp => emp.Id);
                        break;

                    case "Name":
                        employeeQuery = employeesList.OrderBy(emp => emp.Name);
                        break;

                    case "Email":
                        employeeQuery = employeesList.OrderBy(emp => emp.Email);
                        break;

                    case "Salary":
                        employeeQuery = employeesList.OrderBy(emp => emp.Salary);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

            }

            return employeeQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        //return await _employeeContext.Employees.ToListAsync();
        //return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _employeeContext.Employees.FindAsync(employeeId);
        }
        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var employeeToBeUpdated = await GetEmployeeAsync(employeeId);
            employeeToBeUpdated.Name = employee.Name;
            employeeToBeUpdated.Email = employee.Email;
            employeeToBeUpdated.Salary = employee.Salary;
            employeeToBeUpdated.DepartmentId = employee.DepartmentId;
            _employeeContext.Employees.Update(employeeToBeUpdated);
            _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
            return employeeToBeUpdated;
        }
        public async Task DeleteAsync(int employeeId)
        {
            var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
            _employeeContext.Employees.Remove(employeeToBeDeleted);
            await _employeeContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

       
    }
}
