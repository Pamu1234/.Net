using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);
        Task CreateRangeAsync(IEnumerable<Department> departments);
        Task DeleteAsync(int departmentId);
        Task<IEnumerable<DepartmentDto>> GetDepartmentAsync();
        Task<Department> GetDepartmentAsync(int departmentId);
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string filterText = null);
        Task<Department> UpdateAsync(int departmentId, Department department);
    }
}