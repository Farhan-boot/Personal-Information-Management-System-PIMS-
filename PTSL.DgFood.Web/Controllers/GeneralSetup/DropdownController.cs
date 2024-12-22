using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DropdownController : Controller
    {
        private readonly IDivisionService _DivisionService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IDistrictService _DistrictService;
        private readonly IPoliceStationService _PoliceStationService;
        private readonly IDegreeService _DegreeService;
        private readonly IRankService _RankService;
        private readonly IDesignationClassService _DesignationClassService;
        private readonly IDesignationService _DesignationService;
        private readonly ICategoryService _CategoryService;
        private readonly IPresentStatusService _PresentStatusService;
        private readonly IPostingTypeService _PostingTypeService;
        private readonly IPostResponsibilityService _PostResponsibilityService;
        private readonly IPostingService _PostingService;
        private readonly IJobCategoryService _JobCategoryService;
        private readonly IEmployeeTypeService _EmployeeTypeService;
        private readonly IGradationTypeService _GradationTypeService;
        private readonly IPromtionNatureService _PromtionNatureService;
        private readonly IEmployeeStatusService _EmployeeStatusService;
        private readonly ILanguageService _LanguageService;
        private readonly IYearsService _YearsService;
        private readonly ICalculationMethodService _CalculationMethodService;
        private readonly ILeaveTypeInformationService _LeaveTypeInformationService;
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly ILeaveApplicationService _LeaveApplicationService;
        private readonly IPayScaleYearInfoService _PayScaleYearInfoService;
        private readonly ITrainingManagementTypeService _TrainingManagementTypeService;
        private readonly IUnionService _UnionService;
       
        public DropdownController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _UpazillaService = new UpazillaService();
            _PoliceStationService = new PoliceStationService();
            _DegreeService = new DegreeService();
            _RankService = new RankService();
            _DesignationClassService = new DesignationClassService();
            _DesignationService = new DesignationService();
            _CategoryService = new CategoryService();
            _PresentStatusService = new PresentStatusService();
            _PostingTypeService = new PostingTypeService();
            _PostResponsibilityService = new PostResponsibilityService();
            _PostingService = new PostingService();
            _JobCategoryService = new JobCategoryService();
            _EmployeeTypeService = new EmployeeTypeService();
            _GradationTypeService = new GradationTypeService();
            _PromtionNatureService = new PromtionNatureService();
            _EmployeeStatusService = new EmployeeStatusService();
            _LanguageService = new LanguageService();
            _YearsService = new YearsService();
            _CalculationMethodService = new CalculationMethodService();
            _LeaveTypeInformationService = new LeaveTypeInformationService();
            _EmployeeInformationService = new EmployeeInformationService();
            _LeaveApplicationService = new LeaveApplicationService();
            _PayScaleYearInfoService = new PayScaleYearInfoService();
            _TrainingManagementTypeService = new TrainingManagementTypeService();
            _UnionService = new UnionService();
        }

        public List<DivisionVM> GetDivisions()
        {
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnDivisionResponse = _DivisionService.List();
            if (returnDivisionResponse.entity == null)
            {
                List<DivisionVM> data = new List<DivisionVM>();
                return data;
            }
            return returnDivisionResponse.entity;

        }
        public List<DistrictVM> GetDistricts()
        {
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            if (returnDistrictResponse.entity == null)
            {
                List<DistrictVM> data = new List<DistrictVM>();
                return data;
            }
            return returnDistrictResponse.entity;

        }
        public List<CategoryVM> GetCategories()
        {
            (ExecutionState executionState, List<CategoryVM> entity, string message) returnCategoryResponse = _CategoryService.List();
            if (returnCategoryResponse.entity == null)
            {
                List<CategoryVM> data = new List<CategoryVM>();
                return data;
            }
            return returnCategoryResponse.entity;

        }
        public List<YearsVM> GetYears()
        {
            (ExecutionState executionState, List<YearsVM> entity, string message) returnYearsResponse = _YearsService.List();
            if (returnYearsResponse.entity == null)
            {
                List<YearsVM> data = new List<YearsVM>();
                return data;
            }
            return returnYearsResponse.entity;

        }
        public List<LeaveTypeInformationVM> GetLeaveTypeInformations()
        {
            (ExecutionState executionState, List<LeaveTypeInformationVM> entity, string message) returnResponse = _LeaveTypeInformationService.List();
            if (returnResponse.entity == null)
            {
                List<LeaveTypeInformationVM> data = new List<LeaveTypeInformationVM>();
                return data;
            }
            return returnResponse.entity;

        }
        public List<EmployeeInformationVM> GetEmployees()
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse = _EmployeeInformationService.GetEmployeeList();
            if (returnResponse.entity == null)
            {
                List<EmployeeInformationVM> data = new List<EmployeeInformationVM>();
                return data;
            }
            return returnResponse.entity;

        }
        public List<CalculationMethodVM> GetCalculationMethods()
        {
            (ExecutionState executionState, List<CalculationMethodVM> entity, string message) returnCalculationMethodResponse = _CalculationMethodService.List();
            if (returnCalculationMethodResponse.entity == null)
            {
                List<CalculationMethodVM> data = new List<CalculationMethodVM>();
                return data;
            }
            return returnCalculationMethodResponse.entity;

        }
        public List<PostResponsibilityVM> GetPostResponsibilities()
        {
            (ExecutionState executionState, List<PostResponsibilityVM> entity, string message) returnPostResponsibilityResponse = _PostResponsibilityService.List();
            if (returnPostResponsibilityResponse.entity == null)
            {
                List<PostResponsibilityVM> data = new List<PostResponsibilityVM>();
                return data;
            }
            return returnPostResponsibilityResponse.entity;

        }
        public List<PostingTypeVM> GetPostingTypes()
        {
            (ExecutionState executionState, List<PostingTypeVM> entity, string message) returnCategoryResponse = _PostingTypeService.List();
            if (returnCategoryResponse.entity == null)
            {
                List<PostingTypeVM> data = new List<PostingTypeVM>();
                return data;
            }
            return returnCategoryResponse.entity;

        }
        public List<PostingVM> GetPostingByPostingTypesId(long id)
        {
            List<PostingVM> postings = new List<PostingVM>();
            (ExecutionState executionState, PostingTypeVM entity, string message) returnPostingTypesResponse = _PostingTypeService.GetById(id);
            if (returnPostingTypesResponse.entity != null)
            {
                if (returnPostingTypesResponse.entity.PostingList != null)
                {

                    return returnPostingTypesResponse.entity.PostingList.ToList();
                }
            }

            return postings;
        }
        public List<DesignationClassVM> GetDesignationClasses()
        {
            (ExecutionState executionState, List<DesignationClassVM> entity, string message) returnCategoryResponse = _DesignationClassService.List();
            if (returnCategoryResponse.entity == null)
            {
                List<DesignationClassVM> data = new List<DesignationClassVM>();
                return data;
            }
            return returnCategoryResponse.entity;

        }

        public List<LanguageVM> GetLanguages()
        {
            (ExecutionState executionState, List<LanguageVM> entity, string message) returnResponse = _LanguageService.List();
            if (returnResponse.entity == null)
            {
                List<LanguageVM> data = new List<LanguageVM>();
                return data;
            }
            return returnResponse.entity;

        }

        public List<PresentStatusVM> GetPresentStatus()
        {
            (ExecutionState executionState, List<PresentStatusVM> entity, string message) returnPresentStatusResponse = _PresentStatusService.List();
            if (returnPresentStatusResponse.entity == null)
            {
                List<PresentStatusVM> data = new List<PresentStatusVM>();
                return data;
            }
            return returnPresentStatusResponse.entity;

        }
        public List<RankVM> GetRanks()
        {
            (ExecutionState executionState, List<RankVM> entity, string message) returnRankResponse = _RankService.List();
            if (returnRankResponse.entity == null)
            {
                List<RankVM> data = new List<RankVM>();
                return data;
            }
            return returnRankResponse.entity;

        }
        public List<DesignationVM> GetDesignationByRankId(long id)
        {
            List<DesignationVM> Designations = new List<DesignationVM>();
            (ExecutionState executionState, RankVM entity, string message) returnDesignationResponse = _RankService.GetById(id);
            if (returnDesignationResponse.entity != null)
            {
                if (returnDesignationResponse.entity.DesignationList != null)
                {
                    return returnDesignationResponse.entity.DesignationList.ToList();
                }
            }
            return Designations;
        }
        public List<DistrictVM> GetDistrictByDivisionId(long id)
        {
            List<DistrictVM> districts = new List<DistrictVM>();
            (ExecutionState executionState, DivisionVM entity, string message) returnDistrictResponse = _DivisionService.GetById(id);
            if (returnDistrictResponse.entity != null)
            {
                if (returnDistrictResponse.entity.DistrictList != null)
                {
                    return returnDistrictResponse.entity.DistrictList;
                }
            }

            return districts;
        }
        public ICollection<PoliceStationVM> GetPoliceStationByDistrictId(long id)
        {
            List<PoliceStationVM> ps = new List<PoliceStationVM>();
            (ExecutionState executionState, DistrictVM entity, string message) returnPoliceStationResponse = _DistrictService.GetById(id);
            if (returnPoliceStationResponse.entity != null)
            {
                if (returnPoliceStationResponse.entity.PoliceStationList != null)
                {
                    return returnPoliceStationResponse.entity.PoliceStationList;
                }
            }
            return ps;

        }
        public List<DesignationVM> GetDesignationByDesignationClassId(long id)
        {
            List<DesignationVM> ps = new List<DesignationVM>();
            (ExecutionState executionState, DesignationClassVM entity, string message) returnDesignationClassResponse = _DesignationClassService.GetById(id);
            if (returnDesignationClassResponse.entity != null)
            {
                if (returnDesignationClassResponse.entity.DesignationList != null)
                {
                    return returnDesignationClassResponse.entity.DesignationList.ToList();
                }
            }

            return ps;
        }
        public List<JobCategoryVM> GetJobCategories()
        {
            List<JobCategoryVM> ps = new List<JobCategoryVM>();
            (ExecutionState executionState, List<JobCategoryVM> entity, string message) returnJobCategoryResponse = _JobCategoryService.List();
            if (returnJobCategoryResponse.entity != null)
            {
                return returnJobCategoryResponse.entity;
            }

            return ps;
        }
        public List<EmployeeTypeVM> GetEmployeeTypes()
        {
            List<EmployeeTypeVM> ps = new List<EmployeeTypeVM>();
            (ExecutionState executionState, List<EmployeeTypeVM> entity, string message) returnEmployeeTypeResponse = _EmployeeTypeService.List();
            if (returnEmployeeTypeResponse.entity != null)
            {
                return returnEmployeeTypeResponse.entity;
            }

            return ps;
        }
        public List<GradationTypeVM> GetGradationTypess()
        {
            List<GradationTypeVM> ps = new List<GradationTypeVM>();
            (ExecutionState executionState, List<GradationTypeVM> entity, string message) returnGradationTypeResponse = _GradationTypeService.List();
            if (returnGradationTypeResponse.entity != null)
            {
                return returnGradationTypeResponse.entity;
            }

            return ps;
        }
        public List<DesignationVM> GetDesignations()
        {
            List<DesignationVM> ps = new List<DesignationVM>();
            (ExecutionState executionState, List<DesignationVM> entity, string message) returnDesignationResponse = _DesignationService.List();
            if (returnDesignationResponse.entity != null)
            {
                return returnDesignationResponse.entity;
            }

            return ps;
        }
        public List<PromtionNatureVM> GetPromotionNatures()
        {
            List<PromtionNatureVM> ps = new List<PromtionNatureVM>();
            (ExecutionState executionState, List<PromtionNatureVM> entity, string message) returnPromtionNatureVMResponse = _PromtionNatureService.List();
            if (returnPromtionNatureVMResponse.entity != null)
            {
                return returnPromtionNatureVMResponse.entity;
            }

            return ps;
        }
        public List<PostingVM> GetPostings()
        {
            List<PostingVM> ps = new List<PostingVM>();
            (ExecutionState executionState, List<PostingVM> entity, string message) returnPostingResponse = _PostingService.List();
            if (returnPostingResponse.entity != null)
            {
                return returnPostingResponse.entity;
            }

            return ps;
        }
        public List<EmployeeStatusVM> GetEmployeeStatus()
        {
            List<EmployeeStatusVM> ps = new List<EmployeeStatusVM>();
            (ExecutionState executionState, List<EmployeeStatusVM> entity, string message) returnEmployeeStatusResponse = _EmployeeStatusService.List();
            if (returnEmployeeStatusResponse.entity != null)
            {
                return returnEmployeeStatusResponse.entity;
            }

            return ps;
        }
        public List<TrainingManagementTypeVM> GetTrainingManagementTypes()
        {
            List<TrainingManagementTypeVM> ps = new List<TrainingManagementTypeVM>();
            (ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) returnTrainingManagementTypeResponse = _TrainingManagementTypeService.List();
            if (returnTrainingManagementTypeResponse.entity != null)
            {
                return returnTrainingManagementTypeResponse.entity;
            }

            return ps;
        }

        public ActionResult GetDesignationDropdownByRankId(long id)
        {
            (ExecutionState executionState, RankVM entity, string message) returnDesignationResponse = _RankService.GetById(id);
            if (returnDesignationResponse.entity.DesignationList == null)
            {
                List<DesignationVM> data = new List<DesignationVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnDesignationResponse.entity.DesignationList.Select(y => new { Id = y.Id, DesignationName = y.DesignationName });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetDesignationDropdownByRankAndDesignationClassId(long? rankId, long? designationClassId)
        {
            (ExecutionState executionState, List<DesignationVM> entity, string message) returnDesignationResponse = _DesignationService.GetByRankAndDesignationClassId(rankId, designationClassId);
            if (returnDesignationResponse.entity == null)
            {
                List<DesignationVM> data = new List<DesignationVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnDesignationResponse.entity.Select(y => new { Id = y.Id, DesignationName = y.DesignationName });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetDesignationDropdownByDesignationClassId(long id)
        {
            (ExecutionState executionState, DesignationClassVM entity, string message) returnDesignationClassResponse = _DesignationClassService.GetById(id);
            if (returnDesignationClassResponse.entity.DesignationList == null)
            {
                List<DesignationVM> data = new List<DesignationVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnDesignationClassResponse.entity.DesignationList.Select(y => new { Id = y.Id, DesignationName = y.DesignationName });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetPostingDropdownByPostingTypesId(long id)
        {
            (ExecutionState executionState, PostingTypeVM entity, string message) returnPostingTypesResponse = _PostingTypeService.GetById(id);
            if (returnPostingTypesResponse.entity.PostingList == null)
            {
                List<PostingVM> data = new List<PostingVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnPostingTypesResponse.entity.PostingList.Select(y => new { Id = y.Id, PostingName = y.PostingName });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetRemainingLeaveByLeaveTypeId(long LeaveTypeInformationId, long EmployeeInformationId)
        {
            int maxDayPerYear = 0;
            int leaveUsedDays = 0;
            int remainingLeave = 0;
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnLeaveTypeInformationResponse = _LeaveTypeInformationService.GetById(LeaveTypeInformationId);
            //if (returnPostingTypesResponse.entity == null)
            //{
            //    List<PostingVM> data = new List<PostingVM>();
            //    return Json(data, JsonRequestBehavior.AllowGet);
            //}
            if (returnLeaveTypeInformationResponse.entity != null)
            {
                maxDayPerYear = returnLeaveTypeInformationResponse.entity.MaxDaysPerYear;
            }
            LeaveApplicationVM entity = new LeaveApplicationVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnLeaveApplicationResponse = _LeaveApplicationService.GetFilterData(entity);

            if (returnLeaveApplicationResponse.entity != null)
            {
                leaveUsedDays = returnLeaveApplicationResponse.entity.Where(x => x.LeaveTypeInformationId == LeaveTypeInformationId && x.LeaveStatus == LeaveStatus.Approved).Sum(x => x.LeaveDays);
            }
            remainingLeave = maxDayPerYear - leaveUsedDays;
            return Json(remainingLeave, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetDistrictDropdownByDivisionId(long divisionId)
        {

            (ExecutionState executionState, DivisionVM entity, string message) returnDivisionResponse = _DivisionService.GetById(divisionId);
            if (returnDivisionResponse.entity.DistrictList == null)
            {
                List<DistrictVM> data = new List<DistrictVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnDivisionResponse.entity.DistrictList.Select(y => new { Id = y.Id, DistrictName = y.DistrictName });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUpazillaDropdownByDistrictId(long districtId)
        {
            (ExecutionState executionState, DistrictVM entity, string message) returnDivisionResponse = _DistrictService.GetById(districtId);
            if (returnDivisionResponse.entity.UpazillaList == null)
            {
                List<UpazillaVM> data = new List<UpazillaVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            var result = returnDivisionResponse.entity.UpazillaList.Select(y => new { Id = y.Id, Name = y.Name });

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult GetUnionDropdownByUpazillaId(long unionId)
        //{
        //    (ExecutionState executionState, UnionVM entity, string message) returnUnionResponse = _UnionService.GetById(unionId);
        //    if (returnUnionResponse.entity == null)
        //    {
        //        List<UnionVM> data = new List<UnionVM>();
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    var result = returnUnionResponse.entity;

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult GetPoliceStationDropdownByDistrictId(long districtId)
        {

            (ExecutionState executionState, DistrictVM entity, string message) returnDivisionResponse = _DistrictService.GetById(districtId);

            if (returnDivisionResponse.entity.PoliceStationList == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var result = returnDivisionResponse.entity.PoliceStationList.Select(y => new { Id = y.Id, PoliceStationName = y.PoliceStationName });


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUpazilaDropdownByDistrictId(long districtId)
        {
            (ExecutionState executionState, DistrictVM entity, string message) returnDivisionResponse = _DistrictService.GetById(districtId);

            if (returnDivisionResponse.entity.PoliceStationList == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var result = returnDivisionResponse.entity.UpazillaList.Select(y => new { Id = y.Id, Name = y.Name });

            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public ActionResult GetUnionDropdownByUpazillaId(long upazillaId)
        {
            var returnUpazillaResponse = _UnionService.List().entity.Where(x=>x.UpazillaId == upazillaId).ToList();

            if (returnUpazillaResponse == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var result = returnUpazillaResponse.Select(y => new { Id = y.Id, Name = y.Name });

            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public List<DegreeVM> GetDegrees()
        {
            (ExecutionState executionState, List<DegreeVM> entity, string message) returnDegreeResponse = _DegreeService.List();
            if (returnDegreeResponse.entity == null)
            {
                List<DegreeVM> data = new List<DegreeVM>();
                return data;
            }
            return returnDegreeResponse.entity;

        }
        public List<DropdownVM> GetGenders()
        {
            List<DropdownVM> GenderList = (from Gender e in Enum.GetValues(typeof(Gender))
                                           select new DropdownVM
                                           {
                                               Id = (int)e,
                                               Name = e.ToString()
                                           }).ToList();
            return GenderList;

        }

        public List<DropdownVM> GetMaritalStatus()
        {
            List<DropdownVM> MaritalStatusList = (from MaritalStatus e in Enum.GetValues(typeof(MaritalStatus))
                                                  select new DropdownVM
                                                  {
                                                      Id = (int)e,
                                                      Name = e.ToString()
                                                  }).ToList();
            return MaritalStatusList;

        }

        public List<DropdownVM> GetReligions()
        {
            List<DropdownVM> ReligionList = (from Religion e in Enum.GetValues(typeof(Religion))
                                             select new DropdownVM
                                             {
                                                 Id = (int)e,
                                                 Name = e.ToString()
                                             }).ToList();
            return ReligionList;

        }

        public List<DropdownVM> GetDays()
        {
            List<DropdownVM> DaysList = (from Days e in Enum.GetValues(typeof(Days))
                                         select new DropdownVM
                                         {
                                             Id = (int)e,
                                             Name = e.ToString()
                                         }).ToList();
            return DaysList;

        }
        public List<DropdownVM> GetEligibleFor()
        {
            List<DropdownVM> EligibleForList = (from EligibleFor e in Enum.GetValues(typeof(EligibleFor))
                                                select new DropdownVM
                                                {
                                                    Id = (int)e,
                                                    Name = e.ToString()
                                                }).ToList();
            return EligibleForList;

        }

        public List<DropdownVM> GetCountries()
        {
            List<DropdownVM> Countries = (from Country e in Enum.GetValues(typeof(Country))
                                          select new DropdownVM
                                          {
                                              Id = (int)e,
                                              Name = EnumHelper.GetEnumDisplayName((Country)(int)e)
                                          }).ToList();
            return Countries;

        }

        public List<Dropdown2VM> GetBloodGroups()
        {
            List<Dropdown2VM> BloodGroups = (from BloodGroup e in Enum.GetValues(typeof(BloodGroup))
                                             select new Dropdown2VM
                                             {
                                                 Id = e.ToString(),
                                                 Name = EnumHelper.GetEnumDisplayName((BloodGroup)e)
                                             }).ToList();
            return BloodGroups;

        }


        public List<DropdownVM> GetCadres()
        {
            List<DropdownVM> Countries = (from Cadre e in Enum.GetValues(typeof(Cadre))
                                          select new DropdownVM
                                          {
                                              Id = (int)e,
                                              Name = EnumHelper.GetEnumDisplayName((Cadre)(int)e)
                                          }).ToList();
            return Countries;

        }
        public List<DropdownVM> GetLeaveStatus()
        {
            List<DropdownVM> data = (from LeaveStatus e in Enum.GetValues(typeof(LeaveStatus))
                                     select new DropdownVM
                                     {
                                         Id = (int)e,
                                         Name = e.ToString()
                                     }).ToList();
            return data;

        }

        public List<DropdownVM> GetTrainingTypes()
        {
            List<DropdownVM> TrainingTypeList = (from TrainingType e in Enum.GetValues(typeof(TrainingType))
                                                 select new DropdownVM
                                                 {
                                                     Id = (int)e,
                                                     Name = EnumHelper.GetEnumDisplayName((TrainingType)(int)e)
                                                 }).ToList();
            return TrainingTypeList;

        }
        public List<DropdownVM> GetRecruitPromos()
        {
            List<DropdownVM> RecruitPromoList = (from RecruitPromoEnum e in Enum.GetValues(typeof(RecruitPromoEnum))
                                                 select new DropdownVM
                                                 {
                                                     Id = (int)e,
                                                     Name = EnumHelper.GetEnumDisplayName((RecruitPromoEnum)(int)e)
                                                 }).ToList();
            return RecruitPromoList;

        }


        public List<PromtionNatureVM> GetNatureOfPromotions()
        {
            (ExecutionState executionState, List<PromtionNatureVM> entity, string message) returnPromtionNatureResponse = _PromtionNatureService.List();
            return returnPromtionNatureResponse.entity;

        }
        public List<DropdownVM> GetWorkingAs()
        {
            List<DropdownVM> NatureOfPromotionsList = (from WorkingAs e in Enum.GetValues(typeof(WorkingAs))
                                                       select new DropdownVM
                                                       {
                                                           Id = (int)e,
                                                           Name = EnumHelper.GetEnumDisplayName((WorkingAs)(int)e)
                                                       }).ToList();
            return NatureOfPromotionsList;

        }

        public List<PayScaleYearInfoVM> GetYearOfPayScales()
        {
            (ExecutionState executionState, List<PayScaleYearInfoVM> entity, string message) returnPayScaleYearInfoResponse = _PayScaleYearInfoService.List();
            return returnPayScaleYearInfoResponse.entity;
        }

        public ActionResult GetDesignation()
        {
            (ExecutionState executionState, List<DesignationVM> entity, string message) returnDesignationResponse = _DesignationService.List();
            if (returnDesignationResponse.entity == null)
            {
                List<DesignationVM> data = new List<DesignationVM>();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(returnDesignationResponse.entity, JsonRequestBehavior.AllowGet);
            }
        }
    }
}