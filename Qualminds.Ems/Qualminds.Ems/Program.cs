using Qualminds.Ems.Core.Contracts.Infrastructure;
using Qualminds.Ems.Core.Entities;
using Qualminds.Ems.Infrastructure.IO;
using System.Text.Json;
using System.Text;


Console.WriteLine("Please enter file path");
string directoryPath = Console.ReadLine(); 
string fileName = "Employee.csv";
IEmployeeService employeeService = new EmployeeService(Path.Combine(directoryPath, fileName));
Console.WriteLine($"Created {fileName} with predefined headers");

Console.WriteLine("\nAdding Employees:\n");
//var afroz = employeeService.AddEmployee(new Employee { Name = "Afroz", Designation = "Asst. Programmer" });
//var mallika = employeeService.AddEmployee(new Employee { Name = "Mallika", Designation = "Associate Engineer" });
//Console.WriteLine($"Employees added successfully. Here are their newly created IDs: {afroz.Name}: {afroz.Id}, {mallika.Name}: {mallika.Id}");

//employeeService.AddEmployees(new List<Employee>()
//{
//   new Employee { Name="Navneet", Designation = "Programmer"},
//   new Employee { Name = "Bhupal", Designation = "Asst. Programmer" },
//   new Employee { Name = "Parmeshwar", Designation = "Associate Engineer" }
//});
string SelectedOption;
string AddMoreOption;
Console.WriteLine("Do you want to add employee details...? \n\tpress 'y' for Yes or 'n' for No");
SelectedOption = Console.ReadLine();

do
{
    if (SelectedOption == "y")
    {
        Console.WriteLine("Enter employee name:");
        var EmpName = Console.ReadLine();
        Console.WriteLine("Enter employee designation:");
        var EmpDesignation = Console.ReadLine();
        IEmployeeService employeeServiceAdd = new EmployeeService(Path.Combine(directoryPath, fileName));
        employeeServiceAdd.AddEmployee(new Employee { Name = EmpName, Designation = EmpDesignation });

    }
    else if (SelectedOption == "n")
    {
        break;
    }
    Console.WriteLine("Do you want to add more:\n\t enter 'yes' for continue and 'no' for exit");
    AddMoreOption = Console.ReadLine();
} while (AddMoreOption == "yes");

StringBuilder employees = employeeService.GetEmployees();
Console.WriteLine($"ID\t\t\t\t\t NAME\t DESIGNATION");
Console.WriteLine(employees);
//var stringifiedEmployees = JsonSerializer.Serialize(employees);
//Console.WriteLine("\nList of all Employees:\n");
//Console.WriteLine($"{stringifiedEmployees}");

//employeeService.DeleteEmployees();
//Console.WriteLine("\nSuccessfully deleted employees record and file.");