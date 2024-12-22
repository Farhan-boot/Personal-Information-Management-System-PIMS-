using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class EmployeePostingDetailsController : Controller
    {
        private readonly IEmployeePostingDetailsService _EmployeePostingDetailsService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IOrganogramService _OrganogramService;
        public readonly IModelStateValidation _ModelStateValidation;
        private readonly IOfficialInformationService _OfficialInformationService;


        public EmployeePostingDetailsController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _EmployeePostingDetailsService = new EmployeePostingDetailsService();
            _OrganogramService = new OrganogramService();
            _ModelStateValidation = new ModelStateValidation();
            _OfficialInformationService = new OfficialInformationService();
        }
        // GET: EmployeePostingDetails
        public ActionResult Index()
        {
            (ExecutionState executionState, List<EmployeePostingDetailsVM> entity, string message) returnResponse = _EmployeePostingDetailsService.List();
            return View(returnResponse.entity);
        }

        
        // POST: EmployeePostingDetails/Create
        [HttpPost]
        public ActionResult Create(EmployeePostingDetailsVM entityVM)
        {
            try
            {
                if (entityVM.Id == 0)
                {
                    entityVM.IsActive = true;
                    entityVM.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse = _EmployeePostingDetailsService.Create(entityVM);

                    //old table insert start
                    var OfficialInformation = new OfficialInformationVM();
                    OfficialInformation.IsActive = true;
                    OfficialInformation.CreatedAt = DateTime.Now;
                    OfficialInformation.IsDeleted = false;
                    OfficialInformation.EmployeeInformationId = entityVM.EmployeeInformationId ?? 0;
                    OfficialInformation.FirstJoiningDate = entityVM.JoiningDate;
                    OfficialInformation.JoinPostingTypeId = entityVM.PostingTypeId;
                    OfficialInformation.JoinPostingId = entityVM.PostingId;
                    OfficialInformation.JoiningDesignationClassId = entityVM.DesignationClassId;
                    OfficialInformation.JoiningDesgId = entityVM.DesignationId;
                    OfficialInformation.CadreId = entityVM.CadreId;
                    OfficialInformation.CadreDate = DateTime.Now;
                    OfficialInformation.Batch = entityVM.Batch;
                    OfficialInformation.OrderNumber = entityVM.OrderNumber;
                    OfficialInformation.OrderDate = entityVM.OrderDate;
                    OfficialInformation.PresentJoinDate = DateTime.Now;
                    OfficialInformation.GradationNumber = entityVM.GradationNumber;
                    OfficialInformation.GradationTypeId = entityVM.GradationTypeId;
                    OfficialInformation.EmployeeTypeId = entityVM.EmployeeTypeId ?? 0;
                    OfficialInformation.JobCategoryId = entityVM.JobCategoryId;
                    OfficialInformation.Section = entityVM.Section;
                    OfficialInformation.SectionAt = entityVM.SectionAt;
                    OfficialInformation.PRLDate = entityVM.PRLDate;
                    OfficialInformation.JobPermanentDate = entityVM.JobPermanentDate ?? DateTime.Now;
                    OfficialInformation.Remarks = entityVM.Remarks;
                    OfficialInformation.GradationYear = entityVM.GradationYear;
                    OfficialInformation.JoiningRankId = entityVM.JoiningRankId;
                    OfficialInformation.PresentRankId = entityVM.JoiningRankId;
                    OfficialInformation.PresentDesignationClassId = entityVM.DesignationClassId;
                    OfficialInformation.PresentDesignationId = entityVM.DesignationId;
                    OfficialInformation.CrntDesgId = entityVM.DesignationId;
                    OfficialInformation.CurrDesignationClassId = entityVM.DesignationClassId;
                    OfficialInformation.PostResponsibilityId = entityVM.PostResponsibilityId;
                    OfficialInformation.RecruitPromoId = entityVM.RecruitPromoId;
                    OfficialInformation.PromtionNatureId = entityVM.PromtionNatureId;
                    OfficialInformation.PostingTypeId = entityVM.PostingTypeId ?? 0;
                    OfficialInformation.DeppostingTypeId = entityVM.DeppostingTypeId;
                    OfficialInformation.PostingId = entityVM.PostingId ?? 0;
                    OfficialInformation.DepPostingId = entityVM.PostingId;
                    OfficialInformation.JoinOrganogramOfficeType = 0;
                    OfficialInformation.PresentOrganogramOfficeType =0;
                    OfficialInformation.IsFirstJoiningPostPermanent = true;
                    OfficialInformation.IsPresentPostingPermanent = false;
                    OfficialInformation.CrntOrganogramOfficeType = 0;
                    OfficialInformation.IsCrntPostPermanent = true;
                    OfficialInformation.OfficeEmail = entityVM.OfficeEmail;
                    (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponseOfficialInformation = _OfficialInformationService.Create(OfficialInformation);
                    //old table insert end

                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    entityVM.IsActive = true;
                    entityVM.CreatedAt = DateTime.Now;
                    entityVM.UpdatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse = _EmployeePostingDetailsService.Update(entityVM);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetEmployeePostingDetailsByEmployeeInformationId(long employeeInformationId)
        {
           var listOfEmployeePostingDetails = _EmployeePostingDetailsService.List().entity.Where(x=>x.EmployeeInformationId == employeeInformationId).ToList();


            return Json(listOfEmployeePostingDetails, JsonRequestBehavior.AllowGet);
        }


        // GET: EmployeePostingDetails/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse = _EmployeePostingDetailsService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "EmployeePostingDetails deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }


        public JsonResult GetById(int id)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse = _EmployeePostingDetailsService.GetById(id);
            
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }




        //// POST: EmployeePostingDetails/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, EmployeePostingDetailsVM entity)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        if (id != entity.Id)
        //        {
        //            return RedirectToAction(nameof(EmployeePostingDetailsController.Index), "EmployeePostingDetails");
        //        }
        //        //entity.IsActive = true;
        //        entity.IsDeleted = true;
        //        entity.UpdatedAt = DateTime.Now;
        //        (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse = _EmployeePostingDetailsService.Update(entity);
        //        Session["Message"] = returnResponse.message;
        //        Session["executionState"] = returnResponse.executionState;
        //        //return View(returnResponse.entity);
        //        // return RedirectToAction("Edit?id="+id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}