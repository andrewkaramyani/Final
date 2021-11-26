using AspNet_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Repository;

namespace AspNet_Core.Models
{
    public class DepartmentReository : Repository<Department>, IDepartmentReository
    {
        public DepartmentReository(AppDbContext context) : base(context)
        {
        }
        public AppDbContext Context
        {
            get { return Context as AppDbContext; }
        }
    }
}
