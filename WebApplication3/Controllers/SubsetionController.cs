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
    public class SubSectionController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SubSectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.SubSectionRepository.GetAll();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            SubSection SubSection = _unitOfWork.SubSectionRepository.Get(id.Value);
            if (SubSection == null)
            {
                Response.StatusCode = 404;
                return View("SubSectionNotFound", id.Value);
            }
            return View(SubSection);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SubSection SubSection = new SubSection();
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });
            return PartialView("_CreateSubSection", SubSection);
        }

        [HttpPost]
        public IActionResult Create(SubSection Model)
        {
            if (ModelState.IsValid)
            {
                SubSection NewSubSection = new SubSection
                {
                    Name = Model.Name,
                    SectionId = Model.SectionId
                };
                _unitOfWork.SubSectionRepository.Add(NewSubSection);
                _unitOfWork.Complete();
                return PartialView("_SubSections", _unitOfWork.SubSectionRepository.GetAll());
                //return RedirectToAction("details", new { id = NewSubSection.ID });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            SubSection SubSection = _unitOfWork.SubSectionRepository.Get(id);
            SubSection.Section= _unitOfWork.SectionRepository.Get(SubSection.SectionId);
            EditSub editSub = new EditSub() { ID = SubSection.ID, Name = SubSection.Name, SectionId = SubSection.SectionId, DepartmentId = SubSection.Section.DepartmentId };
            ViewBag.Department = _unitOfWork.DepartmentRepository.GetAll().Select(d => new LookUp { Code = d.ID, Name = d.Name });
            ViewBag.Section = _unitOfWork.SectionRepository.GetAll().Select(d => new LookUp { Code = d.Id, Name = d.Name });
            return PartialView("_Edit", editSub);
        }

        [HttpPost]
        public IActionResult Edit(EditSub Model)
        {
            if (ModelState.IsValid)
            {
                SubSection SubSection = _unitOfWork.SubSectionRepository.Get(Model.ID);
                SubSection.Name = Model.Name;
                SubSection.SectionId = Model.SectionId;
                _unitOfWork.SubSectionRepository.Update(SubSection);
                _unitOfWork.Complete();
                return PartialView("_SubSections", _unitOfWork.SubSectionRepository.GetAll());
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.SubSectionRepository.Delete(id);
            _unitOfWork.Complete();
            return PartialView("_SubSections", _unitOfWork.SubSectionRepository.GetAll());
        }

        [HttpGet]
        public JsonResult GetLookUps(int id)
        {
            return Json(_unitOfWork.SubSectionRepository.Find(s => s.SectionId == id).Select(d => new LookUp { Code = d.ID, Name = d.Name }));
        }
    }
}
