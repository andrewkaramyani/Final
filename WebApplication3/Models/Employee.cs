using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        [ForeignKey("SubSection")]
        public int subSectionId { get; set; }
        public SubSection SubSection { get; set; }


    }
}
