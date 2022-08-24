using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;
using EmployeeRecordBook.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeRecordBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            _logger.LogInformation("Getting list of employees");
            return await _employeeRepository.GetEmployeesAsync();
        }


        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            _logger.LogInformation("Get employee data  by employee id: {id}",id);
            return await _employeeRepository.GetEmployeeAsync(id);
        }


        [HttpPost]
        public async Task<Employee> Post([FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            return await _employeeRepository.CreateAsync(employee);

        }


        [HttpPut("{id}")]
        public async Task<Employee> Put(int id, [FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Id = employeeVm.Id, Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            return await _employeeRepository.UpdateAsync(id, employee);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
