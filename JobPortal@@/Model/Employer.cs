using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Employer: IdentityUser
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName {get; set;}
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
         
    }
}
