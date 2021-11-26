using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Repository;

namespace AspNet_Core.Models
{
    public interface IDepartmentReository : IRepository<Department>
    {
    }
}
