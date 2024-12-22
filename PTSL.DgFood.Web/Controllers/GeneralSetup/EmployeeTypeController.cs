using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
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
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeService _EmployeeTypeService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public EmployeeTypeController(): this(new EmployeeTypeService())
        //{
        //}
        public EmployeeTypeController()
        {
            _EmployeeTypeService = new EmployeeTypeService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: EmployeeType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<EmployeeTypeVM> entity, string message) returnResponse = _EmployeeTypeService.List();
             return View(returnResponse.entity);
        }

        // GET: EmployeeType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: EmployeeType/Create
        public ActionResult Create()
        {
            EmployeeTypeVM entity = new EmployeeTypeVM();            
            return View(entity);
        }

        // POST: EmployeeType/Create
        [HttpPost]
        public ActionResult Create(EmployeeTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.Create(entity);
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
        

        // GET: EmployeeType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: EmployeeType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(EmployeeTypeController.Index), "EmployeeType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.Update(entity);
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

        // GET: EmployeeType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _EmployeeTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "EmployeeType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: EmployeeType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(EmployeeTypeController.Index), "EmployeeType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, EmployeeTypeVM entity, string message) returnResponse = _EmployeeTypeService.Update(entity);
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
