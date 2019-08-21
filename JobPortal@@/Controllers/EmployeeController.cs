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
  // [Authorize]
    [Route("api/[controller]")]
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employees);
        }



        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public IActionResult GetEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (employee == null)
                return NotFound();
            
            return Ok(employee);
        }



        [HttpPut("{employeeId}")]
        public IActionResult Update(int id, [FromBody]Employee employee)
        {

            if (employee == null)
                return BadRequest(ModelState);
            if (id != employee.EmployeeId)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _employeeRepository.UpdateEmployee(employee);
                return NoContent();
          
        }



        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //var employee = _mapper.Map<Employee>(employeeDto);
                if (employee == null)
                {
                    ModelState.AddModelError("", "Employee cannot be empty");
                    return BadRequest(ModelState);
                }

                _employeeRepository.CreateEmployee(employee);

                return StatusCode(201);

               // return CreatedAtRoute("GetEmployee", new { employeeId = employee.Id }, employee);
            }
            return BadRequest(ModelState);
        }

    }
}
