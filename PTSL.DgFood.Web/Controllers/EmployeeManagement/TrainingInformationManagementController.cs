using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
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
    public class TrainingInformationManagementController : Controller
    {
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly ITrainingInformationManagementService _TrainingInformationManagementService;
        private readonly IDivisionService _DivisionService;
        private readonly ILeaveTypeInformationService _LeaveTypeInformationService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public TrainingInformationManagementController(): this(new TrainingInformationManagementService())
        //{
        //}
        public TrainingInformationManagementController()
        {
            _TrainingInformationManagementService = new TrainingInformationManagementService();
            _DivisionService = new DivisionService();
            _LeaveTypeInformationService = new LeaveTypeInformationService();
            _ModelStateValidation = new ModelStateValidation();
            _EmployeeInformationService = new EmployeeInformationService();
        }
        // GET: TrainingInformationManagement
        public ActionResult Index()
        {
            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) returnResponse = _TrainingInformationManagementService.List();
            return View(returnResponse.entity);
        }

        // GET: TrainingInformationManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: TrainingInformationManagement/Create
        public ActionResult Create()
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                ViewBag.DesignationId = new SelectList("");
                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");
                string RoleName = Session["RoleName"].ToString();
                if (RoleName == "Employee Group")
                {
                    EmployeeInformationVM filterData = new EmployeeInformationVM();
                    filterData.Email = Session["UserEmail"].ToString();
                    returnResponse = _EmployeeInformationService.EmployeeList();
                    returnResponse.entity = returnResponse.entity.Where(x => x.Email == filterData.Email).ToList();
                }
                else
                {
                    returnResponse = _EmployeeInformationService.EmployeeList();
                }

                if (returnResponse.entity != null)
                {
                    returnResponse.entity = returnResponse.entity.Take(10).OrderByDescending(x => x.Id).ToList();
                }

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {

            } 
            
            return View();
        }

        // POST: TrainingInformationManagement/Create
        [HttpPost]
        public ActionResult Create(TrainingInformationManagementVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.PromotionPartcularsRankId = new SelectList(returnRankResponse, "Id", "RankName",entity.RankId);
                ViewBag.DesignationId = new SelectList("");
                ICollection<DesignationVM> returnDesignationResponse = new List<DesignationVM>();
                if (entity.RankId != null)
                {
                    returnDesignationResponse = dc.GetDesignationByRankId((long)entity.RankId);
                    ViewBag.DesignationId = new SelectList(returnDesignationResponse, "Id", "DesignationName", entity.DesignationId);
                }
                

                if (ModelState.IsValid)
                { 
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    entity.Status = false;
                    

                    // TODO: Add insert logic here
                    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Create(entity);
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
                }
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }


        // GET: TrainingInformationManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.GetById(id);
            DropdownController dc = new DropdownController();
            List<RankVM> returnRankResponse = dc.GetRanks();
            ViewBag.PromotionPartcularsRankId = new SelectList(returnRankResponse, "Id", "RankName",returnResponse.entity.RankId);
            ViewBag.DesignationId = new SelectList("");
            ICollection<DesignationVM> returnDesignationResponse = new List<DesignationVM>();
            if (returnResponse.entity.RankId != null)
            {
                returnDesignationResponse = dc.GetDesignationByRankId((long)returnResponse.entity.RankId);
                ViewBag.DesignationId = new SelectList(returnDesignationResponse, "Id", "DesignationName",returnResponse.entity.DesignationId);
            }
            return View(returnResponse.entity);
        }

        // POST: TrainingInformationManagement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrainingInformationManagementVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.PromotionPartcularsRankId = new SelectList(returnRankResponse, "Id", "RankName", entity.RankId);
                ViewBag.DesignationId = new SelectList("");
                ICollection<DesignationVM> returnDesignationResponse = new List<DesignationVM>();
                if (entity.RankId != null)
                {
                    returnDesignationResponse = dc.GetDesignationByRankId((long)entity.RankId);
                    ViewBag.DesignationId = new SelectList(returnDesignationResponse, "Id", "DesignationName", entity.DesignationId);
                }
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingInformationManagementController.Index), "TrainingInformationManagement");
                    }

                    
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    
                    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(entity);
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

        // GET: TrainingInformationManagement/Delete/5
        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _TrainingInformationManagementService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Leave Application deleted Successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        //public JsonResult Approved(int id)
        //{ 
        //    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnTrainingInformationManagementnResponse = _TrainingInformationManagementService.GetById(id);

        //    returnTrainingInformationManagementnResponse.entity.LeaveStatus = LeaveStatus.Approved;
        //    returnTrainingInformationManagementnResponse.entity.ApprovedDate = DateTime.Now;
        //    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(returnTrainingInformationManagementnResponse.entity);
        //    if (returnResponse.executionState.ToString() == "Updated")
        //    {
        //        returnResponse.message = "Leave Application Approved Successfully.";
        //    }
        //    return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        //    //return View();
        //}

        //public JsonResult Cancelled(int id)
        //{
             
        //    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnTrainingInformationManagementnResponse = _TrainingInformationManagementService.GetById(id);

        //    returnTrainingInformationManagementnResponse.entity.LeaveStatus = LeaveStatus.Cancelled;
        //    returnTrainingInformationManagementnResponse.entity.CancelledDate = DateTime.Now;
        //    (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(returnTrainingInformationManagementnResponse.entity);
        //    if (returnResponse.executionState.ToString() == "Updated")
        //    {
        //        returnResponse.message = "Leave Application Cancelled Successfully.";
        //    }
        //    return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        //    //return View();
        //}

        // POST: TrainingInformationManagement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingInformationManagementVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(TrainingInformationManagementController.Index), "TrainingInformationManagement");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(entity);
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

        public JsonResult Approve(int id)
		{
			(ExecutionState executionState, TrainingInformationManagementVM entity, string message) response = _TrainingInformationManagementService.GetById(id);

			response.entity.ApprovalStatus = TrainingInformationManagementApprovalStatus.Approved;
			response.entity.UpdatedAt = DateTime.Now;

			(ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(response.entity);
			if (returnResponse.executionState == ExecutionState.Updated)
			{
				returnResponse.message = "Training Application Approved Successfully.";
			}
			return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
		}

        public JsonResult Reject(int id)
		{
			(ExecutionState executionState, TrainingInformationManagementVM entity, string message) response = _TrainingInformationManagementService.GetById(id);

			response.entity.ApprovalStatus = TrainingInformationManagementApprovalStatus.Rejected;
			response.entity.UpdatedAt = DateTime.Now;

			(ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse = _TrainingInformationManagementService.Update(response.entity);
			if (returnResponse.executionState == ExecutionState.Updated)
			{
				returnResponse.message = "Training Application Rejected Successfully.";
			}
			return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
		}
    }
}