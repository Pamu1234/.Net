using EmployeeRecordBook.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Data
{
    public class EmployeeContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; } // Both act as table in DB.

        // Now create connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDb)\MSSQLLocalDB;Database=EmployeeDb;Trusted_Connection=True;");
        }
        // Use migration
    }
}
