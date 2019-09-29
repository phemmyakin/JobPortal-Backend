using JobPortal__.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Employer
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        //public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
