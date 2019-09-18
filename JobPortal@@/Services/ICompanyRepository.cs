using JobPortal2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Services
{
    public interface ICompanyRepository
    {
        bool CompanyExist(int CompanyId);
        bool CompanyExist(string CompanyName);
        ICollection<Company> GetCompanies();
    }
}
