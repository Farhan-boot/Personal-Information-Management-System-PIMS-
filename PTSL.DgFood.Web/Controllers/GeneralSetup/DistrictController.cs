using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DistrictController : Controller
    {
        private readonly IDistrictService _DistrictService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public DistrictController(): this(new DistrictService())
        //{
        //}
        public DistrictController()
        {
            _DistrictService = new DistrictService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: District
        public ActionResult Index()
        {
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnResponse = _DistrictService.List();
             return View(returnResponse.entity);
        }

        // GET: District/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DistrictVM entity, string message) returnResponse = _DistrictService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: District/Create
        public ActionResult Create()
        {
            DistrictVM entity = new DistrictVM();
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList(returnResponse.entity, "Id", "DivisionName");
            return View(entity);
        }

        // POST: District/Create
        [HttpPost]
        public ActionResult Create(DistrictVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
                ViewBag.DivisionId = new SelectList(returnResponse.entity, "Id", "DivisionName");
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    (ExecutionState executionState, DistrictVM entity, string message) returnResponseCreate = _DistrictService.Create(entity);

                    if (returnResponseCreate.executionState.ToString() != "Created")
                    {
                        (ExecutionState executionState, List<DivisionVM> entity, string message) divisionLists = _DivisionService.List();

                        ViewBag.DivisionId = new SelectList(divisionLists.entity, "Id", "DivisionName", entity.DivisionId);
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

        // GET: District/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DistrictVM entity, string message) returnResponse = _DistrictService.GetById(id);
            (ExecutionState executionState, List<DivisionVM> entity, string message) divisionLists = _DivisionService.List();

            ViewBag.DivisionId = new SelectList(divisionLists.entity, "Id", "DivisionName", returnResponse.entity.DivisionId);

            return View(returnResponse.entity);
        }

        // POST: District/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DistrictVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DivisionVM> entity, string message) divisionLists = _DivisionService.List();
                ViewBag.DivisionId = new SelectList(divisionLists.entity, "Id", "DivisionName", entity.DivisionId);
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(DistrictController.Index), "District");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, DistrictVM entity, string message) returnResponse = _DistrictService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.DivisionId = new SelectList(divisionLists.entity, "Id", "DivisionName", returnResponse.entity.DivisionId);
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

        // GET: District/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DistrictService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, DistrictVM entity, string message) returnResponse = _DistrictService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "District deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: District/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DistrictVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DistrictController.Index), "District");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DistrictVM entity, string message) returnResponse = _DistrictService.Update(entity);
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
