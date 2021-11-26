using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public String Role { get; set; }
    }
}
