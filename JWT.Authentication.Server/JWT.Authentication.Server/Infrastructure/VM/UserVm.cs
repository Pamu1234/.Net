namespace JWT.Authentication.Server.Infrastructure.VM
{
    public class EmployeeVm
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Contact { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
