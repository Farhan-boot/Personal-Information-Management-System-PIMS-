using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.Datatable;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class EmployeeInformationController : Controller
    {
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly ISpouseInformationService _SpouseInformationService;
        private readonly IChildrenInformationService _ChildrenInformationService;

        private readonly IPermanentAddressService _PermanentAddressService;
        private readonly IPresentAddressService _PresentAddressService;

        private readonly IEducationalQualificationService _EducationalQualificationService;
        private readonly ITrainingInformationService _TrainingInformationService;

        private readonly IServiceHistoryService _ServiceHistoryService;
        private readonly IOfficialInformationService _OfficialInformationService;
        private readonly IDisciplinaryActionsAndCriminalProsecutionService _DisciplinaryActionsAndCriminalProsecutionService;
        private readonly IPostingRecordsService _PostingRecordsService;
        private readonly IEmployeeTransferService _EmployeeTransferService;

        private readonly IPromotionPartcularsService _PromotionPartcularsService;
        private readonly ILanguageInformationService _LanguageInformationService;
        private readonly IEnglishAndBanglaValidation _EnglishAndBanglaValidation;
        public readonly IModelStateValidation _ModelStateValidation;
        private readonly IUniversityInformationService _UniversityInformationService;

        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        //public EmployeeInformationController(): this(new EmployeeInformationService())
        //{
        //}
        public EmployeeInformationController()
        {
            _EmployeeInformationService = new EmployeeInformationService();
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _SpouseInformationService = new SpouseInformationService();
            _ChildrenInformationService = new ChildrenInformationService();
            _PermanentAddressService = new PermanentAddressService();
            _PresentAddressService = new PresentAddressService();
            _EducationalQualificationService = new EducationalQualificationService();
            _TrainingInformationService = new TrainingInformationService();
            _ServiceHistoryService = new ServiceHistoryService();
            _OfficialInformationService = new OfficialInformationService();
            _DisciplinaryActionsAndCriminalProsecutionService = new DisciplinaryActionsAndCriminalProsecutionService();
            _PostingRecordsService = new PostingRecordsService();
            _EmployeeTransferService = new EmployeeTransferService();
            _PromotionPartcularsService = new PromotionPartcularsService();
            _LanguageInformationService = new LanguageInformationService();
            _EnglishAndBanglaValidation = new EnglishAndBanglaValidation();
            _ModelStateValidation = new ModelStateValidation();
            _UniversityInformationService = new UniversityInformationService();

            _UpazillaService = new UpazillaService();
            _UnionService = new UnionService();
        }
        // GET: EmployeeInformation
        public ActionResult Index()
        {
           // (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
           //// EmployeeInformationFilterVM filterData = new EmployeeInformationFilterVM();
           // EmployeeInformationFilterVM filterData = new EmployeeInformationFilterVM
           // {
           //     PageIndex = 1,
           //     PageSize = 10
           // };
           // var RoleName = Session["RoleName"].ToString();
           // if (RoleName == "Employee Group")
           // {

           //     filterData.Email = Session["UserEmail"].ToString();
           //     // returnResponse = _EmployeeInformationService.GetEmployeeByEmailWithAllIncluding(filterData);
           //     returnResponse = _EmployeeInformationService.EmployeeListBySP(filterData);
           //     returnResponse.entity = returnResponse.entity.Where(x => x.Email == filterData.Email).ToList();

           // }
           // else
           // {
           //     returnResponse = _EmployeeInformationService.EmployeeListBySP(filterData);
           // }

           // if (returnResponse.entity != null)
           // {
           //     returnResponse.entity = returnResponse.entity.OrderByDescending(x => x.Id).ToList();
           // }
           // Session["EmployeeIndexList"] = returnResponse.entity;
            return View(new List<EmployeeInformationListVM>());
        }


        public ActionResult EmployeeList(JqDataTable model)
        {
            var pageIndex = (int)Math.Ceiling(((double)model.iDisplayStart + 1) / (double)model.iDisplayLength);


            EmployeeInformationFilterVM filterData = new EmployeeInformationFilterVM
            {
                PageIndex = pageIndex <= 0 ? 1 : pageIndex,
                PageSize = model.iDisplayLength
            };
            //var employees = (List<EmployeeInformationListVM>)Session["EmployeeIndexList"];

            //isortcol_0 paramater will be 0 for the first column (present in JqDataTable)
            //isortcol_0 paramater will be 1 for the second column
            //isortcol_0 paramater will be 2 for the third column
            //etc....
            //if you click on the column header ssortdir_0 paramater will change from 'asc' to 'desc'.
            /*
            if (model.iSortCol_0 == 0 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.Id).ToList();
                }
                else if (model.iSortCol_0 == 0 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.Id).ToList();
                }
                if (model.iSortCol_0 == 1 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.NameEnglish.Trim()).ToList();
                }
                else if (model.iSortCol_0 == 1 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.NameEnglish.Trim()).ToList();
                }
                if (model.iSortCol_0 == 2 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.DateOfBirth).ToList();
                }
                else if (model.iSortCol_0 == 2 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.DateOfBirth).ToList();
                }
                if (model.iSortCol_0 == 3 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.DesignationName).ToList();
                }
                else if (model.iSortCol_0 == 3 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.DesignationName).ToList();
                }
                if (model.iSortCol_0 == 4 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.RankName).ToList();
                }
                else if (model.iSortCol_0 == 4 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.RankName).ToList();
                }
                if (model.iSortCol_0 == 5 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.RecruitPromo).ToList();
                }
                else if (model.iSortCol_0 == 5 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.RecruitPromo).ToList();
                }
                if (model.iSortCol_0 == 6 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.PostingType).ToList();
                }
                else if (model.iSortCol_0 == 6 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.PostingType).ToList();
                }
                if (model.iSortCol_0 == 7 && model.sSortDir_0 == "asc")
                {
                    employees = employees.OrderBy(x => x.MobileNumber).ToList();
                }
                else if (model.iSortCol_0 == 7 && model.sSortDir_0 == "desc")
                {
                    employees = employees.OrderByDescending(x => x.MobileNumber).ToList();
                }
                //Global Search functionality 

                if (!(string.IsNullOrEmpty(model.sSearch)) && !(string.IsNullOrWhiteSpace(model.sSearch)))
                {
                    employees = employees.Where(x => x.Id.ToString().ToLower().Contains(model.sSearch.ToLower()) || x.NameEnglish.ToLower().Contains(model.sSearch.ToLower()) 
                    || x.DateOfBirth.ToString("dd-MM-yyyy").ToLower().Contains(model.sSearch) || x.DesignationName.ToLower().ToString().Contains(model.sSearch.ToLower())
                    || x.RankName.ToLower().ToString().Contains(model.sSearch.ToLower()) || x.RecruitPromo.ToLower().Contains(model.sSearch.ToLower())
                    || x.PostingPlace.ToLower().Contains(model.sSearch.ToLower()) || x.MobileNumber.ToLower().Contains(model.sSearch.ToLower())

                    ).ToList();
                }
                */

                //individual column filtering    
                 
                //Id Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_0)) && !(string.IsNullOrWhiteSpace(model.sSearch_0)))
                {
                //employees = employees.Where(x => x.Id.ToString().ToLower().Contains(model.sSearch_0.ToLower())).ToList();
                    long.TryParse(model?.sSearch_0, out var employeeInfoId);
                    filterData.Id = employeeInfoId;
                }
                //Name Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_1)) && !(string.IsNullOrWhiteSpace(model.sSearch_1)))
                {
                    filterData.NameEnglish = model?.sSearch_1?.ToLower();
                }
                //DOB Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_2)) && !(string.IsNullOrWhiteSpace(model.sSearch_2)))
                {
                    DateTime.TryParse(model?.sSearch_2, out var dob);
                    DateTime? dateOfBirth = null;
                    if (string.IsNullOrEmpty(model?.sSearch_2) == false)
                    {
                        dateOfBirth = dob;
                    }
                    filterData.DateOfBirth = dateOfBirth;
                }
                //Designation Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_3)) && !(string.IsNullOrWhiteSpace(model.sSearch_3)))
                {
                    filterData.Designation = model?.sSearch_3;
                }
                //Grade Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_4)) && !(string.IsNullOrWhiteSpace(model.sSearch_4)))
                {
                    filterData.Grade = model?.sSearch_4;
                }
                //ByPromo Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_5)) && !(string.IsNullOrWhiteSpace(model.sSearch_5)))
                {
                    filterData.PromoRecruit = model?.sSearch_5;
                }
                //PostingPlace Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_6)) && !(string.IsNullOrWhiteSpace(model.sSearch_6)))
                {
                    filterData.PostingPlace = model?.sSearch_6;
                }
                //MobileNo Column Filtering
                if (!(string.IsNullOrEmpty(model.sSearch_7)) && !(string.IsNullOrWhiteSpace(model.sSearch_7)))
                {
                    filterData.MobileNumber = model?.sSearch_7?.ToLower();
                }
            var employeeList = _EmployeeInformationService.EmployeeListBySP(filterData);


            long empId =Convert.ToInt64(Session["EmployeeInformationId"].ToString());
            string groupName = Session["IndividualEmployeeGroup"]?.ToString();

            if (groupName == "Individual Employee Group")
            {
                var testData = _EmployeeInformationService.GetById(empId);
                employeeList.entity = null;
                var employeeInformationList = new EmployeeInformationListVM();
                var employeeInformationListData = new List<EmployeeInformationListVM>();
                employeeInformationList.Id = testData.entity.Id;
                employeeInformationList.NameEnglish = testData.entity.NameEnglish;
                employeeInformationList.DateOfBirth = testData.entity.DateOfBirth;
                employeeInformationList.DesignationName = testData.entity.PresentDesignation;
                employeeInformationList.MobileNumber = testData.entity.MobileNumber;


                employeeInformationListData.Add(employeeInformationList);

                var resultData = new
                {
                    iTotalRecords = employeeInformationListData.Count,//records per page 
                    iTotalDisplayRecords = employeeInformationListData.Count(), //total table count
                    aaData = employeeInformationListData //employee list
                };

                return Json(resultData, JsonRequestBehavior.AllowGet);


            }



            if (employeeList.entity == null)
            {
                var badResult = new
                {
                    iTotalRecords = 0,
                    iTotalDisplayRecords = 0,
                    aaData = new List<EmployeeInformationListVM>()
                };

                return Json(badResult, JsonRequestBehavior.AllowGet);
            }

            var employees = employeeList.entity;


            //var emplist = employees.Skip(model.iDisplayStart).Take(model.iDisplayLength).ToList();
            //var count = employees.Count();

            //var emplist = _EmployeeInformationService.EmployeeListBySP(filterData);

            var totalRowCount = employees.Count > 0 ? employees.FirstOrDefault().TotalRowCount : 0 ;

            var result = new
            {
                iTotalRecords = employees.Count,//records per page 
                iTotalDisplayRecords = totalRowCount, //total table count
                aaData = employees //employee list
            };

            Session["EmployeeIndexList"]  = employees;

            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public ActionResult PrintPreviewEmployeeRpt()
        {
            List<EmployeeInformationListVM> dt = (List<EmployeeInformationListVM>)Session["EmployeeIndexList"];
            ViewBag.ReportData = dt;
            ViewBag.Status = Session["EmployeeStatus"];
            //Session["EmployeeStatus"] = null;
            return View(dt);

        }

        public ActionResult IndexByFilter()
        {
            DropdownController dc = new DropdownController();
            ICollection<EmployeeStatusVM> returnEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.EmployeeStatusId = new SelectList(returnEmployeeStatusResponse, "Id", "EmployeeStatusName");
            List<EmployeeInformationVM> data = new List<EmployeeInformationVM>();
            return View(data);
        }
        [HttpPost]
        public ActionResult IndexByFilter(int EmployeeStatusId)
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse = _EmployeeInformationService.List();
            List<EmployeeInformationVM> data = returnResponse.entity.Where(x => x.EmployeeStatusId == EmployeeStatusId).ToList();
            DropdownController dc = new DropdownController();
            ICollection<EmployeeStatusVM> returnEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.EmployeeStatusId = new SelectList(returnEmployeeStatusResponse, "Id", "EmployeeStatusName");

            return View(data);
        }

        // GET: EmployeeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: EmployeeInformation/Create
        public ActionResult Create()
        {

            EmployeeInformationVM entity = new EmployeeInformationVM();
            var RoleName = Session["RoleName"].ToString();
            if (RoleName == "Employee Group")
            {
                entity.Email = Session["UserEmail"].ToString();
                EmployeeInformationVM filterData = new EmployeeInformationVM();
                filterData.Email = Session["UserEmail"].ToString();
                (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse = _EmployeeInformationService.GetEmployeeByEmail(filterData);
                if (returnResponse.entity != null)
                {
                    return RedirectToAction("Index", "EmployeeInformation");
                }

            }

            DropdownController dc = new DropdownController();
            List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
            //List<DistrictVM> returnDistrictResponse = dc.GetDistrictByDivisionId(entity.DivisionId); //_DistrictService.List();
            ViewBag.DistrictId = new SelectList("");
            ViewBag.PoliceStationId = new SelectList("");
            ICollection<EmployeeStatusVM> returnOfficialInformationEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.OfficialInformationEmployeeStatusId = new SelectList(returnOfficialInformationEmployeeStatusResponse, "Id", "EmployeeStatusName");
            List<Dropdown2VM> returnBloodGroupResponse = dc.GetBloodGroups();
            ViewBag.BloodGroup = new SelectList(returnBloodGroupResponse, "Id", "Name", entity.BloodGroup);

            var GenderList = dc.GetGenders();
            ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
            var MaritalStatusList = dc.GetMaritalStatus();
            ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name");
            var ReligionList = dc.GetReligions();
            ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name");

            ViewBag.FreedomFighterInformationId = new SelectList(EnumHelper.GetEnumDropdowns<FreedomFighterInformation>(), "Id", "Name");

            //Code Gen
            string empCodeGen = _EmployeeInformationService.List().entity.OrderByDescending(x => x.Id).FirstOrDefault().EmployeeCode;
            string empCode= empCodeGen.Substring(empCodeGen.Length - 5);
            entity.EmpCodeGen = empCode ?? "00000";

            return View(entity);
        }

        //[HttpPost]
        //public ActionResult GetSpouceInformationByEmployeeId(long employeeid)
        //{
        //    (ExecutionState executionState, SpouseInformationVM entity, string message) returnSpouceInfoResponse = _SpouseInformationService.GetById(employeeid);
        //    if(returnSpouceInfoResponse.entity == null)
        //    {
        //        returnSpouceInfoResponse.entity = new SpouseInformationVM();
        //    }
        //    (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
        //    ViewBag.DivisionId = new SelectList(returnResponse.entity, "Id", "DivisionName");
        //    (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
        //    ViewBag.DistrictId = new SelectList(returnDistrictResponse.entity, "Id", "DistrictName");

        //    return PartialView("~/Views/SpouseInformation/_SpouceInformationPartial.cshtml", returnSpouceInfoResponse.entity);

        //}
        // POST: EmployeeInformation/Create


        public ActionResult UpdateExistingEmployeeData(EmployeeInformationVM entity)
        {
            try
            {
                // TODO: Add insert logic here
                (ExecutionState executionState, string message) returnResponse = _EmployeeInformationService.UpdateExistingEmployeeData();
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;


                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }
        [HttpPost]
        public ActionResult Create(EmployeeInformationVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
                ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName", entity.DivisionId);
                List<DistrictVM> returnDistrictResponse = dc.GetDistrictByDivisionId(entity.DivisionId); //_DistrictService.List();
                ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", entity.DistrictId);
                ICollection<PoliceStationVM> returnPoliceStationResponse = dc.GetPoliceStationByDistrictId(entity.DistrictId); //_DistrictService.List();
                ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", entity.PoliceStationId);
                List<Dropdown2VM> returnBloodGroupResponse = dc.GetBloodGroups();
                ViewBag.BloodGroup = new SelectList(returnBloodGroupResponse, "Id", "Name", entity.BloodGroup);
                var GenderList = dc.GetGenders();
                ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
                var MaritalStatusList = dc.GetMaritalStatus();
                ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name", entity.MaritalStatusId);
                var ReligionList = dc.GetReligions();
                ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name", entity.ReligionId);
                ICollection<EmployeeStatusVM> returnOfficialInformationEmployeeStatusResponse = dc.GetEmployeeStatus();
                ViewBag.OfficialInformationEmployeeStatusId = new SelectList(returnOfficialInformationEmployeeStatusResponse, "Id", "EmployeeStatusName", entity.EmployeeStatusId);
                ViewBag.FreedomFighterInformationId = new SelectList(EnumHelper.GetEnumDropdowns<FreedomFighterInformation>(), "Id", "Name", entity.FreedomFighterInformationId);


                if (ModelState.IsValid)
                {
                    

                    (bool success, string Message) isFormValid = ValidateBanglaAndEnglishField(entity);
                    if (isFormValid.success == false)
                    {
                        Session["Message"] = isFormValid.Message;
                        return View(entity);
                    }

                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        (ExecutionState executionState, List<DivisionVM> entity, string message) divisionLists = _DivisionService.List();

                        ViewBag.DivisionId = new SelectList(divisionLists.entity, "Id", "DivisionName", entity.DivisionId);
                        return View(entity);
                    }
                    else
                    {
                        UploadPhoto(returnResponse.entity);
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


        public void UploadPhoto(EmployeeInformationVM entity)
        {
            var EmpId = entity.Id;
            if (entity.Photo != "")
            {
                string path = Server.MapPath("~/Content/UploadEmployeePhotos/" + EmpId + "/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(path))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(path);
                }

                HttpFileCollectionBase files = Request.Files;

                for (int i = 0; i < files.Count; i++)
                {
                    var Name = "Emp-Photo";// files.AllKeys[i];
                    HttpPostedFileBase file = files[i];
                    string[] currtintTime_str = DateTime.Now.ToShortTimeString().Split(':');
                    string extension = System.IO.Path.GetExtension(file.FileName);
                    string newFileName = EmpId + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + currtintTime_str[0] + "-" + currtintTime_str[1] + "-" + Name + extension;
                    if (extension.ToUpper() == ".JPG" || extension.ToUpper() == ".JPEG" || extension.ToUpper() == ".GIF" ||
                        extension.ToUpper() == ".PNG" || extension.ToUpper() == ".BMP")
                    {
                        file.SaveAs(path + newFileName);
                        entity.Photo = EmpId + "/" + newFileName;
                    }
                }

                (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Update(entity);
            }

        }
        //public ActionResult GetDistrictByDivisionId(long divisionId)
        //{

        //    (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
        //    var result = returnDistrictResponse.entity.Where(x => x.DivisionId == divisionId).Select(y => new { Id = y.Id, DistrictName = y.DistrictName });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        // GET: EmployeeInformation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            DropdownController dc = new DropdownController();
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetById(id);
            List<DivisionVM> returnDivisionResponse = dc.GetDivisions();

            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName", returnResponse.entity.DivisionId);
            List<DistrictVM> returnDistrictResponse = dc.GetDistrictByDivisionId(returnResponse.entity.DivisionId); //_DistrictService.List();
            ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", returnResponse.entity.DistrictId);
            ICollection<PoliceStationVM> returnPoliceStationResponse = dc.GetPoliceStationByDistrictId(returnResponse.entity.DistrictId); //_DistrictService.List();
            ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", returnResponse.entity.PoliceStationId);

            Session["EmployeeInformationId"] = returnResponse.entity.Id;
            var GenderList = dc.GetGenders();
            ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", (int)(Gender)returnResponse.entity.GenderId);
            var MaritalStatusList = dc.GetMaritalStatus();
            ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name", (int)(MaritalStatus)returnResponse.entity.MaritalStatusId);
            List<Dropdown2VM> returnBloodGroupResponse = dc.GetBloodGroups();
            ViewBag.BloodGroup = new SelectList(returnBloodGroupResponse, "Id", "Name", returnResponse.entity.BloodGroup);
            var ReligionList = dc.GetReligions();
            int ReligionId = returnResponse.entity.ReligionId != null ? (int)(Religion)returnResponse.entity.ReligionId : 0;
            ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name", ReligionId);
            ViewBag.CollapseValue = "";
            ICollection<EmployeeStatusVM> returnOfficialInformationEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.OfficialInformationEmployeeStatusId = new SelectList(returnOfficialInformationEmployeeStatusResponse, "Id", "EmployeeStatusName", returnResponse.entity.EmployeeStatusId);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeInformationVM = returnResponse.entity;
            employeeViewModel.SpouseInformationVM = new SpouseInformationVM();
            employeeViewModel.ChildrenInformationVM = new ChildrenInformationVM();
            employeeViewModel.PresentAddressVM = new PresentAddressVM();
            employeeViewModel.PermanentAddressVM = new PermanentAddressVM();
            employeeViewModel.EducationalQualificationVM = new EducationalQualificationVM();
            employeeViewModel.TrainingInformationVM = new TrainingInformationVM();
            employeeViewModel.ServiceHistoryVM = new ServiceHistoryVM();
            employeeViewModel.PromotionPartcularsVM = new PromotionPartcularsVM();
            employeeViewModel.DisciplinaryActionsAndCriminalProsecutionVM = new DisciplinaryActionsAndCriminalProsecutionVM();
            employeeViewModel.PostingRecordsVM = new PostingRecordsVM();
            employeeViewModel.EmployeeTransferVM = new EmployeeTransferVM();
            employeeViewModel.OfficialInformationVM = new OfficialInformationVM();
            employeeViewModel.LanguageInformationVM = new LanguageInformationVM();
            ViewBag.TabIndex = 0;

            //Spouse Info started
            if (Session["SpouseInformationId"] != null || Session["SpouseData"] != null)
            {
                ViewBag.TabIndex = 1;
                employeeViewModel.SpouseInformationVM = GetSpouseInformationData();
                List<DivisionVM> returnSpouseDivisionResponse = dc.GetDivisions();
                ViewBag.SpouseDivisionId = new SelectList(returnSpouseDivisionResponse, "Id", "DivisionName", employeeViewModel.SpouseInformationVM.DivisionId);
                List<DistrictVM> returnSpouseDistrictResponse = dc.GetDistrictByDivisionId(employeeViewModel.SpouseInformationVM.DivisionId);
                ViewBag.SpouseDistrictId = new SelectList(returnSpouseDistrictResponse, "Id", "DistrictName", employeeViewModel.SpouseInformationVM.DistrictId);
                ViewBag.CollapseValue = "collapseSpouse";
            }
            else
            {
                List<DivisionVM> returnSpouseDivisionResponse = dc.GetDivisions();
                ViewBag.SpouseDivisionId = new SelectList(returnSpouseDivisionResponse, "Id", "DivisionName");
                ViewBag.SpouseDistrictId = new SelectList("");
            }
            //Spouse Info end

            //Children Info started
            if (Session["ChildrenInformationId"] != null || Session["ChildrenInformationData"] != null)
            {
                ViewBag.TabIndex = 1;
                employeeViewModel.ChildrenInformationVM = GetChildrenInformationData();
                ViewBag.ChildrenGenderId = new SelectList(GenderList, "Id", "Name", (int)(Gender)employeeViewModel.ChildrenInformationVM.GenderId);
                ViewBag.CollapseValue = "collapseChild";
            }
            else
            {
                ViewBag.ChildrenGenderId = new SelectList(GenderList, "Id", "Name");

            }
            //Children Info end

            //Present Address started
            if (Session["PresentAddressId"] != null || Session["PresentAddressData"] != null)
            {
                ViewBag.TabIndex = 0;
                employeeViewModel.PresentAddressVM = GetPresentAddressData();
                List<DivisionVM> returnPresentAddressDivisionResponse = dc.GetDivisions();
                ViewBag.PresentAddressDivisionId = new SelectList(returnPresentAddressDivisionResponse, "Id", "DivisionName", employeeViewModel.PresentAddressVM.DivisionId);
                List<DistrictVM> returnPresentAddressDistrictResponse = dc.GetDistrictByDivisionId(employeeViewModel.PresentAddressVM.DivisionId);
                ViewBag.PresentAddressDistrictId = new SelectList(returnPresentAddressDistrictResponse, "Id", "DistrictName", employeeViewModel.PresentAddressVM.DistrictId);
                ICollection<PoliceStationVM> returnPresentAddressPoliceStationResponse = dc.GetPoliceStationByDistrictId(employeeViewModel.PresentAddressVM.DistrictId);
                ViewBag.PresentAddressPoliceStationId = new SelectList(returnPresentAddressPoliceStationResponse, "Id", "PoliceStationName", employeeViewModel.PresentAddressVM.PoliceStationId);
                ViewBag.CollapseValue = "collapsePresentAddress";

                //Add New
                ViewBag.PresentAddressUpazillaId = new SelectList(_UpazillaService.List().entity, "Id", "Name", employeeViewModel.PresentAddressVM.UpazillaId);
                ViewBag.PresentAddressUnionId = new SelectList(_UnionService.List().entity, "Id", "Name", employeeViewModel.PresentAddressVM.UnionId);
            }
            else
            {
                List<DivisionVM> returnPresentAddressDivisionResponse = dc.GetDivisions();
                ViewBag.PresentAddressDivisionId = new SelectList(returnPresentAddressDivisionResponse, "Id", "DivisionName");
                ViewBag.PresentAddressDistrictId = new SelectList("");
                ViewBag.PresentAddressPoliceStationId = new SelectList("");

                //Add New
                ViewBag.PresentAddressUpazillaId = new SelectList("");
                ViewBag.PresentAddressUnionId = new SelectList("");
            }
            //Present Address end

            //Permanent Address started
            if (Session["PermanentAddressId"] != null || Session["PermanentAddressData"] != null)
            {
                ViewBag.TabIndex = 0;
                employeeViewModel.PermanentAddressVM = GetPermanentAddressData();
                List<DivisionVM> returnPermanentAddressDivisionResponse = dc.GetDivisions();
                ViewBag.PermanentAddressDivisionId = new SelectList(returnPermanentAddressDivisionResponse, "Id", "DivisionName", employeeViewModel.PermanentAddressVM.DivisionId);
                List<DistrictVM> returnPermanentAddressDistrictResponse = dc.GetDistrictByDivisionId(employeeViewModel.PermanentAddressVM.DivisionId);
                ViewBag.PermanentAddressDistrictId = new SelectList(returnPermanentAddressDistrictResponse, "Id", "DistrictName", employeeViewModel.PermanentAddressVM.DistrictId);
                ICollection<PoliceStationVM> returnPermanentAddressPoliceStationResponse = dc.GetPoliceStationByDistrictId(employeeViewModel.PermanentAddressVM.DistrictId);
                ViewBag.PermanentAddressPoliceStationId = new SelectList(returnPermanentAddressPoliceStationResponse, "Id", "PoliceStationName", employeeViewModel.PermanentAddressVM.PoliceStationId);
                ViewBag.CollapseValue = "collapsePermanentAddress";

                //Add New
                ViewBag.PermanentAddressUpazillaId = new SelectList(_UpazillaService.List().entity, "Id", "Name", employeeViewModel.PermanentAddressVM.UpazillaId);
                ViewBag.PermanentAddressUnionId = new SelectList(_UnionService.List().entity, "Id", "Name", employeeViewModel.PermanentAddressVM.UnionId);
            }
            else
            {
                List<DivisionVM> returnPermanentAddressDivisionResponse = dc.GetDivisions();
                ViewBag.PermanentAddressDivisionId = new SelectList(returnPermanentAddressDivisionResponse, "Id", "DivisionName");
                ViewBag.PermanentAddressDistrictId = new SelectList("");
                ViewBag.PermanentAddressPoliceStationId = new SelectList("");

                //Add New
                ViewBag.PermanentAddressUpazillaId = new SelectList("");
                ViewBag.PermanentAddressUnionId = new SelectList("");
            }
            //Permanent Address end

            //Educational Qualification started
            if (Session["EducationalQualificationId"] != null || Session["EducationalQualificationData"] != null)
            {
                ViewBag.TabIndex = 2;
                employeeViewModel.EducationalQualificationVM = GetEducationalQualificationData();
                List<DegreeVM> returnEducationalQualificationDegreeResponse = dc.GetDegrees();
                int bangla = 1;

                //if(bangla == 1)
                //{
                ViewBag.DegreeId = new SelectList(returnEducationalQualificationDegreeResponse, "Id", "DegreeName", employeeViewModel.EducationalQualificationVM.DegreeId);

                //}
                //else
                //{
                //    ViewBag.DegreeId = new SelectList(returnEducationalQualificationDegreeResponse, "Id", "DegreeNameBangla", employeeViewModel.EducationalQualificationVM.DegreeId);

                //}
                ViewBag.CollapseValue = "collapseEducationalQualification";
            }
            else
            {
                List<DegreeVM> returnEducationalQualificationDegreeResponse = dc.GetDegrees();
                ViewBag.DegreeId = new SelectList(returnEducationalQualificationDegreeResponse, "Id", "DegreeName");
            }
            //Educational Qualification end

            //Training Information started
            if (Session["TrainingInformationId"] != null || Session["TrainingInformationData"] != null)
            {
                ViewBag.TabIndex = 2;
                employeeViewModel.TrainingInformationVM = GetTrainingInformationData();
                List<DropdownVM> returnTrainingInformationCountryResponse = dc.GetCountries();
                ViewBag.CountryId = new SelectList(returnTrainingInformationCountryResponse, "Id", "Name", employeeViewModel.TrainingInformationVM.CountryId);
                List<DropdownVM> returnTrainingInformationTrainingTypeResponse = dc.GetTrainingTypes();
                ViewBag.TrainingTypeId = new SelectList(returnTrainingInformationTrainingTypeResponse, "Id", "Name", employeeViewModel.TrainingInformationVM.TrainingTypeId);
                ViewBag.CollapseValue = "collapseTrainingInformation";
            }
            else
            {
                List<DropdownVM> returnTrainingInformationCountryResponse = dc.GetCountries();
                ViewBag.CountryId = new SelectList(returnTrainingInformationCountryResponse, "Id", "Name");
                List<DropdownVM> returnTrainingInformationTrainingTypeResponse = dc.GetTrainingTypes();
                ViewBag.TrainingTypeId = new SelectList(returnTrainingInformationTrainingTypeResponse, "Id", "Name");

            }
            //Training Information end

            //Service History started
            if (Session["ServiceHistoryId"] != null || Session["ServiceHistoryData"] != null)
            {
                ViewBag.TabIndex = 3;
                employeeViewModel.ServiceHistoryVM = GetServiceHistoryData();
                List<DropdownVM> returnServiceHistoryCadreResponse = dc.GetCadres();
                ViewBag.CadreId = new SelectList(returnServiceHistoryCadreResponse, "Id", "Name", employeeViewModel.ServiceHistoryVM.CadreId);
                ViewBag.CollapseValue = "collapseServiceHistory";
            }
            else
            {
                List<DropdownVM> returnServiceHistoryCadreResponse = dc.GetCadres();
                ViewBag.CadreId = new SelectList(returnServiceHistoryCadreResponse, "Id", "Name", employeeViewModel.ServiceHistoryVM.CadreId);

            }
            //Service History end

            //Promotion Partculars started
            if (Session["PromotionPartcularsId"] != null || Session["PromotionPartcularsData"] != null)
            {
                ViewBag.TabIndex = 3;
                employeeViewModel.PromotionPartcularsVM = GetPromotionPartcularsData();
                List<RankVM> returnPromotionPartcularsRankResponse = dc.GetRanks();
                ViewBag.PromotionPartcularsRankId = new SelectList(returnPromotionPartcularsRankResponse, "Id", "RankName", employeeViewModel.PromotionPartcularsVM.RankId);

                ICollection<DesignationVM> returnPromotionPartcularsDesignationResponse = new List<DesignationVM>();
                if (employeeViewModel.PromotionPartcularsVM.RankId != null)
                {
                    returnPromotionPartcularsDesignationResponse = dc.GetDesignationByRankId((long)employeeViewModel.PromotionPartcularsVM.RankId);
                }
                ViewBag.PromotionPartcularsDesignationId = new SelectList(returnPromotionPartcularsDesignationResponse, "Id", "DesignationName", employeeViewModel.PromotionPartcularsVM.DesignationId);
                List<PromtionNatureVM> returnPromotionPartcularsNatureOfPromotionResponse = dc.GetNatureOfPromotions();
                ViewBag.PromotionPartcularsNatureOfPromotionId = new SelectList(returnPromotionPartcularsNatureOfPromotionResponse, "Id", "PromtionNatureName", employeeViewModel.PromotionPartcularsVM.PromtionNatureId);
                List<PayScaleYearInfoVM> returnPromotionPartcularsYearOfPayScalesResponse = dc.GetYearOfPayScales();
                ViewBag.PromotionPartcularsYearOfPayScaleId = new SelectList(returnPromotionPartcularsYearOfPayScalesResponse, "Id", "PayScaleYearInfoName", employeeViewModel.PromotionPartcularsVM.PayScaleYearInfoId);

                ViewBag.CollapseValue = "collapsePromotionPartculars";
            }
            else
            {
                List<RankVM> returnPromotionPartcularsRankResponse = dc.GetRanks();
                ViewBag.PromotionPartcularsRankId = new SelectList(returnPromotionPartcularsRankResponse, "Id", "RankName");
                ViewBag.PromotionPartcularsDesignationId = new SelectList("");
                List<PromtionNatureVM> returnPromotionPartcularsNatureOfPromotionResponse = dc.GetNatureOfPromotions();
                ViewBag.PromotionPartcularsNatureOfPromotionId = new SelectList(returnPromotionPartcularsNatureOfPromotionResponse, "Id", "PromtionNatureName");
                List<PayScaleYearInfoVM> returnPromotionPartcularsYearOfPayScalesResponse = dc.GetYearOfPayScales();
                ViewBag.PromotionPartcularsYearOfPayScaleId = new SelectList(returnPromotionPartcularsYearOfPayScalesResponse, "Id", "PayScaleYearInfoName");

            }
            //Promotion Partculars end

            //Disciplinary Actions started
            if (Session["DisciplinaryActionsId"] != null || Session["DisciplinaryActionsData"] != null)
            {
                ViewBag.TabIndex = 4;
                employeeViewModel.DisciplinaryActionsAndCriminalProsecutionVM = GetDisciplinaryActionsData();
                List<CategoryVM> returnDisciplinaryActionsCategoryResponse = dc.GetCategories();
                ViewBag.DisciplinaryActionsCategoryId = new SelectList(returnDisciplinaryActionsCategoryResponse, "Id", "CategoryName", employeeViewModel.DisciplinaryActionsAndCriminalProsecutionVM.CategoryId);
                ICollection<PresentStatusVM> returnDisciplinaryActionsPresentStatusResponse = dc.GetPresentStatus();
                ViewBag.DisciplinaryActionsPresentStatusId = new SelectList(returnDisciplinaryActionsPresentStatusResponse, "Id", "PresentStatusName", employeeViewModel.DisciplinaryActionsAndCriminalProsecutionVM.PresentStatusId);

                ViewBag.CollapseValue = "collapseDisciplinaryActions";
            }
            else
            {
                List<CategoryVM> returnDisciplinaryActionsCategoryResponse = dc.GetCategories();
                ViewBag.DisciplinaryActionsCategoryId = new SelectList(returnDisciplinaryActionsCategoryResponse, "Id", "CategoryName");
                ICollection<PresentStatusVM> returnDisciplinaryActionsPresentStatusResponse = dc.GetPresentStatus();
                ViewBag.DisciplinaryActionsPresentStatusId = new SelectList(returnDisciplinaryActionsPresentStatusResponse, "Id", "PresentStatusName");


            }
            //Disciplinary Actions end

            //Posting Records started
            if (Session["PostingRecordsId"] != null || Session["PostingRecordsData"] != null)
            {
                ViewBag.TabIndex = 5;
                employeeViewModel.PostingRecordsVM = GetPostingRecordsData();
                List<RankVM> returnPostingRecordsRankResponse = dc.GetRanks();
                ViewBag.PostingRecordsRankId = new SelectList(returnPostingRecordsRankResponse, "Id", "RankName", employeeViewModel.PostingRecordsVM.RankId);
                List<DesignationClassVM> returnPostingRecordsDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.PostingRecordsDesignationClassId = new SelectList(returnPostingRecordsDesignationClassResponse, "Id", "DesignationClassName", employeeViewModel.PostingRecordsVM.DesignationClassId);
                List<DesignationVM> returnPostingRecordsDesignationResponse = new List<DesignationVM>();
                if (employeeViewModel.PostingRecordsVM.DesignationClassId != null)
                {
                    returnPostingRecordsDesignationResponse = dc.GetDesignationByDesignationClassId((long)employeeViewModel.PostingRecordsVM.DesignationClassId);
                }
                ViewBag.PostingRecordsDesignationId = new SelectList(returnPostingRecordsDesignationResponse, "Id", "DesignationName", employeeViewModel.PostingRecordsVM.DesignationId);
                List<PostResponsibilityVM> returnPostingRecordsPostResponsibilityResponse = dc.GetPostResponsibilities();
                ViewBag.PostingRecordsPostResponsibilityId = new SelectList(returnPostingRecordsPostResponsibilityResponse, "Id", "PostResponsibilityName", employeeViewModel.PostingRecordsVM.PostResponsibilityId);
                List<PostingTypeVM> returnPostingRecordsPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingRecordsPostingTypeId = new SelectList(returnPostingRecordsPostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.PostingRecordsVM.MainPostingTypeId);
                List<PostingVM> returnPostingRecordsPostingResponse = new List<PostingVM>();
                if (employeeViewModel.PostingRecordsVM.MainPostingTypeId != null)
                {
                    returnPostingRecordsPostingResponse = dc.GetPostingByPostingTypesId((long)employeeViewModel.PostingRecordsVM.MainPostingTypeId);

                }
                ViewBag.PostingRecordsPostingId = new SelectList(returnPostingRecordsPostingResponse, "Id", "PostingName", employeeViewModel.PostingRecordsVM.PostingId);
                List<DropdownVM> returnPostingRecordsWorkingAsResponse = dc.GetWorkingAs();
                ViewBag.PostingRecordsWorkingAsId = new SelectList(returnPostingRecordsWorkingAsResponse, "Id", "Name", employeeViewModel.PostingRecordsVM.WorkingAsId);

                List<DivisionVM> returnPostingRecordsFromDivisionResponse = dc.GetDivisions();
                ViewBag.PostingRecordsFromDivisionId = new SelectList(returnPostingRecordsFromDivisionResponse, "Id", "DivisionName", employeeViewModel.PostingRecordsVM.TransferFromDivisionId);
                List<DistrictVM> returnPostingRecordsFromDistrictResponse = new List<DistrictVM>();
                if (employeeViewModel.PostingRecordsVM.TransferFromDivisionId != null)
                {
                    returnPostingRecordsFromDistrictResponse = dc.GetDistrictByDivisionId((long)employeeViewModel.PostingRecordsVM.TransferFromDivisionId);

                }
                ViewBag.PostingRecordsFromDistrictId = new SelectList(returnPostingRecordsFromDistrictResponse, "Id", "DistrictName", employeeViewModel.PostingRecordsVM.TransferFromDistrictId);
                List<DivisionVM> returnPostingRecordsToDivisionResponse = dc.GetDivisions();
                ViewBag.PostingRecordsToDivisionId = new SelectList(returnPostingRecordsToDivisionResponse, "Id", "DivisionName", employeeViewModel.PostingRecordsVM.TransferToDivisionId);
                List<DistrictVM> returnPostingRecordsToDistrictResponse = new List<DistrictVM>();
                if (employeeViewModel.PostingRecordsVM.TransferToDivisionId != null)
                {
                    returnPostingRecordsToDistrictResponse = dc.GetDistrictByDivisionId((long)employeeViewModel.PostingRecordsVM.TransferToDivisionId);
                }
                ViewBag.PostingRecordsToDistrictId = new SelectList(returnPostingRecordsToDistrictResponse, "Id", "DistrictName", employeeViewModel.PostingRecordsVM.TransferToDistrictId);


                List<DesignationClassVM> returnPostingRecordsCurrDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsCurrDesignationClassResponse, "Id", "DesignationClassName", employeeViewModel.PostingRecordsVM.CurrDesignationClassId);
                List<DesignationVM> returnPostingRecordsCrntDesgResponse = new List<DesignationVM>();
                if (employeeViewModel.PostingRecordsVM.DesignationClassId != null)
                {
                    returnPostingRecordsCrntDesgResponse = dc.GetDesignationByDesignationClassId((long)employeeViewModel.PostingRecordsVM.DesignationClassId);

                }
                ViewBag.PostingRecordsCrntDesgId = new SelectList(returnPostingRecordsCrntDesgResponse, "Id", "DesignationName", employeeViewModel.PostingRecordsVM.CrntDesgId);
                List<PostingTypeVM> returnPostingRecordsDeppostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingRecordsDeppostingTypeId = new SelectList(returnPostingRecordsDeppostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.PostingRecordsVM.DeppostingTypeId);
                List<PostingVM> returnPostingRecordsDepPostingResponse = new List<PostingVM>();
                if (employeeViewModel.PostingRecordsVM.MainPostingTypeId != null)
                {
                    returnPostingRecordsDepPostingResponse = dc.GetPostingByPostingTypesId((long)employeeViewModel.PostingRecordsVM.MainPostingTypeId);
                }

                ViewBag.PostingRecordsDepPostingId = new SelectList(returnPostingRecordsDepPostingResponse, "Id", "PostingName", employeeViewModel.PostingRecordsVM.DepPostingId);



                ViewBag.CollapseValue = "collapsePostingRecords";
            }
            else
            {
                List<RankVM> returnPostingRecordsRankResponse = dc.GetRanks();
                ViewBag.PostingRecordsRankId = new SelectList(returnPostingRecordsRankResponse, "Id", "RankName");
                List<DesignationClassVM> returnPostingRecordsDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.PostingRecordsDesignationClassId = new SelectList(returnPostingRecordsDesignationClassResponse, "Id", "DesignationClassName");
                ViewBag.PostingRecordsDesignationId = new SelectList("");
                List<PostResponsibilityVM> returnPostingRecordsPostResponsibilityResponse = dc.GetPostResponsibilities();
                ViewBag.PostingRecordsPostResponsibilityId = new SelectList(returnPostingRecordsPostResponsibilityResponse, "Id", "PostResponsibilityName");
                List<PostingTypeVM> returnPostingRecordsPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingRecordsPostingTypeId = new SelectList(returnPostingRecordsPostingTypeResponse, "Id", "PostingTypeName");
                ViewBag.PostingRecordsPostingId = new SelectList("");
                List<DropdownVM> returnPostingRecordsWorkingAsResponse = dc.GetWorkingAs();
                ViewBag.PostingRecordsWorkingAsId = new SelectList(returnPostingRecordsWorkingAsResponse, "Id", "Name");
                List<DivisionVM> returnPostingRecordsFromDivisionResponse = dc.GetDivisions();
                ViewBag.PostingRecordsFromDivisionId = new SelectList(returnPostingRecordsFromDivisionResponse, "Id", "DivisionName");
                ViewBag.PostingRecordsFromDistrictId = new SelectList("");
                List<DivisionVM> returnPostingRecordsToDivisionResponse = dc.GetDivisions();
                ViewBag.PostingRecordsToDivisionId = new SelectList(returnPostingRecordsToDivisionResponse, "Id", "DivisionName");
                ViewBag.PostingRecordsToDistrictId = new SelectList("");


                List<DesignationClassVM> returnPostingRecordsCurrDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsCurrDesignationClassResponse, "Id", "DesignationClassName");
                ViewBag.PostingRecordsCrntDesgId = new SelectList("");
                List<PostingTypeVM> returnPostingRecordsDeppostingTypeResponse = dc.GetPostingTypes();
                ViewBag.PostingRecordsDeppostingTypeId = new SelectList(returnPostingRecordsDeppostingTypeResponse, "Id", "PostingTypeName");
                ViewBag.PostingRecordsDepPostingId = new SelectList("");


            }
            //Posting Records end

            //Official Information started
            if (Session["OfficialInformationId"] != null || Session["OfficialInformationData"] != null)
            {
                ViewBag.TabIndex = 0;
                Session["OfficialInformationId"] = null;
                Session["OfficialInformationData"] = null;
                //employeeViewModel.OfficialInformationVM = GetOfficialInformationData();
                OfficialInformationFilterVM officialFilterVM = new OfficialInformationFilterVM();
                officialFilterVM.EmployeeInformationId = (long)id;
                // employeeViewModel.OfficialInformationVM = returnResponse.entity.OfficialInformation.FirstOrDefault();
                (ExecutionState executionState, List<OfficialInformationVM> entity, string message) returnOfficialResponse = _OfficialInformationService.GetFilterData(officialFilterVM);

                ViewBag.OrganogramOfficeTypes = EnumHelper.GetEnumDropdowns<OrganogramOfficeType>();

                employeeViewModel.OfficialInformationVM = returnOfficialResponse.entity != null ? returnOfficialResponse.entity.FirstOrDefault() : new OfficialInformationVM();
                List<DropdownVM> returnOfficialInformationGetCadres = dc.GetCadres();
                ViewBag.OfficialInformationCadreId = new SelectList(returnOfficialInformationGetCadres, "Id", "Name", employeeViewModel.OfficialInformationVM.CadreId);

                List<DropdownVM> returnOfficialInformationRecruitPromo = dc.GetRecruitPromos();
                ViewBag.OfficialInformationRecruitPromoId = new SelectList(returnOfficialInformationRecruitPromo, "Id", "Name", employeeViewModel.OfficialInformationVM.CadreId);


                List<RankVM> returnOfficialInformationJoiningRank = dc.GetRanks();
                ViewBag.OfficialInformationJoiningRankId = new SelectList(returnOfficialInformationJoiningRank, "Id", "RankName", employeeViewModel.OfficialInformationVM.JoiningRankId);
                List<RankVM> returnOfficialInformationPresentRank = dc.GetRanks();
                ViewBag.OfficialInformationPresentRankId = new SelectList(returnOfficialInformationPresentRank, "Id", "RankName", employeeViewModel.OfficialInformationVM.PresentRankId);


                ICollection<DesignationClassVM> returnOfficialInformationPresentDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationPresentDesignationClassId = new SelectList(returnOfficialInformationPresentDesignationClassResponse, "Id", "DesignationClassName", employeeViewModel.OfficialInformationVM.PresentDesignationClassId);
                ICollection<DesignationClassVM> returnOfficialInformationJoiningDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationJoiningDesignationClassId = new SelectList(returnOfficialInformationJoiningDesignationClassResponse, "Id", "DesignationClassName", employeeViewModel.OfficialInformationVM.JoiningDesignationClassId);
                ICollection<DesignationClassVM> returnOfficialInformationCurrDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationCurrDesignationClassId = new SelectList(returnOfficialInformationCurrDesignationClassResponse, "Id", "DesignationClassName", employeeViewModel.OfficialInformationVM.CurrDesignationClassId);

                ICollection<DesignationVM> returnOfficialInformationJoiningDesignationResponse = dc.GetDesignations();
                ViewBag.OfficialInformationJoiningDesignationId = new SelectList(returnOfficialInformationJoiningDesignationResponse, "Id", "DesignationName", employeeViewModel.OfficialInformationVM.JoiningDesgId);
                ICollection<DesignationVM> returnOfficialInformationPresentDesignationResponse = dc.GetDesignations();
                ViewBag.OfficialInformationPresentDesignationId = new SelectList(returnOfficialInformationPresentDesignationResponse, "Id", "DesignationName", employeeViewModel.OfficialInformationVM.PresentDesignationId);
                ICollection<DesignationVM> returnOfficialInformationCrntDesgResponse = dc.GetDesignations();
                ViewBag.OfficialInformationCrntDesgId = new SelectList(returnOfficialInformationCrntDesgResponse, "Id", "DesignationName", employeeViewModel.OfficialInformationVM.CrntDesgId);

                ICollection<PostResponsibilityVM> returnOfficialInformationPostResponsibilityResponse = dc.GetPostResponsibilities();
                ViewBag.OfficialInformationPostResponsibilityId = new SelectList(returnOfficialInformationPostResponsibilityResponse, "Id", "PostResponsibilityName", employeeViewModel.OfficialInformationVM.PostResponsibilityId);
                ICollection<PromtionNatureVM> returnOfficialInformationPromtionNatureResponse = dc.GetPromotionNatures();
                ViewBag.OfficialInformationPromtionNatureId = new SelectList(returnOfficialInformationPromtionNatureResponse, "Id", "PromtionNatureName", employeeViewModel.OfficialInformationVM.PromtionNatureId);
                ICollection<PostingTypeVM> returnOfficialInformationPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationPostingTypeId = new SelectList(returnOfficialInformationPostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.OfficialInformationVM.PostingTypeId);
                ICollection<PostingTypeVM> returnOfficialInformationJoiningPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationJoiningPostingTypeId = new SelectList(returnOfficialInformationJoiningPostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.OfficialInformationVM.JoinPostingTypeId);
                ICollection<PostingTypeVM> returnOfficialInformationDepPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationDepPostingTypeId = new SelectList(returnOfficialInformationDepPostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.OfficialInformationVM.DeppostingTypeId);

                ICollection<PostingVM> returnOfficialInformationPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationPostingId = new SelectList(returnOfficialInformationPostingResponse, "Id", "PostingName", employeeViewModel.OfficialInformationVM.PostingId);
                ICollection<PostingVM> returnOfficialInformationJoiningPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationJoiningPostingId = new SelectList(returnOfficialInformationJoiningPostingResponse, "Id", "PostingName", employeeViewModel.OfficialInformationVM.JoinPostingId);
                ICollection<PostingVM> returnOfficialInformationDepPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationDepPostingId = new SelectList(returnOfficialInformationDepPostingResponse, "Id", "PostingName", employeeViewModel.OfficialInformationVM.DepPostingId);


                ICollection<GradationTypeVM> returnOfficialInformationGradationTypeResponse = dc.GetGradationTypess();
                ViewBag.OfficialInformationGradationTypeId = new SelectList(returnOfficialInformationGradationTypeResponse, "Id", "GradationTypeName", employeeViewModel.OfficialInformationVM.GradationTypeId);
                ICollection<EmployeeTypeVM> returnOfficialInformationEmployeeTypeResponse = dc.GetEmployeeTypes();
                ViewBag.OfficialInformationEmployeeTypeId = new SelectList(returnOfficialInformationEmployeeTypeResponse, "Id", "EmployeeTypeName", employeeViewModel.OfficialInformationVM.EmployeeTypeId);
                ICollection<JobCategoryVM> returnOfficialInformationJobCategoryResponse = dc.GetJobCategories();
                ViewBag.OfficialInformationJobCategoryId = new SelectList(returnOfficialInformationJobCategoryResponse, "Id", "JobCategoryName", employeeViewModel.OfficialInformationVM.JobCategoryId);


                ViewBag.CollapseValue = "collapseOfficialInformation";
            }
            else
            {
                //if(returnResponse.entity.OfficialInformation != null && returnResponse.entity.OfficialInformation.Count() > 0)
                //{
                OfficialInformationFilterVM officialFilterVM = new OfficialInformationFilterVM();
                officialFilterVM.EmployeeInformationId = (long)id;
                // employeeViewModel.OfficialInformationVM = returnResponse.entity.OfficialInformation.FirstOrDefault();
                (ExecutionState executionState, List<OfficialInformationVM> entity, string message) returnOfficialResponse = _OfficialInformationService.GetFilterData(officialFilterVM);

                employeeViewModel.OfficialInformationVM = returnOfficialResponse.entity != null ? returnOfficialResponse.entity.FirstOrDefault() : new OfficialInformationVM();

                ViewBag.OrganogramOfficeTypes = EnumHelper.GetEnumDropdowns<OrganogramOfficeType>();

                //}
                List<DropdownVM> returnOfficialInformationGetCadres = dc.GetCadres();
                ViewBag.OfficialInformationCadreId = new SelectList(returnOfficialInformationGetCadres, "Id", "Name");

                List<DropdownVM> returnOfficialInformationRecruitPromo = dc.GetRecruitPromos();
                ViewBag.OfficialInformationRecruitPromoId = new SelectList(returnOfficialInformationRecruitPromo, "Id", "Name");

                List<RankVM> returnOfficialInformationJoiningRank = dc.GetRanks();
                ViewBag.OfficialInformationJoiningRankId = new SelectList(returnOfficialInformationJoiningRank, "Id", "RankName");
                List<RankVM> returnOfficialInformationPresentRank = dc.GetRanks();
                ViewBag.OfficialInformationPresentRankId = new SelectList(returnOfficialInformationPresentRank, "Id", "RankName");

                ICollection<DesignationClassVM> returnOfficialInformationPresentDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationPresentDesignationClassId = new SelectList(returnOfficialInformationPresentDesignationClassResponse, "Id", "DesignationClassName");
                ICollection<DesignationClassVM> returnOfficialInformationJoiningDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationJoiningDesignationClassId = new SelectList(returnOfficialInformationJoiningDesignationClassResponse, "Id", "DesignationClassName");
                ICollection<DesignationClassVM> returnOfficialInformationCurrDesignationClassResponse = dc.GetDesignationClasses();
                ViewBag.OfficialInformationCurrDesignationClassId = new SelectList(returnOfficialInformationCurrDesignationClassResponse, "Id", "DesignationClassName");

                ICollection<DesignationVM> returnOfficialInformationJoiningDesignationResponse = dc.GetDesignations();
                ViewBag.OfficialInformationJoiningDesignationId = new SelectList(returnOfficialInformationJoiningDesignationResponse, "Id", "DesignationName");
                ICollection<DesignationVM> returnOfficialInformationPresentDesignationResponse = dc.GetDesignations();
                ViewBag.OfficialInformationPresentDesignationId = new SelectList(returnOfficialInformationPresentDesignationResponse, "Id", "DesignationName");
                ICollection<DesignationVM> returnOfficialInformationCrntDesgResponse = dc.GetDesignations();
                ViewBag.OfficialInformationCrntDesgId = new SelectList(returnOfficialInformationCrntDesgResponse, "Id", "DesignationName");

                ICollection<PostResponsibilityVM> returnOfficialInformationPostResponsibilityResponse = dc.GetPostResponsibilities();
                ViewBag.OfficialInformationPostResponsibilityId = new SelectList(returnOfficialInformationPostResponsibilityResponse, "Id", "PostResponsibilityName");
                ICollection<PromtionNatureVM> returnOfficialInformationPromtionNatureResponse = dc.GetPromotionNatures();
                ViewBag.OfficialInformationPromtionNatureId = new SelectList(returnOfficialInformationPromtionNatureResponse, "Id", "PromtionNatureName");
                ICollection<PostingTypeVM> returnOfficialInformationPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationPostingTypeId = new SelectList(returnOfficialInformationPostingTypeResponse, "Id", "PostingTypeName");
                ICollection<PostingTypeVM> returnOfficialInformationJoiningPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationJoiningPostingTypeId = new SelectList(returnOfficialInformationJoiningPostingTypeResponse, "Id", "PostingTypeName");
                ICollection<PostingTypeVM> returnOfficialInformationDepPostingTypeResponse = dc.GetPostingTypes();
                ViewBag.OfficialInformationDepPostingTypeId = new SelectList(returnOfficialInformationDepPostingTypeResponse, "Id", "PostingTypeName");

                ICollection<PostingVM> returnOfficialInformationPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationPostingId = new SelectList(returnOfficialInformationPostingResponse, "Id", "PostingName");
                ICollection<PostingVM> returnOfficialInformationJoiningPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationJoiningPostingId = new SelectList(returnOfficialInformationJoiningPostingResponse, "Id", "PostingName");
                ICollection<PostingVM> returnOfficialInformationDepPostingResponse = dc.GetPostings();
                ViewBag.OfficialInformationDepPostingId = new SelectList(returnOfficialInformationDepPostingResponse, "Id", "PostingName");

                ICollection<GradationTypeVM> returnOfficialInformationGradationTypeResponse = dc.GetGradationTypess();
                ViewBag.OfficialInformationGradationTypeId = new SelectList(returnOfficialInformationGradationTypeResponse, "Id", "GradationTypeName");
                ICollection<EmployeeTypeVM> returnOfficialInformationEmployeeTypeResponse = dc.GetEmployeeTypes();
                ViewBag.OfficialInformationEmployeeTypeId = new SelectList(returnOfficialInformationEmployeeTypeResponse, "Id", "EmployeeTypeName");
                ICollection<JobCategoryVM> returnOfficialInformationJobCategoryResponse = dc.GetJobCategories();
                ViewBag.OfficialInformationJobCategoryId = new SelectList(returnOfficialInformationJobCategoryResponse, "Id", "JobCategoryName");

            }
            //Official Information end

            //Language Info started
            if (Session["LanguageInformationId"] != null || Session["LanguageInformationData"] != null)
            {
                ViewBag.TabIndex = 5;
                employeeViewModel.LanguageInformationVM = GetLanguageInformationData();
                List<LanguageVM> returnLanguageResponse = dc.GetLanguages();
                ViewBag.LanguageId = new SelectList(returnLanguageResponse, "Id", "LanguageName", employeeViewModel.LanguageInformationVM.Id);
                ViewBag.CollapseValue = "collapseLanguage";
            }
            else
            {
                List<LanguageVM> returnLanguageResponse = dc.GetLanguages();
                ViewBag.LanguageId = new SelectList(returnLanguageResponse, "Id", "LanguageName");
            }
            //Language Info end


            employeeViewModel.SpouseInformationLists = returnResponse.entity.SpouseInformationList;
            employeeViewModel.ChildrenInformationLists = returnResponse.entity.ChildrenInformationList;
            employeeViewModel.PresentAddressLists = returnResponse.entity.PresentAddressesList;
            employeeViewModel.PermanentAddressLists = returnResponse.entity.PermanentAddressesList;
            employeeViewModel.EducationalQualificationLists = returnResponse.entity.EducationalQualificationList;
            employeeViewModel.TrainingInformationLists = returnResponse.entity.TrainingInformationList;
            employeeViewModel.ServiceHistoryLists = returnResponse.entity.ServiceHistoriesList;
            employeeViewModel.PromotionPartcularLists = returnResponse.entity.PromotionPartcularsList;
            employeeViewModel.DisciplinaryActionsAndCriminalProsecutionLists = returnResponse.entity.DisciplinaryActionsAndCriminalProsecutionsList;
            employeeViewModel.PostingRecordLists = returnResponse.entity.PostingRecordsList;
            employeeViewModel.EmployeeTransferLists = returnResponse.entity.EmployeeTransfersList;
            employeeViewModel.LanguageInformationLists = returnResponse.entity.LanguageInformationsList;

            ViewBag.FreedomFighterInformationId = new SelectList(EnumHelper.GetEnumDropdowns<FreedomFighterInformation>(), "Id", "Name");



            //Multi add
            List<RankVM> JoiningRank = dc.GetRanks();
            ViewBag.JoiningRankId = new SelectList(JoiningRank, "Id", "RankName", employeeViewModel.OfficialInformationVM.JoiningRankId);
            //ViewBag.OfficeTypeId = EnumHelper.GetEnumDropdowns<OrganogramOfficeType>();

            ViewBag.OfficeType = new SelectList(EnumHelper.GetEnumDropdowns<OrganogramOfficeType>(), "Id", "Name");


            ICollection<DesignationVM> desgResponse = dc.GetDesignations();
            ViewBag.DesignationTypeId = new SelectList(desgResponse, "Id", "DesignationName");
            ICollection<PostingTypeVM> postingTypeResponse = dc.GetPostingTypes();
            ViewBag.PostingTypeId = new SelectList(postingTypeResponse, "Id", "PostingTypeName");
            ICollection<PostingVM> postingResponse = dc.GetPostings();
            ViewBag.PostingId = new SelectList(postingResponse, "Id", "PostingName");
            List<DesignationClassVM> designationClassResponse = dc.GetDesignationClasses();
            ViewBag.DesignationClassId = new SelectList(designationClassResponse, "Id", "DesignationClassName", employeeViewModel.PostingRecordsVM.DesignationClassId);
            ICollection<DesignationVM> designationResponse = dc.GetDesignations();
            ViewBag.DesignationId = new SelectList(designationResponse, "Id", "DesignationName");
            ICollection<GradationTypeVM> gradationTypeResponse = dc.GetGradationTypess();
            ViewBag.GradationTypeId = new SelectList(gradationTypeResponse, "Id", "GradationTypeName", employeeViewModel.OfficialInformationVM.GradationTypeId);
            ICollection<EmployeeTypeVM> employeeTypeResponse = dc.GetEmployeeTypes();
            ViewBag.EmployeeTypeId = new SelectList(employeeTypeResponse, "Id", "EmployeeTypeName");
            ICollection<JobCategoryVM> jobCategoryResponse = dc.GetJobCategories();
            ViewBag.JobCategoryId = new SelectList(jobCategoryResponse, "Id", "JobCategoryName", employeeViewModel.OfficialInformationVM.JobCategoryId);
            List<PostResponsibilityVM> postResponsibilityResponse = dc.GetPostResponsibilities();
            ViewBag.PostResponsibilityId = new SelectList(postResponsibilityResponse, "Id", "PostResponsibilityName", employeeViewModel.PostingRecordsVM.PostResponsibilityId);
            List<DropdownVM> RecruitPromo = dc.GetRecruitPromos();
            ViewBag.RecruitPromoId = new SelectList(RecruitPromo, "Id", "Name", employeeViewModel.OfficialInformationVM.CadreId);
            List<PromtionNatureVM> natureOfPromotionResponse = dc.GetNatureOfPromotions();
            ViewBag.PromtionNatureId = new SelectList(natureOfPromotionResponse, "Id", "PromtionNatureName", employeeViewModel.PromotionPartcularsVM.PromtionNatureId);

            List<PostingTypeVM> deppostingTypeResponse = dc.GetPostingTypes();
            ViewBag.DeppostingTypeId = new SelectList(deppostingTypeResponse, "Id", "PostingTypeName", employeeViewModel.PostingRecordsVM.DeppostingTypeId);



            //ViewBag.CadreId = EnumHelper.GetEnumDropdowns<Cadre>();

            ViewBag.CadreId = new SelectList(EnumHelper.GetEnumDropdowns<Cadre>(), "Id", "Name");


            //ViewBag.PostingDetailsId = EnumHelper.GetEnumDropdowns<PostingDetails>();

            ViewBag.PostingDetailsId = new SelectList(EnumHelper.GetEnumDropdowns<PostingDetails>(), "Id", "Name");


            return View(employeeViewModel);
        }

        public SpouseInformationVM GetSpouseInformationData()
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnSingleSpouseInfo;
            if (Session["SpouseData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleSpouseInfo.entity = (SpouseInformationVM)Session["SpouseData"];
                }
                else
                {
                    returnSingleSpouseInfo.entity = new SpouseInformationVM();
                }

            }
            else
            {
                long spouseid = Convert.ToInt64(Session["SpouseInformationId"].ToString());
                returnSingleSpouseInfo = _SpouseInformationService.GetById(spouseid);

            }
            Session["SpouseInformationId"] = null;
            Session["SpouseData"] = null;
            return returnSingleSpouseInfo.entity;
        }

        public LanguageInformationVM GetLanguageInformationData()
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnSingleLanguageInfo;
            if (Session["LanguageInformationData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleLanguageInfo.entity = (LanguageInformationVM)Session["LanguageInformationData"];
                }
                else
                {
                    returnSingleLanguageInfo.entity = new LanguageInformationVM();
                }

            }
            else
            {
                long Languageid = Convert.ToInt64(Session["LanguageInformationId"].ToString());
                returnSingleLanguageInfo = _LanguageInformationService.GetById(Languageid);

            }
            Session["LanguageInformationId"] = null;
            Session["LanguageInformationData"] = null;
            return returnSingleLanguageInfo.entity;
        }

        public ChildrenInformationVM GetChildrenInformationData()
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnSingleChildrenInfo;
            if (Session["ChildrenInformationData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleChildrenInfo.entity = (ChildrenInformationVM)Session["ChildrenInformationData"];
                }
                else
                {
                    returnSingleChildrenInfo.entity = new ChildrenInformationVM();
                }

            }
            else
            {
                long childrenid = Convert.ToInt64(Session["ChildrenInformationId"].ToString());
                returnSingleChildrenInfo = _ChildrenInformationService.GetById(childrenid);

            }
            Session["ChildrenInformationId"] = null;
            Session["ChildrenInformationData"] = null;
            return returnSingleChildrenInfo.entity;
        }

        public PresentAddressVM GetPresentAddressData()
        {
            (ExecutionState executionState, PresentAddressVM entity, string message) returnSinglePresentAddress;
            if (Session["PresentAddressData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSinglePresentAddress.entity = (PresentAddressVM)Session["PresentAddressData"];
                }
                else
                {
                    returnSinglePresentAddress.entity = new PresentAddressVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["PresentAddressId"].ToString());
                returnSinglePresentAddress = _PresentAddressService.GetById(pid);

            }
            Session["PresentAddressId"] = null;
            Session["PresentAddressData"] = null;
            return returnSinglePresentAddress.entity;
        }
        public PermanentAddressVM GetPermanentAddressData()
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnSinglePermanentAddress;
            if (Session["PermanentAddressData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSinglePermanentAddress.entity = (PermanentAddressVM)Session["PermanentAddressData"];
                }
                else
                {
                    returnSinglePermanentAddress.entity = new PermanentAddressVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["PermanentAddressId"].ToString());
                returnSinglePermanentAddress = _PermanentAddressService.GetById(pid);

            }
            Session["PermanentAddressId"] = null;
            Session["PermanentAddressData"] = null;
            return returnSinglePermanentAddress.entity;
        }

        public EducationalQualificationVM GetEducationalQualificationData()
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnSingleEducationalQualification;
            if (Session["EducationalQualificationData"] != null)
            {

                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleEducationalQualification.entity = (EducationalQualificationVM)Session["EducationalQualificationData"];
                }
                else
                {
                    returnSingleEducationalQualification.entity = new EducationalQualificationVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["EducationalQualificationId"].ToString());
                returnSingleEducationalQualification = _EducationalQualificationService.GetById(pid);

            }
            Session["EducationalQualificationId"] = null;
            Session["EducationalQualificationData"] = null;
            return returnSingleEducationalQualification.entity;
        }
        public TrainingInformationVM GetTrainingInformationData()
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnSingleTrainingInformation;
            if (Session["TrainingInformationData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleTrainingInformation.entity = (TrainingInformationVM)Session["TrainingInformationData"];
                }
                else
                {
                    returnSingleTrainingInformation.entity = new TrainingInformationVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["TrainingInformationId"].ToString());
                returnSingleTrainingInformation = _TrainingInformationService.GetById(pid);

            }
            Session["TrainingInformationId"] = null;
            Session["TrainingInformationData"] = null;
            return returnSingleTrainingInformation.entity;
        }

        public ServiceHistoryVM GetServiceHistoryData()
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnSingleServiceHistory;
            if (Session["ServiceHistoryData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleServiceHistory.entity = (ServiceHistoryVM)Session["ServiceHistoryData"];
                }
                else
                {
                    returnSingleServiceHistory.entity = new ServiceHistoryVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["ServiceHistoryId"].ToString());
                returnSingleServiceHistory = _ServiceHistoryService.GetById(pid);

            }
            Session["ServiceHistoryId"] = null;
            Session["ServiceHistoryData"] = null;
            return returnSingleServiceHistory.entity;
        }
        public PromotionPartcularsVM GetPromotionPartcularsData()
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnSinglePromotionPartculars;
            if (Session["PromotionPartcularsData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSinglePromotionPartculars.entity = (PromotionPartcularsVM)Session["PromotionPartcularsData"];
                }
                else
                {
                    returnSinglePromotionPartculars.entity = new PromotionPartcularsVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["PromotionPartcularsId"].ToString());
                returnSinglePromotionPartculars = _PromotionPartcularsService.GetById(pid);

            }
            Session["PromotionPartcularsId"] = null;
            Session["PromotionPartcularsData"] = null;
            return returnSinglePromotionPartculars.entity;
        }
        public DisciplinaryActionsAndCriminalProsecutionVM GetDisciplinaryActionsData()
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnSingleDisciplinaryActions;
            if (Session["DisciplinaryActionsData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleDisciplinaryActions.entity = (DisciplinaryActionsAndCriminalProsecutionVM)Session["DisciplinaryActionsData"];
                }
                else
                {
                    returnSingleDisciplinaryActions.entity = new DisciplinaryActionsAndCriminalProsecutionVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["DisciplinaryActionsId"].ToString());
                returnSingleDisciplinaryActions = _DisciplinaryActionsAndCriminalProsecutionService.GetById(pid);

            }
            Session["DisciplinaryActionsId"] = null;
            Session["DisciplinaryActionsData"] = null;
            return returnSingleDisciplinaryActions.entity;
        }

        public PostingRecordsVM GetPostingRecordsData()
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnSinglePostingRecords;
            if (Session["PostingRecordsData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSinglePostingRecords.entity = (PostingRecordsVM)Session["PostingRecordsData"];
                }
                else
                {
                    returnSinglePostingRecords.entity = new PostingRecordsVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["PostingRecordsId"].ToString());
                returnSinglePostingRecords = _PostingRecordsService.GetById(pid);

            }
            Session["PostingRecordsId"] = null;
            Session["PostingRecordsData"] = null;
            return returnSinglePostingRecords.entity;
        }
        public OfficialInformationVM GetOfficialInformationData()
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnSingleOfficialInformation;
            if (Session["OfficialInformationData"] != null)
            {
                if (Session["executionState"].ToString() == "0" || Session["executionState"].ToString() == "Failure")
                {
                    returnSingleOfficialInformation.entity = (OfficialInformationVM)Session["OfficialInformationData"];
                }
                else
                {
                    returnSingleOfficialInformation.entity = new OfficialInformationVM();
                }

            }
            else
            {
                long pid = Convert.ToInt64(Session["OfficialInformationId"].ToString());
                returnSingleOfficialInformation = _OfficialInformationService.GetById(pid);

            }
            Session["OfficialInformationId"] = null;
            Session["OfficialInformationData"] = null;
            return returnSingleOfficialInformation.entity;
        }

        public ActionResult EditSpouseInformation(long? spouseid, long? empid)
        {
            Session["SpouseInformationId"] = spouseid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditLanguageInformation(long? languageid, long? empid)
        {
            Session["LanguageInformationId"] = languageid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditChildrenInformation(long? childrenid, long? empid)
        {
            Session["ChildrenInformationId"] = childrenid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditPresentAddress(long? pid, long? empid)
        {
            Session["PresentAddressId"] = pid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditPermanentAddress(long? pid, long? empid)
        {
            Session["PermanentAddressId"] = pid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditEducationalQualification(long? eid, long? empid)
        {
            Session["EducationalQualificationId"] = eid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditTrainingInformation(long? tid, long? empid)
        {
            Session["TrainingInformationId"] = tid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditServiceHistory(long? sid, long? empid)
        {
            Session["ServiceHistoryId"] = sid;
            return RedirectToAction("Edit", new { id = empid });
        }

        public ActionResult EditPromotionPartculars(long? pid, long? empid)
        {
            Session["PromotionPartcularsId"] = pid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditDisciplinaryActions(long? did, long? empid)
        {
            Session["DisciplinaryActionsId"] = did;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditPostingRecords(long? pid, long? empid)
        {
            Session["PostingRecordsId"] = pid;
            return RedirectToAction("Edit", new { id = empid });
        }
        public ActionResult EditOfficialInformation(long? oid, long? empid)
        {
            Session["OfficialInformationId"] = oid;
            return RedirectToAction("Edit", new { id = empid });
        }


        public (bool success, string Message) ValidateBanglaAndEnglishField(EmployeeInformationVM entity)
        {
            //List<object> data = new List<object>();
            //data.Add((entity.NameBangla, 2));
            //data.Add((entity.NameEnglish, 1));
            //data.Add((entity.FathersNameBangla, 2));
            //data.Add((entity.FathersNameEnglish, 1));
            //data.Add((entity.MothersNameBangla, 2));
            //data.Add((entity.MothersNameEnglish, 1));

            (bool success, string Message) returnResponse;

            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.NameBangla, 2);
            if (returnResponse.success == false)
            {
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.NameEnglish, 1);
            if (returnResponse.success == false)
            {
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.FathersNameBangla, 2);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Father Name Bangla is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.FathersNameEnglish, 1);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Father Name English is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.MothersNameBangla, 2);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Mother Name Bangla is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.MothersNameEnglish, 1);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Mother Name English is Invalid !";
                return returnResponse;
            }

            //returnResponse = _EnglishAndBanglaValidation.ValidateListOfBanglaAndEnglishField(data);
            return returnResponse;
        }
        // POST: EmployeeInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel entityVM)
        {
            EmployeeInformationVM entity = entityVM.EmployeeInformationVM;

            try
            {
                (ExecutionState executionState, List<DivisionVM> entity, string message) returnDivisionResponse = _DivisionService.List();
                ViewBag.DivisionId = new SelectList(returnDivisionResponse.entity, "Id", "DivisionName");
                var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
                                 select new
                                 {
                                     Id = (int)e,
                                     Name = e.ToString()
                                 };
                ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
                var MaritalStatusList = from MaritalStatus e in Enum.GetValues(typeof(MaritalStatus))
                                        select new
                                        {
                                            Id = (int)e,
                                            Name = e.ToString()
                                        };
                ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name", entity.MaritalStatusId);
                var ReligionList = from Religion e in Enum.GetValues(typeof(Religion))
                                   select new
                                   {
                                       Id = (int)e,
                                       Name = e.ToString()
                                   };
                ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name", entity.ReligionId);

                if (ModelState.IsValid)
                {
                    (bool success, string Message) isFormValid = ValidateBanglaAndEnglishField(entity);
                    if (isFormValid.success == false)
                    {
                        Session["Message"] = isFormValid.Message;
                        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
                    }

                    //if (id != entity.Id)
                    //{
                    //    return RedirectToAction(nameof(EmployeeInformationController.Index), "EmployeeInformation");
                    //}

                    if (entity.Photo == null)
                    {
                        (ExecutionState executionState, EmployeeInformationVM entity, string message) returnEmpResponse = _EmployeeInformationService.GetById(entity.Id);
                        entity.Photo = returnEmpResponse.entity.Photo;
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
                    }
                    else
                    {
                        UploadPhoto(returnResponse.entity);
                        return RedirectToAction("Index");
                    }
                }

                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);

                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
            }
            catch
            {
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
            }
        }

        //public ActionResult Report(int? id)

        //{
        //    if (id == null || id == 0)
        //    {
        //        return HttpNotFound();
        //    }

        //    (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetById(id);


        //    EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        //    employeeViewModel.EmployeeInformationVM = returnResponse.entity;
        //    employeeViewModel.SpouseInformationLists = returnResponse.entity.SpouseInformation;
        //    employeeViewModel.ChildrenInformationLists = returnResponse.entity.ChildrenInformation;
        //    employeeViewModel.PresentAddressLists = returnResponse.entity.PresentAddresses;
        //    employeeViewModel.PermanentAddressLists = returnResponse.entity.PermanentAddresses;
        //    employeeViewModel.EducationalQualificationLists = returnResponse.entity.EducationalQualification;
        //    employeeViewModel.TrainingInformationLists = returnResponse.entity.TrainingInformation;
        //    employeeViewModel.ServiceHistoryLists = returnResponse.entity.ServiceHistories;
        //    employeeViewModel.PromotionPartcularLists = returnResponse.entity.PromotionPartculars;
        //    employeeViewModel.DisciplinaryActionsAndCriminalProsecutionLists = returnResponse.entity.DisciplinaryActionsAndCriminalProsecutions;
        //    employeeViewModel.PostingRecordLists = returnResponse.entity.PostingRecords;
        //    employeeViewModel.EmployeeTransferLists = returnResponse.entity.EmployeeTransfers;
        //    return View(employeeViewModel);
        //}

        public ActionResult Report(int? id)

        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetEmployeeFullInfoById(id);


            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeInformationVM = returnResponse.entity;
            employeeViewModel.SpouseInformationLists = returnResponse.entity?.SpouseInformationList != null ? returnResponse.entity?.SpouseInformationList : new List<SpouseInformationVM>();
            employeeViewModel.ChildrenInformationLists = returnResponse.entity?.ChildrenInformationList != null ? returnResponse.entity?.ChildrenInformationList : new List<ChildrenInformationVM>();
            employeeViewModel.PresentAddressLists = returnResponse.entity?.PresentAddressesList != null ? returnResponse.entity?.PresentAddressesList : new List<PresentAddressVM>();
            employeeViewModel.PermanentAddressLists = returnResponse.entity?.PermanentAddressesList != null ? returnResponse.entity?.PermanentAddressesList : new List<PermanentAddressVM>();
            employeeViewModel.EducationalQualificationLists = returnResponse.entity?.EducationalQualificationList != null ? returnResponse.entity?.EducationalQualificationList : new List<EducationalQualificationVM>();
            employeeViewModel.TrainingInformationLists = returnResponse.entity?.TrainingInformationList != null ? returnResponse.entity?.TrainingInformationList : new List<TrainingInformationVM>();
            employeeViewModel.ServiceHistoryLists = returnResponse.entity?.ServiceHistoriesList != null ? returnResponse.entity?.ServiceHistoriesList : new List<ServiceHistoryVM>();
            employeeViewModel.PromotionPartcularLists = returnResponse.entity?.PromotionPartcularsList != null ? returnResponse.entity?.PromotionPartcularsList : new List<PromotionPartcularsVM>();
            employeeViewModel.DisciplinaryActionsAndCriminalProsecutionLists = returnResponse.entity?.DisciplinaryActionsAndCriminalProsecutionsList != null ? returnResponse.entity?.DisciplinaryActionsAndCriminalProsecutionsList : new List<DisciplinaryActionsAndCriminalProsecutionVM>();
            employeeViewModel.PostingRecordLists = returnResponse.entity?.PostingRecordsList != null ? returnResponse.entity?.PostingRecordsList : new List<PostingRecordsVM>();
            employeeViewModel.EmployeeTransferLists = returnResponse.entity?.EmployeeTransfersList != null ? returnResponse.entity?.EmployeeTransfersList : new List<EmployeeTransferVM>();
            employeeViewModel.LanguageInformationLists = returnResponse.entity?.LanguageInformationsList != null ? returnResponse.entity?.LanguageInformationsList : new List<LanguageInformationVM>();
            employeeViewModel.OfficialInformationLists = returnResponse.entity?.OfficialInformation != null ? returnResponse.entity?.OfficialInformation : new List<OfficialInformationVM>();
            return View(employeeViewModel);
        }

        // GET: EmployeeInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "EmployeeInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: EmployeeInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(EmployeeInformationController.Index), "EmployeeInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Update(entity);
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


    
        public ActionResult GetUniversityInformationList(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, List<UniversityInformationVM> entity, string message) returnResponse = _UniversityInformationService.List();
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }


    }
}