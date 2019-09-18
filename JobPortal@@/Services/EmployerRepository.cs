﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal__.Data;
using JobPortal2.Model;

namespace JobPortal2.Services
{
    public class EmployerRepository : IEmployerRepository
    {
        protected readonly ApplicationDbContext _context;

        public EmployerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employer CreateEmployer(Employer employer)
        {
            _context.Employers.Add(employer);
            _context.SaveChanges();
            return employer;
        }

        public Employer GetEmployer(int employerId)
        {
           return  _context.Employers.Where(e => e.EmployerId == employerId).FirstOrDefault();
            
        }

        public IEnumerable<Employer> GetEmployers()
        {
            return _context.Employers.ToList();
        }

        
        public void UpdateEmployer(Employer employer)
        {
            var user = _context.Employers.Find(employer.EmployerId);
            

            if (user == null)
                throw new Exception("User not found");
            user.FirstName = employer.FirstName;
            user.LastName = employer.LastName;
            user.Company = employer.Company;
            _context.Employers.Update(user);
            _context.SaveChanges();

        }

        public bool EmployerExists(int employerId)
        {
            return _context.Employers.Any(b => b.EmployerId== employerId);
        }
    }
}
