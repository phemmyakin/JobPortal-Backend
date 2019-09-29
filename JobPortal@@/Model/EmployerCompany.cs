using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class EmployerCompany
    {
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
