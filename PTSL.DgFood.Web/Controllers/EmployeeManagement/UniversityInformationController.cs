using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class UniversityInformationController : Controller
    {
        private readonly IUniversityInformationService _UniversityInformationService;
        public readonly IModelStateValidation _ModelStateValidation;
        public UniversityInformationController()
        {
            _UniversityInformationService = new UniversityInformationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Category
        public ActionResult Index()
        {
            var returnResponse = _UniversityInformationService.List();
            return View(returnResponse.entity);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            UniversityInformationVM entity = new UniversityInformationVM();
       
            return View(entity);
        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(UniversityInformationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

        
                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }
        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DropdownController dc = new DropdownController();
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UniversityInformationVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(UniversityInformationController.Index), "Category");
                    }
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        // GET: Category/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _UniversityInformationService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Category deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UniversityInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(UniversityInformationController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse = _UniversityInformationService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}