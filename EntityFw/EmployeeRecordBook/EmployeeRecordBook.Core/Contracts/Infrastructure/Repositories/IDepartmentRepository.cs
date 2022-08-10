using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);
        Task<IEnumerable<Department>> GetDepartmentAsync();
        Task<Department> CreateAsync(int departmentid);
    }
}