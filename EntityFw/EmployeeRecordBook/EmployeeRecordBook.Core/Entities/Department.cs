namespace EmployeeRecordBook.Core.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
