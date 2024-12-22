using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Implementation.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class PromotionManagementController : Controller
    {
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly IPromotionManagementService _PromotionManagementService;
        private readonly IPromotionPartcularsService _PromotionPartcularsService;
        private readonly IOfficialInformationService _OfficialInformationService;
        private readonly IOrganogramService _OrganogramService;
        private readonly IEmployeePostingDetailsService _EmployeePostingDetailsService;
        
        public PromotionManagementController()
        {
            _EmployeeInformationService = new EmployeeInformationService();
            _PromotionManagementService = new PromotionManagementService();
            _PromotionPartcularsService = new PromotionPartcularsService();
            _OfficialInformationService = new OfficialInformationService();
            _OrganogramService = new OrganogramService();
            _EmployeePostingDetailsService = new EmployeePostingDetailsService();
        }
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) returnResponse = _PromotionManagementService.PromotionList();
            return View(returnResponse.entity);

        }
        public ActionResult Create()
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                ViewBag.DesignationId = new SelectList("");
                List<PostingTypeVM> returnPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingTypeId = new SelectList(returnPostingTypeResponse, "Id", "PostingTypeName");
                List<PostingVM> returnPostingResponse = dc.GetPostings();
                ViewBag.PostingId = new SelectList(returnPostingResponse, "Id", "PostingName");
                List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
                ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
                List<DistrictVM> returnDistrictResponse = dc.GetDistricts();
                ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName");
                //List<PoliceStationVM> returnPoliceStationResponse = dc.Getpoli();
                ViewBag.PoliceStationId = new SelectList("");

                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");

                returnResponse.entity = new List<EmployeeInformationListVM>();



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
        [HttpPost]
        public ActionResult Create(EmployeeInformationFilterVM filterData)
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName", filterData.RankId);
                ViewBag.DesignationId = new SelectList("");
                if (filterData.RankId != null)
                {
                    ICollection<DesignationVM> returnDesignationResponse = dc.GetDesignationByRankId((long)filterData.RankId);
                    ViewBag.DesignationId = new SelectList(returnDesignationResponse, "Id", "DesignationName", filterData.DesignationId);
                }

                List<PostingTypeVM> returnPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingTypeId = new SelectList(returnPostingTypeResponse, "Id", "PostingTypeName", filterData.PostingTypeId);
                List<PostingVM> returnPostingResponse = dc.GetPostings();
                ViewBag.PostingId = new SelectList(returnPostingResponse, "Id", "PostingName", filterData.PostingId);
                List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
                ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName", filterData.DivisionId);
                List<DistrictVM> returnDistrictResponse = dc.GetDistricts();
                ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", filterData.DistrictId);

                ViewBag.PoliceStationId = new SelectList("");
                if (filterData.DistrictId > 0)
                {
                    ICollection<PoliceStationVM> returnPoliceStationResponse = dc.GetPoliceStationByDistrictId((long)filterData.DistrictId); //_DistrictService.List();
                    ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", filterData.PoliceStationId);


                }


                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");
                string RoleName = Session["RoleName"].ToString();

                returnResponse = _EmployeeInformationService.EmployeeListBySP(filterData);

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {

            }

            return View();
        }
        public ActionResult Edit(long id)
        {
            try
            {
                DropdownController dc = new DropdownController();

                (ExecutionState executionState, PromotionManagementVM entity, string message) returnPromotionInfo = _PromotionManagementService.GetById(id);

                List<RankVM> returnPromotionManagementRankResponse = dc.GetRanks();
                ViewBag.PromotionManagementRankId = new SelectList(returnPromotionManagementRankResponse, "Id", "RankName", returnPromotionInfo.entity.RankId);
                long RankID = returnPromotionInfo.entity.RankId != null ? Convert.ToInt64(returnPromotionInfo.entity.RankId) : 0;
                List<DesignationVM> returnPromotionManagementDesignationResponse = dc.GetDesignationByRankId(RankID);
                ViewBag.PromotionManagementDesignationId = new SelectList(returnPromotionManagementDesignationResponse, "Id", "DesignationName", returnPromotionInfo.entity.DesignationId);
                List<PromtionNatureVM> returnPromotionManagementNatureOfPromotionResponse = dc.GetNatureOfPromotions();
                ViewBag.PromotionManagementNatureOfPromotionId = new SelectList(returnPromotionManagementNatureOfPromotionResponse, "Id", "PromtionNatureName", returnPromotionInfo.entity.PromtionNatureId);
                List<PayScaleYearInfoVM> returnPromotionManagementYearOfPayScalesResponse = dc.GetYearOfPayScales();
                ViewBag.PromotionManagementYearOfPayScaleId = new SelectList(returnPromotionManagementYearOfPayScalesResponse, "Id", "PayScaleYearInfoName", returnPromotionInfo.entity.PayScaleYearInfoId);

                EmployeeInformationFilterVM employeeInformationFilterVM = new EmployeeInformationFilterVM();
                employeeInformationFilterVM.Id = returnPromotionInfo.entity.EmployeeInformationId;
                (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnEmployeeInfo = _EmployeeInformationService.EmployeeListBySP(employeeInformationFilterVM);
                ViewBag.EmployeeInfo = returnEmployeeInfo.entity.FirstOrDefault();

                return View(returnPromotionInfo.entity);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public JsonResult Submit(PromotionManagementVM promotionManagementVM)
        {
            bool success = false; string successtext = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    var employeeInfoId = promotionManagementVM.EmployeeInformationId;

                    var officialInfo = _OfficialInformationService.GetFilterData(new OfficialInformationFilterVM
                    {
                        EmployeeInformationId = employeeInfoId
                    });

                    if (officialInfo.entity == null)
                    {
                        return Json(new { success = success, responseText = "No official information found." }, JsonRequestBehavior.AllowGet);
                    }

                    // Taking the first official info
                    var officialInformation = officialInfo.entity.First();


                    

                    // Validate if designation is available start
                    var presentOrganogramOfficeType = OrganogramOfficeType.DGOfFood; //officialInformation.PresentOrganogramOfficeType;
                    var presentPostingId = officialInformation.PostingId;
                    var presentDesignationId = officialInformation.PresentDesignationId;
					var presentIsPermanent = officialInformation.IsPresentPostingPermanent;

                    var presentResult = _OrganogramService.GetOrganogramByPostDesignation(presentOrganogramOfficeType, presentPostingId, presentDesignationId, presentIsPermanent);
                    if (presentResult.entity != null)
                    {
                        if (presentResult.entity.TotalPost <= 0)
                        {
                            return Json(new { success = false, responseText = "Selected present posting does not have any available empty post." }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "No organogram found for this designation and posting." }, JsonRequestBehavior.AllowGet);
                    }
                    // Validate if designation is available end

                    if (promotionManagementVM.Id > 0)
                    {
                        promotionManagementVM.IsActive = true;
                        promotionManagementVM.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse = _PromotionManagementService.Update(promotionManagementVM);
                        if (returnResponse.executionState.ToString() != "Updated")
                        {
                            successtext = "Data update failed";
                        }
                        else
                        {
                            success = true;
                            successtext = "Data update successfully";
                        }
                    }
                    else
                    {
                        promotionManagementVM.IsActive = true;
                        promotionManagementVM.CreatedAt = DateTime.Now;
                        (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse = _PromotionManagementService.Create(promotionManagementVM);
                        if (returnResponse.executionState.ToString() != "Created")
                        {
                            successtext = "Data save failed";
                        }
                        else
                        {
                            success = true;
                            successtext = "Data save successfully";
                        }
                    }

                }
            }
            catch
            {
                successtext = "Something went wrong";
            }
            return Json(new { success = success, responseText = successtext }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult PromotionFormPartial(long id)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnPromotionManagementRankResponse = dc.GetRanks();
                ViewBag.PromotionManagementRankId = new SelectList(returnPromotionManagementRankResponse, "Id", "RankName");
                ViewBag.PromotionManagementDesignationId = new SelectList("");
                List<PromtionNatureVM> returnPromotionManagementNatureOfPromotionResponse = dc.GetNatureOfPromotions();
                ViewBag.PromotionManagementNatureOfPromotionId = new SelectList(returnPromotionManagementNatureOfPromotionResponse, "Id", "PromtionNatureName");
                List<PayScaleYearInfoVM> returnPromotionManagementYearOfPayScalesResponse = dc.GetYearOfPayScales();
                ViewBag.PromotionManagementYearOfPayScaleId = new SelectList(returnPromotionManagementYearOfPayScalesResponse, "Id", "PayScaleYearInfoName");

                EmployeeInformationFilterVM employeeInformationFilterVM = new EmployeeInformationFilterVM();
                employeeInformationFilterVM.Id = id;
                (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnEmployeeInfo = _EmployeeInformationService.EmployeeListBySP(employeeInformationFilterVM);
                EmployeeInformationListVM employeeInformationListVM = new EmployeeInformationListVM();
                employeeInformationListVM = returnEmployeeInfo.entity.FirstOrDefault();
                return PartialView(employeeInformationListVM);
            }
            catch (Exception ex)
            {

            }
            return PartialView(null);
        }

        public PartialViewResult PromotionHistoryPartial(long EmployeeInformationId)
        {
            try
            {
                PromotionPartcularsFilterVM entity = new PromotionPartcularsFilterVM();
                entity.EmployeeInformationId = EmployeeInformationId;
                (ExecutionState executionState, IList<PromotionParticularsListVM> entity, string message) returnResponse = _PromotionPartcularsService.GetFilterData(entity);

                EmployeeInformationFilterVM employeeInformationFilterVM = new EmployeeInformationFilterVM();
                employeeInformationFilterVM.Id = EmployeeInformationId;
                (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnEmployeeInfo = _EmployeeInformationService.EmployeeListBySP(employeeInformationFilterVM);
                ViewBag.EmployeeInfo = returnEmployeeInfo.entity.FirstOrDefault();

                return PartialView(returnResponse.entity);
            }
            catch (Exception ex)
            {

            }
            return PartialView(null);
        }
    }
}