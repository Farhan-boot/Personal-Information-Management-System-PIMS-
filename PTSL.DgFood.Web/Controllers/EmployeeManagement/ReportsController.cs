using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using Newtonsoft.Json;
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
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class ReportsController : Controller
    {

        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IPoliceStationService _PoliceStationService;
        private readonly ISpouseInformationService _SpouseInformationService;
        private readonly IChildrenInformationService _ChildrenInformationService;

        private readonly IPermanentAddressService _PermanentAddressService;
        private readonly IPresentAddressService _PresentAddressService;

        private readonly IEducationalQualificationService _EducationalQualificationService;
        private readonly ITrainingInformationService _TrainingInformationService;
        private readonly ITrainingManagementTypeService _TrainingManagementTypeService;
        private readonly ITrainingInformationManagementService _TrainingInformationManagementService;
        private readonly ITrainingInformationManagementMasterService _TrainingInformationManagementMasterService;

        private readonly IServiceHistoryService _ServiceHistoryService;
        private readonly IOfficialInformationService _OfficialInformationService;
        private readonly IDisciplinaryActionsAndCriminalProsecutionService _DisciplinaryActionsAndCriminalProsecutionService;
        private readonly IPostingRecordsService _PostingRecordsService;
        private readonly IEmployeeTransferService _EmployeeTransferService;

        private readonly IPromotionPartcularsService _PromotionPartcularsService;
        private readonly IEmployeeStatusService _EmployeeStatusService;
        private readonly IDesignationService _DesignationService;
        public readonly IModelStateValidation _ModelStateValidation;
        public ReportsController()
        {
            _EmployeeInformationService = new EmployeeInformationService();
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _PoliceStationService = new PoliceStationService();
            _SpouseInformationService = new SpouseInformationService();
            _ChildrenInformationService = new ChildrenInformationService();
            _PermanentAddressService = new PermanentAddressService();
            _PresentAddressService = new PresentAddressService();
            _EducationalQualificationService = new EducationalQualificationService();
            _TrainingInformationService = new TrainingInformationService();
            _TrainingInformationManagementService = new TrainingInformationManagementService();
            _TrainingManagementTypeService = new TrainingManagementTypeService();
            _TrainingInformationManagementMasterService = new TrainingInformationManagementMasterService();
            _ServiceHistoryService = new ServiceHistoryService();
            _OfficialInformationService = new OfficialInformationService();
            _DisciplinaryActionsAndCriminalProsecutionService = new DisciplinaryActionsAndCriminalProsecutionService();
            _PostingRecordsService = new PostingRecordsService();
            _EmployeeTransferService = new EmployeeTransferService();
            _PromotionPartcularsService = new PromotionPartcularsService();
            _EmployeeStatusService = new EmployeeStatusService();
            _DesignationService = new DesignationService();
            _ModelStateValidation = new ModelStateValidation();
        }

        public ActionResult Index()
        {
            DropdownController dc = new DropdownController();

            ICollection<EmployeeStatusVM> returnEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.EmployeeStatusId = new SelectList(returnEmployeeStatusResponse, "Id", "EmployeeStatusName");

            ICollection<DesignationVM> returnDesignationsResponse = dc.GetDesignations();
            ViewBag.DesignationId = new SelectList(returnDesignationsResponse, "Id", "DesignationName");

            ICollection<DivisionVM> returnDivisionResponse = dc.GetDivisions();

            ICollection<GradationTypeVM> returnGradationTypeResponse = dc.GetGradationTypess();
            ViewBag.GradationTypeId = new SelectList(returnGradationTypeResponse, "Id", "GradationTypeName");

            var returnBloodGroupsResponse = dc.GetBloodGroups();
            ViewBag.BloodGroupId = new SelectList(returnBloodGroupsResponse, "Id", "Name");

            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.PoliceStationId = new SelectList("");

            var trainingManagementMaster = _TrainingInformationManagementMasterService.List();
            var trainingInfoList = new List<TrainingManagementTypeVM>();
            if (trainingManagementMaster.entity != null)
            {
                foreach (var item in trainingManagementMaster.entity)
                {
                    var training = item.TrainingManagementTypeDto;
                    var trainingBatch = string.IsNullOrEmpty(training.TrainingBatch) ? "": $"-{training.TrainingBatch}";

                    training.TrainingTitle = $"{training.TrainingTitle}{trainingBatch}-{training.TrainingLocationType.ToString()}";

                    training.Id = item.Id;
                    trainingInfoList.Add(training);
                }
                ViewBag.TrainingManagementMasterId = new SelectList(trainingInfoList, "Id", "TrainingTitle");
            }
            else
            {
                ViewBag.TrainingManagementMasterId = new SelectList("");
            }

            var categoryResponse = dc.GetCategories();
            ViewBag.CategoryId = new SelectList(categoryResponse, "Id", "CategoryName");
            var presentStatusResponse = dc.GetPresentStatus();
            ViewBag.PresentStatusId = new SelectList(presentStatusResponse, "Id", "PresentStatusName");

            ClearSessionData();

            return View();
        }

        //public void CreatePagingLinks(int page)
        //{
        //    PagingInfo pagingInfo = new PagingInfo();
        //    pagingInfo.CurrentPage = page == 0 ? 1 : page;
        //    pagingInfo.TotalItems = 1000;
        //    pagingInfo.ItemsPerPage = 10;
        //    ViewBag.Paging = pagingInfo;
        //}

        //public ActionResult NotActiveEmployeeFilter(int? page)
        //{
            
        //    List<EmployeeInformationListVM> EmployeeInformationListVM = new List<EmployeeInformationListVM>();
        //    DataTable table = new DataTable();

        //    try
        //    {
        //        var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
        //        int pageSize = 1000; // Get 25 students for each requested page. 
        //        List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["NotActiveEmployee"];
        //        if (dt != null)
        //            {   
        //                var onePageOfSearchData = dt.Skip(pageNumber).Take(pageSize);
        //                return View(onePageOfSearchData);
        //            } 
        //    }
        //    catch (Exception ex)
        //    {
        //        //return View();
        //    }
        //    return View(EmployeeInformationListVM);
        //}

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "NotActiveEmployeeRpt")]

        public ActionResult NotActiveEmployeeRpt(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                ReturnAllRow = true,
            };
            Session["NotActiveEmployee"] = null;
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);
            List<EmployeeInformationListVM> data = returnResponse.entity.Where(x => x.EmployeeStatusId != 0).ToList(); // 0 means Active
            Session["NotActiveEmployee"] = data;
            return View(data);
        }

        public ActionResult PrintPriviewNotActiveEmployeeRpt()
        {
            List<EmployeeInformationListVM>  dt = (List <EmployeeInformationListVM>)Session["NotActiveEmployee"];
            ViewBag.ReportData = dt; 
            //Session["NotActiveEmployee"] = null;
            return View(dt);

        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "StatusWiseEmployeeRpt")]

        public ActionResult StatusWiseEmployeeRpt(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            Session["StatusWiseEmployee"] = null;
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                EmployeeStatusId = model.EmployeeStatusId,
                ReturnAllRow = true,
            };
            ViewBag.Status = "All";
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            (ExecutionState executionState, EmployeeStatusVM entity, string message) returnEmployeeStatusResponse = _EmployeeStatusService.GetById(model.EmployeeStatusId);

            ViewBag.Status = returnEmployeeStatusResponse.entity.EmployeeStatusName;
            Session["EmployeeStatus"] = returnEmployeeStatusResponse.entity.EmployeeStatusName;
            Session["StatusWiseEmployee"] = returnResponse.entity;

            return View(returnResponse.entity);
        }


        [HttpPost]
        [MultipleButton(Name = "action", Argument = "FirstJoiningDateWiseEmployeeRpt")]
        public ActionResult FirstJoiningDateWiseEmployeeRpt(HomeViewModel model)
        {
            Session["StatusWiseEmployee"] = null;
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                FirstJoiningDate = model.FirstJoiningDate,
                ReturnAllRow = true,
            };
            ViewBag.Status = "All";
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            Session["StatusWiseEmployee"] = returnResponse.entity;
            return View(returnResponse.entity);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "BloodGroupWiseReport")]
        public ActionResult BloodGroupWiseReport(HomeViewModel model)
        {
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                BloodGroup = model.BloodGroup,
                ReturnAllRow = true,
            };
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            ViewBag.BloodGroup = model.BloodGroup;

            return View(returnResponse.entity);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "GetEmployeeByDisciplinaryAction")]
        public ActionResult GetEmployeeByDisciplinaryAction(HomeViewModel model)
        {
            var filter = new DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM
            {
                CategoryId = model.CategoryId,
                PresentStatusId = model.PresentStatusId
            };

            (ExecutionState executionState, List<EmployeeInformationByDisciplinaryVM> entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.GetEmployeeByDisciplinaryActionsFilter(filter);

            //ViewBag.EmployeeList = model.BloodGroup;

            return View(returnResponse.entity);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "GradationListWiseReport")]
        public ActionResult GradationListWiseReport(HomeViewModel model)
        {
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                GradationTypeId = model.GradationTypeId,
                ReturnAllRow = true,
            };
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            if (returnResponse.entity != null)
            {
                return View(returnResponse.entity);
            }

            var emptyList = Enumerable.Empty<EmployeeInformationListVM>();

            return View(emptyList);
        }

        public ActionResult PrintPreviewStatusWiseEmployeeRpt()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["StatusWiseEmployee"];
            ViewBag.ReportData = dt;
            ViewBag.Status = Session["EmployeeStatus"] ; 
            //Session["EmployeeStatus"] = null;
            return View(dt);

        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DesignationWiseEmployeeRpt")]
        public ActionResult DesignationWiseEmployeeRpt(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            Session["DesignationWiseEmployee"] = null;
            ViewBag.Status = "All Employee";
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                ReturnAllRow = true,
            };
            employee.DesignationId = model.DesignationId;
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            if (model.DesignationId > 0)
            {
                (ExecutionState executionState, DesignationVM entity, string message) returnEmployeeStatusResponse = _DesignationService.GetById(model.DesignationId);
                //var officialData = returnResponse.entity.SelectMany(x => x.OfficialInformationList.Where(y=>y.PresentDesignationId == model.DesignationId).ToList()).ToList();
                //List<EmployeeInformationVM> filteredData = (from item in data
                //                                            join official in officialData on item.Id equals official.EmployeeInformationId
                //                                            select new EmployeeInformationVM
                //                                            {
                //                                                Id = item.Id,
                //                                                NameEnglish = item.NameEnglish,
                //                                                DateOfBirth = item.DateOfBirth,
                //                                                PromotionPartcularsList = item.PromotionPartcularsList,
                //                                                OfficialInformationList = item.OfficialInformationList,
                //                                                PermanentAddressesList = item.PermanentAddressesList,
                //                                                PresentAddressesList = item.PresentAddressesList,
                //                                                EmployeeStatusDTO = item.EmployeeStatusDTO
                //                                            }
                //       ).ToList();
                 
                ViewBag.DesignationName = returnEmployeeStatusResponse.entity.DesignationName;
                Session["DesignationName"] = returnEmployeeStatusResponse.entity.DesignationName;
                Session["DesignationWiseEmployee"] = returnResponse.entity;
                return View(returnResponse.entity);
            }
            Session["DesignationWiseEmployee"] = returnResponse.entity;
            return View(returnResponse.entity);
        }

        public ActionResult PrintPreviewDesignationWiseEmployeeRpt()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["DesignationWiseEmployee"];
            ViewBag.ReportData = dt;
            ViewBag.DesignationName = Session["DesignationName"];
            //Session["DesignationWiseEmployee"] = null;
            //Session["DesignationName"] = null;
            return View(dt);

        }


        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DateWiseTransferRpt")]
        public ActionResult DateWiseTransferRpt(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            Session["DateWiseTransferRpt"] = null;
            ViewBag.TransferDate = DateTime.Now.Date;
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                ReturnAllRow = true,
            };
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);
            List<EmployeeInformationListVM> data = returnResponse.entity.ToList();
            
            if (model.TransferFromDate != null && model.TransferToDate != null)
            {
                var filterdata = returnResponse.entity.Where(x => Convert.ToDateTime(x.PostingFromDate) >= Convert.ToDateTime(model.TransferFromDate.Date) && Convert.ToDateTime(x.PostingToDate) <= Convert.ToDateTime(model.TransferToDate.Date)).ToList() ;
                ViewBag.TransferFromDate = model.TransferFromDate.Date;
                ViewBag.TransferToDate = model.TransferToDate.Date;
                Session["TransferFromDate"] = model.TransferFromDate.Date;
                Session["TransferToDate"] = model.TransferToDate.Date;
                Session["DateWiseTransferRpt"] = filterdata;
                return View(filterdata);
            }
            Session["DesignationWiseEmployee"] = data;
            return View(data);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "PRLReportDateWiseRpt")]
        public ActionResult PRLReportDateWiseRpt(HomeViewModel model)
        {
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                PRLFromDate = model.PRLFromDate,
                PRLToDate = model.PRLToDate,
                ReturnAllRow = true,
            };

            if (model.TransferFromDate != null && model.TransferToDate != null)
            {
                (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);
                return View(returnResponse.entity);
            }

            var emptyList = Enumerable.Empty<EmployeeInformationListVM>();

            return View(emptyList);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "TrainingReport")]
        public ActionResult TrainingReport(HomeViewModel model)
        {
            if (model.TrainingManagementMasterId != 0)
            {
                (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetById(model.TrainingManagementMasterId);
                return View(returnResponse.entity);
            }

            var emptyList = Enumerable.Empty<TrainingInfoListVM>();

            return View(emptyList);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "TrainingCompletionReport")]
        public ActionResult TrainingCompletionReport(HomeViewModel model)
        {
            ViewBag.TrainingFromDate = model.TrainingFromDate;
            ViewBag.TrainingToDate = model.TrainingToDate;

            if (model.TrainingFromDate != null && model.TrainingToDate != null)
            {
                var filter = new GetTrainingFilterDataByDateVM
                {
                    FromDate = model.TrainingFromDate,
                    ToDate = model.TrainingToDate
                };

                (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetCompletedByFromToDate(filter);
                return View(returnResponse.entity);
            }

            var emptyList = Enumerable.Empty<TrainingInformationManagementMasterVM>();

            return View(emptyList);
        }

        public ActionResult PrintPreviewDateWiseTransferRpt()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["DateWiseTransferRpt"];
            ViewBag.ReportData = dt;
            ViewBag.TransferFromDate = Session["TransferFromDate"];
            ViewBag.TransferToDate = Session["TransferToDate"];
           
            //Session["DateWiseTransferRpt"] = null;             
            //Session["TransferFromDate"] = null;
            //Session["TransferToDate"] = null;
            return View(dt);

        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DateWisePromotionRpt")]
        public ActionResult DateWisePromotionRpt(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            Session["DateWisePromotionRpt"] = null;
            ViewBag.PromotionDate = DateTime.Now.Date;
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                ReturnAllRow = true,
            };
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);
            List<EmployeeInformationListVM> data = returnResponse.entity.ToList();

            if (model.PromotionFromDate != null && model.PromotionToDate != null)
            {
                //var PromotionData = returnResponse.entity.SelectMany(x => x.PromotionPartcularsList.Where(y => Convert.ToDateTime(y.CreatedAt.Date) >= Convert.ToDateTime(model.PromotionFromDate.Date) && Convert.ToDateTime(y.CreatedAt.Date) <= Convert.ToDateTime(model.PromotionToDate.Date)).ToList()).ToList();
                //List<EmployeeInformationVM> filteredData = (from item in data
                //                                            join official in PromotionData on item.Id equals official.EmployeeInformationId
                //                                            select new EmployeeInformationVM
                //                                            {
                //                                                Id = item.Id,
                //                                                NameEnglish = item.NameEnglish,
                //                                                DateOfBirth = item.DateOfBirth,
                //                                                PromotionPartcularsList = item.PromotionPartcularsList,
                //                                                OfficialInformationList = item.OfficialInformationList,
                //                                                PermanentAddressesList = item.PermanentAddressesList,
                //                                                PresentAddressesList = item.PresentAddressesList,
                //                                                EmployeeStatusDTO = item.EmployeeStatusDTO,
                //                                                PostingRecordsList = item.PostingRecordsList
                //                                            }).ToList();

                var PromotionData = returnResponse.entity.Where(x => Convert.ToDateTime(x.PromotionDate) >= Convert.ToDateTime(model.PromotionFromDate.Date) && Convert.ToDateTime(x.PromotionDate) <= Convert.ToDateTime(model.PromotionToDate.Date)).ToList() ;

                ViewBag.PromotionFromDate = model.PromotionFromDate.Date;
                ViewBag.PromotionToDate = model.PromotionToDate.Date;
                Session["PromotionFromDate"] = model.PromotionFromDate.Date;
                Session["PromotionToDate"] = model.PromotionToDate.Date;
                Session["DateWisePromotionRpt"] = PromotionData;
                return View(PromotionData);
            }
            Session["DesignationWiseEmployee"] = data;
            return View(data);
        }

        public ActionResult PrintPreviewDateWisePromotionRpt()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["DateWisePromotionRpt"];
            ViewBag.ReportData = dt;
            ViewBag.PromotionFromDate = Session["PromotionFromDate"];
            ViewBag.PromotionToDate = Session["PromotionToDate"];

            //Session["DateWisePromotionRpt"] = null;
            //Session["PromotionFromDate"] = null;
            //Session["PromotionToDate"] = null;
            return View(dt);

        }


        // FIX; Police station is not showing
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "LocationWiseEmployeeReport")]
        public ActionResult LocationWiseEmployeeReport(HomeViewModel model)//,long ProgressPercenFrom, long ProgressPercenTo
        {
            Session["StatusWiseEmployee"] = null;
            ViewBag.Status = "All";
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                DistrictId = model.DistrictId,
                DivisionId = model.DivisionId,
                PoliceStationId = model.PoliceStationId,
                ReturnAllRow = true,
            };

            if (model.DivisionId > 0)
            {
                employee.DivisionId = model.DivisionId;

                (ExecutionState executionState, DivisionVM entity, string message) returnDivisionResponse = _DivisionService.GetById(model.DivisionId);
                ViewBag.DivisionName = returnDivisionResponse.entity.DivisionName;
                Session["DivisionName"] = returnDivisionResponse.entity.DivisionName;
            }
            if (model.DistrictId > 0)
            {
                employee.DistrictId = model.DistrictId;

                (ExecutionState executionState, DistrictVM entity, string message) returnDistrictResponse = _DistrictService.GetById(model.DistrictId);
                ViewBag.DistrictName = returnDistrictResponse.entity.DistrictName;
                Session["DistrictName"] = returnDistrictResponse.entity.DistrictName;
            }
            if (model.PoliceStationId > 0)
            {
                employee.PoliceStationId = model.PoliceStationId;

                (ExecutionState executionState, PoliceStationVM entity, string message) returnPoliceStationResponse = _PoliceStationService.GetById(model.PoliceStationId);
                ViewBag.PoliceStationName = returnPoliceStationResponse.entity.PoliceStationName;
                Session["PoliceStationName"] = returnPoliceStationResponse.entity.PoliceStationName;
            }

            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            Session["LocationWiseEmployee"] = returnResponse.entity;
            return View(returnResponse.entity);
        }

        public ActionResult PrintPreviewLocationWiseEmployeeReport()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["LocationWiseEmployee"];
            ViewBag.ReportData = dt;
            ViewBag.DivisionName = Session["DivisionName"];
            ViewBag.DistrictName = Session["DistrictName"];
            ViewBag.PoliceStationName = Session["PoliceStationName"];
            //Session["LocationWiseEmployee"] = null;
            //Session["DivisionName"] = null;
            //Session["DistrictName"] = null;
            //Session["PoliceStationName"] = null;
            return View(dt);

        }

        public void ClearSessionData()
        {
            Session["NotActiveEmployee"] = null;
            Session["StatusWiseEmployee"] = null;
            Session["EmployeeStatus"] = null;
            Session["DesignationWiseEmployee"] = null;
            Session["DesignationName"] = null;
            Session["DateWiseTransferRpt"] = null;
            Session["TransferFromDate"] = null;
            Session["TransferToDate"] = null;
            Session["DateWisePromotionRpt"] = null;
            Session["PromotionFromDate"] = null;
            Session["PromotionToDate"] = null;
            Session["LocationWiseEmployee"] = null;
            Session["DivisionName"] = null;
            Session["DistrictName"] = null;
            Session["PoliceStationName"] = null;
        }



        // New Report, DD Sir

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "AllEmployeeRpt")]
        public ActionResult AllEmployeeRpt(HomeViewModel model)
        {
            Session["DesignationWiseEmployee"] = null;
            ViewBag.Status = "All Employee";
            EmployeeInformationFilterVM employee = new EmployeeInformationFilterVM
            {
                ReturnAllRow = true,
            };
            employee.DesignationId = model.DesignationId;
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse = _EmployeeInformationService.EmployeeListBySP(employee);

            if (model.DesignationId > 0)
            {
                (ExecutionState executionState, DesignationVM entity, string message) returnEmployeeStatusResponse = _DesignationService.GetById(model.DesignationId);
               

                ViewBag.DesignationName = returnEmployeeStatusResponse.entity.DesignationName;
                Session["DesignationName"] = returnEmployeeStatusResponse.entity.DesignationName;
                Session["DesignationWiseEmployee"] = returnResponse.entity;
                return View(returnResponse.entity);
            }
            Session["DesignationWiseEmployee"] = returnResponse.entity;
            return View(returnResponse.entity);
        }




    }
}