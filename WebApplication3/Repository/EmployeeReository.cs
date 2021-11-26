using AspNet_Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication3.Repository;
using WebApplication3.ViewModel;

namespace AspNet_Core.Models
{
    public class EmployeeReository : Repository<Employee>,IEmployeeReository
    {
        public EmployeeReository(AppDbContext context) : base(context)
        {
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
        public IEnumerable<Employee> Filter(EmployeeFilters employeeFilters)
        {
            var e= AppContext.employee.Include(e => e.SubSection).ThenInclude(s => s.Section).ThenInclude(d => d.Department).Where(
            emp => ( ((employeeFilters.Department == -1) ? true : employeeFilters.Department == emp.SubSection.Section.DepartmentId)
              && ((employeeFilters.Section == -1) ? true : employeeFilters.Section == emp.SubSection.SectionId)
              && ((employeeFilters.SubSection == -1) ? true : employeeFilters.SubSection == emp.subSectionId)
              && ((string.IsNullOrWhiteSpace(employeeFilters.EmployeeName)) ? true : emp.Name.StartsWith(employeeFilters.EmployeeName))
              ));
            return e;
        }
    }
}
