using JWT.Authentication.Server.Core.Contract.Repository;
using JWT.Authentication.Server.Core.Entities;
using JWT.Authentication.Server.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Authentication.Server.Infrastructure.Repositories
{
    public class UserRepository : IEmployeeRepository
    {
        private readonly EmployeemanagementDbContext _dbContext;


        public UserRepository(EmployeemanagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            return await _dbContext.Employees.AnyAsync(s => s.EmailId == email && s.Password == password);
        }

        public async Task<Employee> RegisterUser(Employee user)
        {
            await _dbContext.Employees.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Employee> GetUserDetails(string email)
        {

            return await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmailId == email);
        }

        public async Task<Role?> GetEmployeeRole(Employee employee)
        {
            var employeeRole = await (from role in _dbContext.Roles
                                      join emp in _dbContext.Employees
                                      on role.RoleId equals emp.RoleId
                                      where emp.EmployeeId == employee.EmployeeId
                                      select new Role
                                      {
                                          RoleName = role.RoleName
                                      }).FirstOrDefaultAsync();

            return employeeRole;
        }
    }
}
