using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories.EntityFramework
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _employeeContext;
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task CreateRangeAsync(IEnumerable<Department> departments)
        {
            _employeeContext.Departments.AddRange(departments);
            await _employeeContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(int pageIndex, int pageSize, string sortField, string? sortOrder = "asc", string? filterText = null)
        {
            var departmentList = await (from dept in _employeeContext.Departments
                                 .Where(e => e.Name.ToLower().Contains(filterText) || filterText == null)
                                        select new DepartmentDto
                                        {
                                            Name = dept.Name,
                                            Id = dept.Id
                                        }).ToListAsync();
            IEnumerable<DepartmentDto> departmentQuery = new List<DepartmentDto>();
            if (sortOrder == "desc")
            {
                switch (sortField)
                {

                    case "Id":
                        departmentQuery = departmentList.OrderByDescending(dept => dept.Id);
                        break;

                    case "Name":
                        departmentQuery = departmentList.OrderByDescending(dept => dept.Name);
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
                        departmentQuery = departmentList.OrderBy(dept => dept.Id);
                        break;

                    case "Name":
                        departmentQuery = departmentList.OrderBy(dept => dept.Name);
                        break;


                    default:
                        throw new ArgumentOutOfRangeException();

                }

            }

            return departmentQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        }
        public async Task<Department> GetDepartmentAsync(int departmentId)
        {
            return await _employeeContext.Departments.FindAsync(departmentId);
        }

        public async Task<Department> UpdateAsync(int departmentId, Department department)
        {
            var departmentToBeUpdated = await GetDepartmentAsync(departmentId);
            departmentToBeUpdated.Name = department.Name;
            departmentToBeUpdated.Id = department.Id;
            _employeeContext.Departments.Update(departmentToBeUpdated);
            _employeeContext.SaveChanges();
            return departmentToBeUpdated;
        }

        public async Task DeleteAsync(int departmentId)
        {
            var departmentToBeDeleted = await GetDepartmentAsync(departmentId);
            _employeeContext.Departments.Remove(departmentToBeDeleted);
            await _employeeContext.SaveChangesAsync();
        }

        public Task<IEnumerable<DepartmentDto>> GetDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> CreateAsync(Department department)
        {
            throw new NotImplementedException();
        }

        //public async Task CreateAsync(Department department)
        //{
        //   // Not ideal way to use DB Context instance here, instead use constuctor injection. 
        //   using (var employeeContext = new EmployeeContext())
        //   {
        //      employeeContext.Departments.Add(department);
        //      await employeeContext.SaveChangesAsync();
        //   }
        //}
        //public async Task CreateRangeAsync(IEnumerable<Department> departments)
        //{
        //   // Not ideal way to use DB Context instance here, instead use constuctor injection. 
        //   using (var employeeContext = new EmployeeContext())
        //   {
        //      employeeContext.Departments.AddRange(departments);
        //      await employeeContext.SaveChangesAsync();
        //   }
    }
}

