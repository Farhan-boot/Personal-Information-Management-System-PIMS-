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
    public class GradationTypeController : Controller
    {
        private readonly IGradationTypeService _GradationTypeService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public GradationTypeController(): this(new GradationTypeService())
        //{
        //}
        public GradationTypeController()
        {
            _GradationTypeService = new GradationTypeService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: GradationType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<GradationTypeVM> entity, string message) returnResponse = _GradationTypeService.List();
             return View(returnResponse.entity);
        }

        // GET: GradationType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: GradationType/Create
        public ActionResult Create()
        {
            GradationTypeVM entity = new GradationTypeVM();            
            return View(entity);
        }

        // POST: GradationType/Create
        [HttpPost]
        public ActionResult Create(GradationTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.Create(entity);
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
        

        // GET: GradationType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: GradationType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GradationTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(GradationTypeController.Index), "GradationType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.Update(entity);
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

        // GET: GradationType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _GradationTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "GradationType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: GradationType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GradationTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(GradationTypeController.Index), "GradationType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, GradationTypeVM entity, string message) returnResponse = _GradationTypeService.Update(entity);
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
