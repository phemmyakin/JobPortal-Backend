﻿using JobPortal__.Data;
using JobPortal2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Company CompanyDetails(int companyId)
        {
            return _context.Companies.Where(c => c.CompanyId == companyId).FirstOrDefault();
        }

        public bool CompanyExist(int companyId)
        {
            return _context.Companies.Any(c => c.CompanyId == companyId);
        }

        public bool CompanyExist(string companyName)
        {
            return _context.Companies.Any(c => c.CompanyName == companyName);
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(c => c.CompanyName).ToList();
        }

        public ICollection<Job> GetJobs()
        {
            return _context.Jobs.OrderBy(c => c.JobTitle).ToList();
        }
    }
}
