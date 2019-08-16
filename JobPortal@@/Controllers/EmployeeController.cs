using JobPortal2.Model;
using JobPortal2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
   // [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return Ok(employees);
        }



        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public IActionResult GetEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Employee employee)
        {
        
            try
            {
              
                _employeeRepository.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            //var employee = _mapper.Map<Employee>(employeeDto);
            if (employee == null)
            {
                return BadRequest();
            }

            _employeeRepository.CreateEmployee(employee);

            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

    }
}
