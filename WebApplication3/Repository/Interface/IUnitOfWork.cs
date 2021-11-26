using AspNet_Core.Data;
using AspNet_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeReository EmployeeRepository { get; }
        ISubSetionReository SubSectionRepository { get; }
        ISetionReository SectionRepository { get; }
        IDepartmentReository DepartmentRepository { get; }
        int Complete();
    }
}
