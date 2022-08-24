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

        public async Task<Employee> CreateAsync(Employee employee)
        {
            var command = "Insert Employee(Name,Email,Id,Salary) Values (@Name,@Email,@Id,@Salary)";
            var result = await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }

        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            await _dbConnection.ExecuteAsync($"InsertRecord{employees}");
        }

        public async Task DeleteAsync(int employeeId)
        {
            var command = "Delete from Employee where Id=@Id";
            await _dbConnection.ExecuteAsync(command, new {Id = employeeId});
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var query = "execute spGetEmployeesById";
            return (await _dbConnection.QueryAsync<Employee>(query, new { employeeId })).FirstOrDefault();
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var query = "SELECT [e].[Id],[e].[Name],[e].[Salary],[e].[Name] AS [DepartmentName] FROM [Employee] AS [e] INNER JOIN [Department] AS[d] ON [e].[DepartmentId]=[d].[Id]";
            return await _dbConnection.QueryAsync<EmployeeDto>(query);
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string filterText = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee>UpdateAsync(int employeeId, Employee employee)
        {
            var command = "Update Employee Set Name = @Name, Salary =@Salary Where Id = @Id";
            await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }

        Task<IEnumerable<Employee>> IEmployeeRepository.GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
