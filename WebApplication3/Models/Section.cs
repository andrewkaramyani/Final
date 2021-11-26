using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int  DepartmentId { get; set; }
        public Department  Department { get; set; }
        [JsonIgnore]
        public ICollection<SubSection> SubSections { get; set; }
    }
}
