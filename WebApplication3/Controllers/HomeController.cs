using AspNet_Core.Models;
using AspNet_Core.Models.ViewModel;
using AspNet_Core.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ViewModel;

namespace AspNet_Core.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.EmployeeRepository.Filter(new EmployeeFilters() { });
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });

            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Employee employee = new Employee();

            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });

            return PartialView("_CreateEmployee", employee);
        }

        [HttpPost]
        public IActionResult Create(Employee Model)
        {
            if (ModelState.IsValid)
            {
                Employee NewEmployee = new Employee
                {
                    Name = Model.Name,
                    HireDate = Model.HireDate,
                    Salary = Model.Salary,
                    subSectionId = Model.subSectionId
                };
                _unitOfWork.EmployeeRepository.Add(NewEmployee);
                _unitOfWork.Complete();
                return PartialView("_Employees",_unitOfWork.EmployeeRepository.GetAll());
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.Get(id);
            int sectionid = _unitOfWork.SubSectionRepository.Get(employee.subSectionId).SectionId;
            var section = _unitOfWork.SectionRepository.Get(sectionid);
            var department = _unitOfWork.DepartmentRepository.Get(section.DepartmentId);

            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });
            ViewBag.Section = _unitOfWork.SectionRepository.Find(s => s.DepartmentId == department.ID).Select(d => new LookUp { Code = d.Id, Name = d.Name });
            ViewBag.SubSection = _unitOfWork.SubSectionRepository.Find(sub => sub.SectionId == sectionid).Select(d => new LookUp { Code = d.ID, Name = d.Name });


            return PartialView("_Edit", employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee Model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _unitOfWork.EmployeeRepository.Get(Model.ID);
                employee.Name = Model.Name;
                employee.HireDate = Model.HireDate;
                employee.Salary = Model.Salary;
                employee.subSectionId = Model.subSectionId;

                _unitOfWork.EmployeeRepository.Update(employee);
                _unitOfWork.Complete();
                return PartialView("_Employees", _unitOfWork.EmployeeRepository.GetAll());
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeFilter(EmployeeFilters employeeFilters)
        {
            IEnumerable<Employee> employees = _unitOfWork.EmployeeRepository.Filter(employeeFilters);

            return PartialView("_Employees", employees);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.EmployeeRepository.Delete(id);
            _unitOfWork.Complete();
            return PartialView("_Employees", _unitOfWork.EmployeeRepository.GetAll());
        }
    }
}
