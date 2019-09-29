<<<<<<< .mine
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
       public virtual ICollection<Employer> Employers{ get; set; }
       public virtual ICollection<Job> Jobs { get; set; }
    }
}

