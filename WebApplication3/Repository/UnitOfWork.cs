using AspNet_Core.Data;
using AspNet_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeReository(_context);
            SubSectionRepository = new SubSetionReository(_context);
            SectionRepository = new SetionReository(_context);
            DepartmentRepository = new DepartmentReository(_context);
        }
        public IEmployeeReository EmployeeRepository { get; private set; }

        public ISubSetionReository SubSectionRepository { get; private set; }

        public ISetionReository SectionRepository { get; private set; }

        public IDepartmentReository DepartmentRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
