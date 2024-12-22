using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using Microsoft.Ajax.Utilities;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
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

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class LeaveApplicationController : Controller
    {
        private readonly ILeaveApplicationService _LeaveApplicationService;
        private readonly IDivisionService _DivisionService;
        private readonly ILeaveTypeInformationService _LeaveTypeInformationService;
        public readonly IModelStateValidation _ModelStateValidation;
        public readonly IEmployeeInformationService _EmployeeInformationService;
        //public LeaveApplicationController(): this(new LeaveApplicationService())
        //{
        //}
        public LeaveApplicationController()
        {
            _LeaveApplicationService = new LeaveApplicationService();
            _DivisionService = new DivisionService();
            _LeaveTypeInformationService = new LeaveTypeInformationService();
            _ModelStateValidation = new ModelStateValidation();
            _EmployeeInformationService = new EmployeeInformationService();

		}
        // GET: LeaveApplication
        public ActionResult Index()
        {
            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnResponse = _LeaveApplicationService.List();
            return View(returnResponse.entity);
        }

        // GET: LeaveApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.GetById(id);
            return View(returnResponse.entity);
        }
        // GET: LeaveApplication/LeaveApplicationDetails/5
        public PartialViewResult LeaveApplicationDetailsPartial(int? id)
        {
            if (id == null)
            {
                return PartialView(null);
            }
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.GetById(id);
            return PartialView(returnResponse.entity);
        }
        // GET: LeaveApplication/Create
        public ActionResult Create()
        {
            DropdownController dc = new DropdownController();
            List<LeaveTypeInformationVM> LeaveTypeInformationList = dc.GetLeaveTypeInformations();
            ViewBag.LeaveTypeInformationId = new SelectList(LeaveTypeInformationList, "Id", "NameInEnglish");
            
            List<EmployeeInformationVM> EmployeeInfoList = dc.GetEmployees();
            ViewBag.EmployeeInformationId = new SelectList(EmployeeInfoList, "Id", "NameEnglish");
            LeaveApplicationVM entity = new LeaveApplicationVM();
            return View(entity);
        }

        // POST: LeaveApplication/Create
        [HttpPost]
        public ActionResult Create(LeaveApplicationVM entity)
        {
			var employeeIdString = Session["EmployeeInformationId"].ToString();
			long.TryParse(employeeIdString, out var employeeId);
			var hasEmployee = employeeId != 0;

			try
			{
				DropdownController dc = new DropdownController();
                List<LeaveTypeInformationVM> LeaveTypeInformationList = dc.GetLeaveTypeInformations();
                ViewBag.LeaveTypeInformationId = new SelectList(LeaveTypeInformationList, "Id", "NameInEnglish",entity.LeaveTypeInformationId);
                List<EmployeeInformationVM> EmployeeInfoList = dc.GetEmployees();
                ViewBag.EmployeeInformationId = new SelectList(EmployeeInfoList, "Id", "NameEnglish", entity.EmployeeInformationId);
                //var LeaveStatusList = dc.GetLeaveStatus();
                //ViewBag.EmployeeInformationId = new SelectList(LeaveStatusList, "Id", "Name", (int)entity.LeaveStatus);
                if (ModelState.IsValid)
                {
                    
                    (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnLeaveTypeInformationResponse = _LeaveTypeInformationService.GetById(entity.LeaveTypeInformationId);
                    int maxDayPerYear = returnLeaveTypeInformationResponse.entity.MaxDaysPerYear;

                    (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnLeaveApplicationResponse = _LeaveApplicationService.GetFilterData(entity);
                    //int maxDayPerYear = returnLeaveTypeInformationResponse.entity.MaxDaysPerYear;
                    int leaveUsedDays = 0;
                    if(returnLeaveApplicationResponse.entity != null)
                    {
                        leaveUsedDays = returnLeaveApplicationResponse.entity.Where(x=>x.LeaveTypeInformationId == entity.LeaveTypeInformationId && x.LeaveStatus == LeaveStatus.Approved).Sum(x => x.LeaveDays);
                        var LeaveExistsOrNot = returnLeaveApplicationResponse.entity.Where(x => Convert.ToDateTime(x.FromDate.Date) >= Convert.ToDateTime(entity.FromDate.Date) && Convert.ToDateTime(x.ToDate.Date) <= Convert.ToDateTime(entity.ToDate.Date)).ToList();
                        if (LeaveExistsOrNot.Count() > 0)
                        {
                            Session["Message"] = "Failed, This Date Already Exists.";
                            Session["executionState"] = 0;
                            if (hasEmployee) return View("NewApplication.cshtml", entity);
                            else return View(entity);
                        }
                    }

                    
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    entity.LeaveStatus = LeaveStatus.Pending;
                    DateTime d1 = entity.FromDate;
                    DateTime d2 = entity.ToDate;

                    TimeSpan t = d2 - d1;
                    int NoOfDays = Convert.ToInt32(t.TotalDays) + 1;
                    entity.LeaveDays = NoOfDays;

                    if (maxDayPerYear < (leaveUsedDays + entity.LeaveDays))
                    {
                        Session["Message"] = "Failed, You have Remaining " + (maxDayPerYear - leaveUsedDays) + " Days Leave";
                        Session["executionState"] = 0;
						if (hasEmployee) return View("NewApplication.cshtml", entity);
						else return View(entity);
					}

					// TODO: Add insert logic here
					(ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
						if (hasEmployee) return View("NewApplication.cshtml", entity);
						else return View(entity);
                    }
                    else
                    {
						if (hasEmployee) return RedirectToAction("EmployeeIndex");
						else return RedirectToAction("Index");
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
				if (hasEmployee) return View("NewApplication.cshtml", entity);
				else return View(entity);
			}
			catch
            {
				if (hasEmployee) return View("NewApplication.cshtml", entity);
				else return View(entity);
            }
        }


        // GET: LeaveApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.GetById(id);
            DropdownController dc = new DropdownController();
            List<LeaveTypeInformationVM> LeaveTypeInformationList = dc.GetLeaveTypeInformations();
            ViewBag.LeaveTypeInformationId = new SelectList(LeaveTypeInformationList, "Id", "NameInEnglish", returnResponse.entity.LeaveTypeInformationId);
            List<EmployeeInformationVM> EmployeeInfoList = dc.GetEmployees();
            ViewBag.EmployeeInformationId = new SelectList(EmployeeInfoList, "Id", "NameEnglish", returnResponse.entity.EmployeeInformationId);

            return View(returnResponse.entity);
        }

        // POST: LeaveApplication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LeaveApplicationVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<LeaveTypeInformationVM> LeaveTypeInformationList = dc.GetLeaveTypeInformations();
                ViewBag.LeaveTypeInformationId = new SelectList(LeaveTypeInformationList, "Id", "NameInEnglish", entity.LeaveTypeInformationId);
                List<EmployeeInformationVM> EmployeeInfoList = dc.GetEmployees();
                ViewBag.EmployeeInformationId = new SelectList(EmployeeInfoList, "Id", "NameEnglish", entity.EmployeeInformationId);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(LeaveApplicationController.Index), "LeaveApplication");
                    }

                    (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnLeaveTypeInformationResponse = _LeaveTypeInformationService.GetById(entity.LeaveTypeInformationId);
                    int maxDayPerYear = returnLeaveTypeInformationResponse.entity.MaxDaysPerYear;

                    (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnLeaveApplicationResponse = _LeaveApplicationService.GetFilterData(entity);
                    //int maxDayPerYear = returnLeaveTypeInformationResponse.entity.MaxDaysPerYear;
                    int leaveUsedDays = 0;
                    if (returnLeaveApplicationResponse.entity != null)
                    {
                        leaveUsedDays = returnLeaveApplicationResponse.entity.Where(x => x.Id != entity.Id && x.LeaveTypeInformationId == entity.LeaveTypeInformationId && x.LeaveStatus == LeaveStatus.Approved).Sum(x => x.LeaveDays);
                        var LeaveExistsOrNot = returnLeaveApplicationResponse.entity.Where(x =>x.Id != entity.Id && Convert.ToDateTime(x.FromDate.Date) >= Convert.ToDateTime(entity.FromDate.Date) && Convert.ToDateTime(x.ToDate.Date) <= Convert.ToDateTime(entity.ToDate.Date)).ToList();
                        if (LeaveExistsOrNot.Count() > 0)
                        {
                            Session["Message"] = "Failed, This Date Already Exists.";
                            Session["executionState"] = 0;
                            return View(entity);
                        }
                    }

                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    DateTime d1 = entity.FromDate;
                    DateTime d2 = entity.ToDate;

                    TimeSpan t = d2 - d1;
                    int NoOfDays = Convert.ToInt32(t.TotalDays) + 1;
                    entity.LeaveDays = NoOfDays;
                    if (maxDayPerYear < (leaveUsedDays + entity.LeaveDays))
                    {
                        Session["Message"] = "Faild, You have Remaining " + (maxDayPerYear - leaveUsedDays) + " Days Leave";
                        Session["executionState"] = 0;
                        return View(entity);
                    }
                    (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Update(entity);
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
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveApplication/Delete/5
        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _LeaveApplicationService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Leave Application deleted Successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public JsonResult Approved(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _LeaveApplicationService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnLeaveApplicationnResponse = _LeaveApplicationService.GetById(id);

            returnLeaveApplicationnResponse.entity.LeaveStatus = LeaveStatus.Approved;
            returnLeaveApplicationnResponse.entity.ApprovedDate = DateTime.Now;
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Update(returnLeaveApplicationnResponse.entity);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Leave Application Approved Successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public JsonResult Cancelled(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _LeaveApplicationService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnLeaveApplicationnResponse = _LeaveApplicationService.GetById(id);

            returnLeaveApplicationnResponse.entity.LeaveStatus = LeaveStatus.Cancelled;
            returnLeaveApplicationnResponse.entity.CancelledDate = DateTime.Now;
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Update(returnLeaveApplicationnResponse.entity);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Leave Application Cancelled Successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: LeaveApplication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LeaveApplicationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(LeaveApplicationController.Index), "LeaveApplication");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse = _LeaveApplicationService.Update(entity);
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

        public ActionResult NewApplication()
        {
            var employeeIdString = Session["EmployeeInformationId"].ToString();
            long.TryParse(employeeIdString, out var employeeId);

            if (employeeId == 0)
            {
                Session["Message"] = "Admin are not access this page";
                Session["executionState"] = 0;
                return RedirectToAction("EmployeeIndex", "LeaveApplication");
            }
      
    
            var dc = new DropdownController();
            var leaveTypeInformationList = dc.GetLeaveTypeInformations();
            ViewBag.LeaveTypeInformationId = new SelectList(leaveTypeInformationList, "Id", "NameInEnglish");

            var employee = _EmployeeInformationService.GetById(employeeId);
            ViewBag.EmployeeInformationId = new SelectList(new List<EmployeeInformationVM>() { employee.entity }, "Id", "NameEnglish", employeeId);

            return View(new LeaveApplicationVM());
        }

		public ActionResult EmployeeIndex()
		{
            var employeeIdString = Session["EmployeeInformationId"].ToString();
            long.TryParse(employeeIdString, out var employeeId);

            if (employeeId == 0) return View(new List<LeaveApplicationVM>());

			(ExecutionState executionState, List<LeaveApplicationVM> entity, string message) result = _LeaveApplicationService.GetFilterData(new LeaveApplicationVM
            {
                EmployeeInformationId = employeeId
            });
			return View(result.entity);
		}
	}
}