using Dapper;
using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using System.Data;

namespace EmployeeRecordBook.Infrastructure.Repositories.Dapper
{
    public class EmployeeDapperRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;
        public EmployeeDapperRepository(IDbConnection dbConnection)
        {
                _dbConnection = dbConnection;
        }

        public async Task<Employee> CreateAsync (Employee employee)
        {
            var command = "Insert Employee(Name,Email,Id,Salary) Values (@Name,@Email,@Id,@Salary)";
            var result = await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }

        public Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var command = "Delete from Employee where Id=@Id";
            await _dbConnection.ExecuteAsync(command, new {Id = employeeId});
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var query = "select * from Employee where Id = @employeeId";
            return (await _dbConnection.QueryAsync<Employee>(query, new { employeeId })).FirstOrDefault();
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var query = "SELECT [e].[Id],[e].[Name],[e].[Salary],[e].[Name] AS [DepartmentName] FROM [Employee] AS [e] INNER JOIN [Department] as[d] ON [e].[DepartmentId]=[d].[Id]";
            return await _dbConnection.QueryAsync<EmployeeDto>(query);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string filterText = null)
        {
            var query = "select * from Employee ";
            var employeesList = await _dbConnection.QueryAsync<EmployeeDto>(query);
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

        public async Task<Employee>UpdateAsync(int employeeId, Employee employee)
        {
            var command = "Update Employee Set Name = @Name, Salary =@Salary Where Id = @Id";
            await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }
    }
}
