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
    public class PoliceStationController : Controller
    {
        private readonly IPoliceStationService _PoliceStationService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PoliceStationController(): this(new PoliceStationService())
        //{
        //}
        public PoliceStationController()
        {
            _PoliceStationService = new PoliceStationService();
            _DistrictService = new DistrictService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PoliceStation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PoliceStationVM> entity, string message) returnResponse = _PoliceStationService.List();
             return View(returnResponse.entity);
        }

        // GET: PoliceStation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: PoliceStation/Create
        public ActionResult Create()
        {
            PoliceStationVM entity = new PoliceStationVM();
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnResponse = _DistrictService.List();
            ViewBag.DistrictId = new SelectList(returnResponse.entity, "Id", "DistrictName");
            return View(entity);
        }

        // POST: PoliceStation/Create
        [HttpPost]
        public ActionResult Create(PoliceStationVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DistrictVM> entity, string message) DistrictLists = _DistrictService.List();

                ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", entity.DistrictId);
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", entity.DistrictId);
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

        // GET: PoliceStation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.GetById(id);
            (ExecutionState executionState, List<DistrictVM> entity, string message) DistrictLists = _DistrictService.List();

            ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", returnResponse.entity.DistrictId);

            return View(returnResponse.entity);
        }

        // POST: PoliceStation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PoliceStationVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DistrictVM> entity, string message) DistrictLists = _DistrictService.List();

                ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", entity.DistrictId);
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(PoliceStationController.Index), "PoliceStation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", returnResponse.entity.DistrictId);
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

        // GET: PoliceStation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _PoliceStationService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }

            (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PoliceStation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PoliceStation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PoliceStationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PoliceStationController.Index), "PoliceStation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PoliceStationVM entity, string message) returnResponse = _PoliceStationService.Update(entity);
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
