using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().HasData(
                new User {ID=1,UserName="Ahmed",Password="Ahmed",Role="Admin" },
                new User {ID=2,UserName="Andrew",Password= "Andrew", Role= "Viewer" },
                new User {ID=3,UserName="John",Password= "John", Role= "Contributor" }
                );
            modelBuilder.Entity<Department>().HasData(
               new Department {ID=1, Name = "IT" }
               );
        }
    }
}
