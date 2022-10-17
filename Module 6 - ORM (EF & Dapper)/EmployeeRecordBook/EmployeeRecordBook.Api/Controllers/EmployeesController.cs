using AutoMapper;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Repositories;
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
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeesController> logger )
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _logger = logger;

        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable< Employee>>> Get()
        {
            _logger.LogInformation("Getting list of employees");
            var result = await _employeeRepository.GetEmployeesAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Employee>>> Get(int id)
        {
            if(id<= 0 || id>=9999)
                return BadRequest("Invalid Id");
            _logger.LogInformation("Get employee data  by employee id: {id}",id);
            var result = await _employeeRepository.GetEmployeeAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employee>>> Post([FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            var result = await _employeeRepository.CreateAsync(employee);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Put(int id, [FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Id = employeeVm.Id, Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            var result = await _employeeRepository.UpdateAsync(id, employee);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
