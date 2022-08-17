using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
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

        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Employees.AddRange(employees);
                await employeeContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string filterText = null)
        {
            var employeesQuery = from employee in _employeeContext.Employees.Include(e => e.Department)
                                 .Where(emp => emp.Name.ToLower().Contains(filterText) || emp.Email.ToLower().Contains(filterText) || filterText.Equals(null))
                                 select new EmployeeDto
                                 {
                                     Id = employee.Id,
                                     Name = employee.Name,
                                     Salary = employee.Salary,
                                     DepartmentName = employee.Department.Name
                                 };


            if (sortOrder == "desc")
            {
                IEnumerable<EmployeeDto> employeeQuery = null;
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = await (employeesQuery.OrderByDescending(emp => emp.Id)).ToListAsync();
                        break;

                    case "Name":
                        employeeQuery = await (employeesQuery.OrderByDescending(emp => emp.Name)).ToListAsync();
                        break;

                    case "Email":
                        employeeQuery = await (employeesQuery.OrderByDescending(emp => emp.Email)).ToListAsync();
                        break;

                    case "Salary":
                        employeeQuery = await (employeesQuery.OrderByDescending(emp => emp.Salary)).ToListAsync();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                return employeeQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                IEnumerable<EmployeeDto> employeeQuery = null;
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = await (employeesQuery.OrderBy(emp => emp.Id)).ToListAsync();
                        break;

                    case "Name":
                        employeeQuery = await (employeesQuery.OrderBy(emp => emp.Name)).ToListAsync();
                        break;

                    case "Email":
                        employeeQuery = await (employeesQuery.OrderBy(emp => emp.Email)).ToListAsync();
                        break;

                    case "Salary":
                        employeeQuery = await (employeesQuery.OrderBy(emp => emp.Salary)).ToListAsync();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                return employeeQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            }


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

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
