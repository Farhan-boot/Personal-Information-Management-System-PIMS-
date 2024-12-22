using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DegreeController : Controller
    {
        private readonly IDegreeService _DegreeService;
        private readonly IDivisionService _DivisionService;
        private readonly IEducationalQualificationService _EducationalQualificationService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public DegreeController(): this(new DegreeService())
        //{
        //}
        public DegreeController()
        {
            _DegreeService = new DegreeService();
            _DivisionService = new DivisionService();
            _EducationalQualificationService = new EducationalQualificationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Degree
        public ActionResult Index()
        {
            (ExecutionState executionState, List<DegreeVM> entity, string message) returnResponse = _DegreeService.List();
             return View(returnResponse.entity);
        }

        // GET: Degree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Degree/Create
        public ActionResult Create()
        {
            DegreeVM entity = new DegreeVM();
            return View(entity);
        }

        // POST: Degree/Create
        [HttpPost]
        public ActionResult Create(DegreeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.Create(entity);
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
        

        // GET: Degree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.GetById(id);
            
            return View(returnResponse.entity);
        }

        // POST: Degree/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DegreeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(DegreeController.Index), "Degree");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.Update(entity);
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

        // GET: Degree/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DegreeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Degree deleted successfully.";
            }

            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        //public bool IsExists(int id)
        //{
        //    (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.(id);
        //}

        // POST: Degree/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DegreeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DegreeController.Index), "Degree");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DegreeVM entity, string message) returnResponse = _DegreeService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                //return View(returnResponse.entity);
                // return RedirectToAction("Edit?id="+id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
