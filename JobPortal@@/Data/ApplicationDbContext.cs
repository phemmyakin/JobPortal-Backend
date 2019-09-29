using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal2.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal__.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

           
    }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        //public virtual DbSet<EmployerCompany> EmployerCompanies { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
    }
}
