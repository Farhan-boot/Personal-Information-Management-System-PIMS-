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
    public class WeeklyHolydaySetupController : Controller
    {
        private readonly IWeeklyHolydaySetupService _WeeklyHolydaySetupService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public WeeklyHolydaySetupController(): this(new WeeklyHolydaySetupService())
        //{
        //}
        public WeeklyHolydaySetupController()
        {
            _WeeklyHolydaySetupService = new WeeklyHolydaySetupService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: WeeklyHolydaySetup
        public ActionResult Index()
        {
            
            (ExecutionState executionState, List<WeeklyHolydaySetupVM> entity, string message) returnResponse = _WeeklyHolydaySetupService.List();
             return View(returnResponse.entity);
        }

        // GET: WeeklyHolydaySetup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: WeeklyHolydaySetup/Create
        public ActionResult Create()
        {
            DropdownController dc = new DropdownController();
            List<YearsVM> YearsList = dc.GetYears();
            ViewBag.YearsId = new SelectList(YearsList, "Id", "YearsName");
            var DayList = dc.GetDays();
            ViewBag.Day = new SelectList(DayList, "Id", "Name");

            WeeklyHolydaySetupVM entity = new WeeklyHolydaySetupVM();            
            return View(entity);
        }

        // POST: WeeklyHolydaySetup/Create
        [HttpPost]
        public ActionResult Create(WeeklyHolydaySetupVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<YearsVM> YearsList = dc.GetYears();
                ViewBag.YearsId = new SelectList(YearsList, "Id", "YearsName",entity.YearsId);
                List<DropdownVM> DayList = dc.GetDays();
                ViewBag.Day = new SelectList(DayList, "Id", "Name",entity.Day);

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.Create(entity);
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
        

        // GET: WeeklyHolydaySetup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.GetById(id);
            DropdownController dc = new DropdownController();
            List<YearsVM> YearsList = dc.GetYears();
            ViewBag.YearsId = new SelectList(YearsList, "Id", "YearsName", returnResponse.entity.YearsId);
            List<DropdownVM> DayList = dc.GetDays();
            ViewBag.Day = new SelectList(DayList, "Id", "Name", (int)returnResponse.entity.Day);
            return View(returnResponse.entity);
        }

        // POST: WeeklyHolydaySetup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WeeklyHolydaySetupVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<YearsVM> YearsList = dc.GetYears();
                ViewBag.YearsId = new SelectList(YearsList, "Id", "YearsName", entity.YearsId);
                List<DropdownVM> DayList = dc.GetDays();
                ViewBag.Day = new SelectList(DayList, "Id", "Name", entity.Day);
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(WeeklyHolydaySetupController.Index), "WeeklyHolydaySetup");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.Update(entity);
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

                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        // GET: WeeklyHolydaySetup/Delete/5
        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _WeeklyHolydaySetupService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "WeeklyHolydaySetup deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: WeeklyHolydaySetup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WeeklyHolydaySetupVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(WeeklyHolydaySetupController.Index), "WeeklyHolydaySetup");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) returnResponse = _WeeklyHolydaySetupService.Update(entity);
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
