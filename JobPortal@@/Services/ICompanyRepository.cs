using JobPortal2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Services
{
    public interface ICompanyRepository
    {
        bool CompanyExist(int companyId);
        bool CompanyExist(string companyName);
        ICollection<Company> GetCompanies();

        ICollection<Job> GetJobs();
        Company CompanyDetails(int companyId);
    }
}
