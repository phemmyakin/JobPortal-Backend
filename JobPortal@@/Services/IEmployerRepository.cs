using JobPortal2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Services
{
    public interface IEmployerRepository
    {
        IEnumerable<Employer> GetEmployers();
        Employer GetEmployer(int employerId);
        Employer CreateEmployer(Employer employer);
        void UpdateEmployer(Employer employer);

        bool EmployerExists(int employerId);
    }
}
