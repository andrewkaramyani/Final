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
    public class SectionController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.SectionRepository.GetAll();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Section Section = _unitOfWork.SectionRepository.Get(id.Value);
            if (Section == null)
            {
                Response.StatusCode = 404;
                return View("SectionNotFound", id.Value);
            }
            return View(Section);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Section Section = new Section();
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });
            return PartialView("_CreateSection", Section);
        }

        [HttpPost]
        public IActionResult Create(Section Model)
        {
            if (ModelState.IsValid)
            {
                Section NewSection = new Section
                {
                    Name = Model.Name,
                    DepartmentId=Model.DepartmentId
                };
                _unitOfWork.SectionRepository.Add(NewSection);
                _unitOfWork.Complete();
                return PartialView("_Sections", _unitOfWork.SectionRepository.GetAll());
                //return RedirectToAction("details", new { id = NewSection.ID });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Section Section = _unitOfWork.SectionRepository.Get(id);
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });
            return PartialView("_Edit", Section);
        }

        [HttpPost]
        public IActionResult Edit(Section Model)
        {
            if (ModelState.IsValid)
            {
                Section Section = _unitOfWork.SectionRepository.Get(Model.Id);
                Section.Name = Model.Name;
                Section.DepartmentId = Model.DepartmentId;
                _unitOfWork.SectionRepository.Update(Section);
                _unitOfWork.Complete();
                return PartialView("_Sections", _unitOfWork.SectionRepository.GetAll());
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.SectionRepository.Delete(id);
            _unitOfWork.Complete();
            return PartialView("_Sections", _unitOfWork.SectionRepository.GetAll());
        }

        [HttpGet]
        public JsonResult GetLookUps(int id)
        {
            return Json(_unitOfWork.SectionRepository.Find(s=>s.DepartmentId==id).Select(d => new LookUp { Code = d.Id, Name = d.Name }));
        }
    }
}
