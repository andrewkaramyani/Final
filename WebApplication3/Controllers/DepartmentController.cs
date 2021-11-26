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
    public class DepartmentController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.DepartmentRepository.GetAll();
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });

            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Department Department = _unitOfWork.DepartmentRepository.Get(id.Value);
            if (Department == null)
            {
                Response.StatusCode = 404;
                return View("DepartmentNotFound", id.Value);
            }
            return View(Department);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Department Department = new Department();
            return PartialView("_CreateDepartment", Department);
        }

        [HttpPost]
        public IActionResult Create(Department Model)
        {
            if (ModelState.IsValid)
            {
                Department NewDepartment = new Department
                {
                    Name = Model.Name,
                };
                _unitOfWork.DepartmentRepository.Add(NewDepartment);
                _unitOfWork.Complete();
                return PartialView("_Departments", _unitOfWork.DepartmentRepository.GetAll());
                //return RedirectToAction("details", new { id = NewDepartment.ID });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Department Department = _unitOfWork.DepartmentRepository.Get(id);
            return PartialView("_Edit", Department);
        }

        [HttpPost]
        public IActionResult Edit(Department Model)
        {
            if (ModelState.IsValid)
            {
                Department Department = _unitOfWork.DepartmentRepository.Get(Model.ID);
                Department.Name = Model.Name;
                _unitOfWork.DepartmentRepository.Update(Department);
                _unitOfWork.Complete();
                return PartialView("_Departments", _unitOfWork.DepartmentRepository.GetAll());
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.DepartmentRepository.Delete(id);
            _unitOfWork.Complete();
            return PartialView("_Departments", _unitOfWork.DepartmentRepository.GetAll());
        }  


    }
}
