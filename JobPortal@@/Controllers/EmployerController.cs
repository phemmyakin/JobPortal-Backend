using JobPortal__.Data;
using JobPortal2.Dto;
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
    //[Authorize]
    [Route("api/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployerController(IEmployerRepository employerRepository, ICompanyRepository companyRepository)
        {
            _employerRepository = employerRepository;
            _companyRepository = companyRepository;
        }

        [Authorize(Roles = "Admin, JobSeeker")]
        [HttpGet]
        public IActionResult GetEmployers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employers = _employerRepository.GetEmployers();
            return Ok(employers);

        }

        [Authorize(Roles = "Admin, JobSeeker")]
        [HttpGet("Companies")]
        public IActionResult GetCompanies()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var companies = _companyRepository.GetCompanies();
            return Ok(companies);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Company/Employers")]
        public IActionResult GetEmployersOfACompany(int companyId)
        {
            if (!_companyRepository.CompanyExist(companyId))
                return NotFound();
            var employers = _employerRepository.GetEmployersOfACompany(companyId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employerDto = new List<EmployerDto>();
           // var user = new List<ApplicationUser>();
            foreach (var employer in employers)
            {
                employerDto.Add(new EmployerDto
                {
                    Id = employer.EmployerId,
                    FirstName = employer.FirstName,
                    LastName = employer.LastName
                });
            }
            return Ok(employerDto);

        }


        [Authorize(Roles = "Admin, JobSeeker")]
        [HttpGet("employerId")]
        public IActionResult GetEmployer(int employerId)
        {
            var employer = _employerRepository.GetEmployer(employerId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (employer == null)
                return NotFound();
            return Ok(employer);
        }

        [Authorize(Roles = "Admin, Company")]
        [HttpPut("employerid")]
        public IActionResult Update(int Id, [FromBody] Employer employer)
        {
            if (employer == null)
                return BadRequest(ModelState);
            if (Id != employer.EmployerId)
            {
                ModelState.AddModelError("", "Input Id and Company Id does not match");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _employerRepository.UpdateEmployer(employer);
            return NoContent();
        }



        [Authorize(Roles = "Admin, Employer")]
        [HttpPost]
        public IActionResult Create([FromBody] Employer employer)
        {
            if (ModelState.IsValid)
            {
                if (employer == null)
                {
                    ModelState.AddModelError("", "Employer cannot be empty");
                    return BadRequest(ModelState);
                }
                var company = _companyRepository.GetCompanies().
                    Where(a => a.CompanyName.Trim().ToLower() == employer.Company.CompanyName.Trim().ToLower()).FirstOrDefault();
                if (company != null)
                {
                    ModelState.AddModelError("", $"{employer.Company.CompanyName} already exist");
                    return StatusCode(422, ModelState);
                }

                _employerRepository.CreateEmployer(employer);

                return StatusCode(201);
            }
            return BadRequest(ModelState);

        }
    }
}
