using JobPortal__.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Role
    {
        public const string Admin = "Admin";
        public const string Company = "Company";
        public const string JobSeeker = "JobSeeker";
        public const string Employer = "Employer";
    }




       
}
