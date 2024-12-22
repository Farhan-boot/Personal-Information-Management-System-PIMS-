using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Helper;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class LeaveTypeInformationController : Controller
    {
        private readonly ILeaveTypeInformationService _LeaveTypeInformationService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public LeaveTypeInformationController(): this(new LeaveTypeInformationService())
        //{
        //}
        public LeaveTypeInformationController()
        {
            _LeaveTypeInformationService = new LeaveTypeInformationService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: LeaveTypeInformation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<LeaveTypeInformationVM> entity, string message) returnResponse = _LeaveTypeInformationService.List();
             return View(returnResponse.entity);
        }

        // GET: LeaveTypeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: LeaveTypeInformation/Create
        public ActionResult Create()
        {
            DropdownController dc = new DropdownController();
            List<CalculationMethodVM> CalculationMethodsList = dc.GetCalculationMethods();
            ViewBag.CalculationMethodId = new SelectList(CalculationMethodsList, "Id", "CalculationMethodName");
            var EligibleForList = dc.GetEligibleFor();
            ViewBag.EligibleFor = new SelectList(EligibleForList, "Id", "Name");

            LeaveTypeInformationVM entity = new LeaveTypeInformationVM();            
            return View(entity);
        }

        // POST: LeaveTypeInformation/Create
        [HttpPost]
        public ActionResult Create(LeaveTypeInformationVM entity)
        {
            try
            {

                DropdownController dc = new DropdownController();
                List<CalculationMethodVM> CalculationMethodsList = dc.GetCalculationMethods();
                ViewBag.CalculationMethodId = new SelectList(CalculationMethodsList, "Id", "CalculationMethodName",entity.CalculationMethodId);
                var EligibleForList = dc.GetEligibleFor();
                ViewBag.EligibleFor = new SelectList(EligibleForList, "Id", "Name",entity.EligibleFor);
                const int MaxAnsiCode = 255;
                string nameBangla = entity.NameInBangla.Replace(" ", "");
                string nameEnglish = entity.NameInEnglish.Replace(" ", "");
                bool hasEnglishCharacterInBanglaName = nameBangla.Any(c => c < MaxAnsiCode);
                if(hasEnglishCharacterInBanglaName == true)
                {
                    Session["Message"] = "Bangla Name is Invalid !";
                    Session["executionState"] = ExecutionState.Failure;
                    return View(entity);
                }
                bool hasBanglaCharacterInEnglishName = nameEnglish.Any(c => c > MaxAnsiCode);
                if (hasBanglaCharacterInEnglishName == true)
                {
                    Session["Message"] = "English Name is Invalid !";
                    Session["executionState"] = ExecutionState.Failure;
                    return View(entity);
                }
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.Create(entity);
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
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                    Session["executionState"] = ExecutionState.Failure;
                    return View(entity);
                }
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }
        

        // GET: LeaveTypeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.GetById(id);
            DropdownController dc = new DropdownController();
            List<CalculationMethodVM> CalculationMethodsList = dc.GetCalculationMethods();
            ViewBag.CalculationMethodId = new SelectList(CalculationMethodsList, "Id", "CalculationMethodName", returnResponse.entity.CalculationMethodId);
            var EligibleForList = dc.GetEligibleFor();
            ViewBag.EligibleFor = new SelectList(EligibleForList, "Id", "Name", (int)returnResponse.entity.EligibleFor);

            return View(returnResponse.entity);
        }

        // POST: LeaveTypeInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LeaveTypeInformationVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<CalculationMethodVM> CalculationMethodsList = dc.GetCalculationMethods();
                ViewBag.CalculationMethodId = new SelectList(CalculationMethodsList, "Id", "CalculationMethodName", entity.CalculationMethodId);
                var EligibleForList = dc.GetEligibleFor();
                ViewBag.EligibleFor = new SelectList(EligibleForList, "Id", "Name", entity.EligibleFor);

                if (ModelState.IsValid)
                {
                    const int MaxAnsiCode = 255;
                    string nameBangla = entity.NameInBangla.Replace(" ", "");
                    string nameEnglish = entity.NameInEnglish.Replace(" ", "");
                    bool hasEnglishCharacterInBanglaName = nameBangla.Any(c => c < MaxAnsiCode);
                    if (hasEnglishCharacterInBanglaName == true)
                    {
                        Session["Message"] = "Bangla Name is Invalid !";
                        Session["executionState"] = ExecutionState.Failure;
                        return View(entity);
                    }
                    bool hasBanglaCharacterInEnglishName = nameEnglish.Any(c => c > MaxAnsiCode);
                    if (hasBanglaCharacterInEnglishName == true)
                    {
                        Session["Message"] = "English Name is Invalid";
                        Session["executionState"] = ExecutionState.Failure;
                        return View(entity);
                    }

                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(LeaveTypeInformationController.Index), "LeaveTypeInformation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.Update(entity);
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

        // GET: LeaveTypeInformation/Delete/5
        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _LeaveTypeInformationService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "LeaveTypeInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: LeaveTypeInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LeaveTypeInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(LeaveTypeInformationController.Index), "LeaveTypeInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse = _LeaveTypeInformationService.Update(entity);
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
