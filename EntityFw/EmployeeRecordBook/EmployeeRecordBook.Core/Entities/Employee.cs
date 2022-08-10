namespace EmployeeRecordBook.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string EmailId { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; } // Use this type of relation

    }
}
