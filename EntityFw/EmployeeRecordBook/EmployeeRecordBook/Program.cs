using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;

Console.WriteLine("Hello, World!");

// Sepration of concern
//var departmentRepository = new DepartmentRepository();
//departmentRepository.Create(new Department() { DepartmentName = "HR" });
//departmentRepository.Create(new Department() { DepartmentName = "IT" });
//departmentRepository.Create(new Department() { DepartmentName = "Accounting" });

using (var employeeContext = new EmployeeContext())
{
    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);

    
    var parmeshwar = await employeeRepository.CreateAsync(new Employee
    {
        Name = "Parmeshwar",
        EmailId = "parmeshwar@gmail.com",
        Salary = 25000m,
        DepartmentId = 1
    });

   var patil = await employeeRepository.CreateAsync(new Employee
   {
       Name = "Parmeshwar Patil",
       EmailId = "parmeshwar252@gmail.com",
       Salary = 28000m,
       DepartmentId = 2
   });

    Console.WriteLine($"Created Employees: {parmeshwar.Name}, {parmeshwar.EmailId}, {parmeshwar.Salary}, {parmeshwar.DepartmentId}");

    var employees = await employeeRepository.GetEmployeesAsync();
    Console.WriteLine($"Total employee's record: {employees.Count()}");

    var updateParmeshwarData = new Employee
    {
        Name = "Parmeshwar",
        EmailId = "parmeshwarSawrate@gmail.com",
        Salary = 25000m,
        DepartmentId = 1
    };
    var updateEmployee =await employeeRepository.UpdateAsync(parmeshwar.EmployeeId, updateParmeshwarData);
    Console.WriteLine($"Updates Employees: {updateParmeshwarData.EmailId}, {updateParmeshwarData.Name}, {updateParmeshwarData.Salary}, {updateParmeshwarData.DepartmentId}");

    await employeeRepository.DeleteAsync(patil.EmployeeId);

    var deletedRecord = await employeeRepository.GetEmployeeAsync(patil.EmployeeId);
    Console.WriteLine($"Was record deleted? {deletedRecord==null: true? false}");
}

using(var employeeContext = new EmployeeContext())
{
    IDepartmentRepository departmentRepository = new DepartmentRepository(employeeContext);

    var sapDepartment = await departmentRepository.CreateAsync(new Department
    {
        DepartmentId = 3,
        DepartmentName = "SAP",
    });

    var departments = await departmentRepository.GetDepartmentAsync();
    Console.WriteLine($"Total employee's record: {departments.Count()}");

}
