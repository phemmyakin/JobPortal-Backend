using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public Company Company { get; set; }
    }
}
