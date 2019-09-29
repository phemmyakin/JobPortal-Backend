using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Employee 
    {
         [Key]
        public int EmployeeId { get; set; }

        public string Title { get; set; }

        public string Gender { get; set; }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public string State { get; set; }

        public string PhoneNumber { get; set; }

        public string AlternatePhoneNumber { get; set; }


        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string HighestQualification { get; set; }

        public string CurrentJob { get; set; }

        public string YearsOfExperience { get; set; }

        public string Avalability { get; set; }
        public string CV { get; set; }

    }
}
