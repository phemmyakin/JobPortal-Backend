using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal__.Data;
using JobPortal2.Model;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal2.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public bool EmployeeExists(int employeeId)
        {
            return _context.Employees.Any(b => b.EmployeeId == employeeId);
        }

        public Employee GetEmployee(int employeeId)
        {
            return _context.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();

            //var user = _context.Employees.Find(employee.EmployeeId);

            //if (user == null)
            //    return BadRequest(ModelState);


            //// update user properties

            //user.Address1 = employee.Address1;
            //user.Address2 = employee.Address2;
            ////user.AlternatePhoneNumber = employee.AlternatePhoneNumber;
            //user.Avalability = employee.Avalability;
            ////user.Country = employee.Country;
            //user.CurrentJob = employee.CurrentJob;
            //user.CV = employee.CV;
            ////user.DateOfBirth = employee.DateOfBirth;

            ////user.PhoneNumber = employee.PhoneNumber;
            ////user.State = employee.State;
            //user.HighestQualification = employee.HighestQualification;
            //user.YearsOfExperience = employee.YearsOfExperience;

            //_context.Employees.Update(user);
            //_context.SaveChanges();
        }
    }
}
