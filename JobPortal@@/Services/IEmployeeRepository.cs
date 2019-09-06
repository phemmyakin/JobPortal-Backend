using JobPortal2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        bool EmployeeExists(int employeeId);

    }
}
