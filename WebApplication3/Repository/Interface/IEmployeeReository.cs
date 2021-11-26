using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication3.Repository;
using WebApplication3.ViewModel;

namespace AspNet_Core.Models
{
    public interface IEmployeeReository : IRepository<Employee>
    {
        IEnumerable<Employee> Filter(EmployeeFilters employeeFilters);
    }
}
