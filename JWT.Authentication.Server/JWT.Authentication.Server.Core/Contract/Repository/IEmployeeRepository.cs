using JWT.Authentication.Server.Core.Entities;

namespace JWT.Authentication.Server.Core.Contract.Repository
{
    public interface IEmployeeRepository
    {
        public Task<bool> ValidateUser(string email, string password);
        public Task<Employee> RegisterUser(Employee user);
        Task<Employee> GetUserDetails(string email);
        Task<Role?> GetEmployeeRole(Employee employee);
    }
}
