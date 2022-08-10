using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _employeeContext;
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<Department> CreateAsync(Department department)
        {
            _employeeContext.Departments.Add(department);
            await _employeeContext.SaveChangesAsync();
            return department;
        }
        // Method to get all department without any filter
        public async Task<IEnumerable<Department>> GetDepartmentAsync()
        {
            var departmentQuery = from dept in _employeeContext.Departments
                                  select dept;
            return await departmentQuery.ToListAsync();
        }
        // Method to get single department using department-id
        public async Task<Department> CreateAsync(int departmentid)
        {
            return await _employeeContext.Departments.Where(e => e.DepartmentId == departmentid).FirstOrDefaultAsync();

        }


        // Not ideal way to use DB  context here,use const. injection.
        //using (var employeeContext = new EmployeeContext())
        //{ 
        //employeeContext.Departments.Add(department);
        //employeeContext.SaveChanges();
        //}

    }

}




