using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using Microsoft.AspNetCore.Http;
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
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class TrainingInformationManagementMasterController : Controller
    {
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly ITrainingInformationManagementMasterService _TrainingInformationManagementMasterService;
        private readonly ITrainingInformationManagementService _TrainingInformationManagementService;
        private readonly IDivisionService _DivisionService;
        private readonly ILeaveTypeInformationService _LeaveTypeInformationService;
        public readonly IModelStateValidation _ModelStateValidation;
        public readonly ITrainingInformationService _TrainingInformationService;
        public readonly IDesignationService _DesignationService;
        public readonly FileHelper _FileHelper = new FileHelper();
        private readonly IOtherTrainingMemberService _OtherTrainingMemberService;

        public TrainingInformationManagementMasterController()
        {
            _TrainingInformationManagementMasterService = new TrainingInformationManagementMasterService();
            _TrainingInformationManagementService = new TrainingInformationManagementService();
            _DivisionService = new DivisionService();
            _LeaveTypeInformationService = new LeaveTypeInformationService();
            _ModelStateValidation = new ModelStateValidation();
            _EmployeeInformationService = new EmployeeInformationService();
            _TrainingInformationService = new TrainingInformationService();
            _DesignationService = new DesignationService();
            _OtherTrainingMemberService = new OtherTrainingMemberService();
        }
        // GET: TrainingInformationManagementMaster
        public ActionResult Index()
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse = _TrainingInformationManagementMasterService.List();
            return View(returnResponse.entity);
        }

        // GET: TrainingInformationManagementMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: TrainingInformationManagementMaster/Create
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

                ViewBag.DesignationId = new SelectList(_DesignationService.List().entity ?? new List<DesignationVM>(), "Id", "DesignationName");

                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                //ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");
                ViewBag.TrainingManagementTypes = returnTrainingManagementTypeResponse;

                returnResponse.entity = new List<EmployeeInformationListVM>();

                ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

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
                //List<PoliceStationVM> returnPoliceStationResponse = dc.Getpoli();
                ViewBag.PoliceStationId = new SelectList("");
                if (filterData.DistrictId > 0)
                {
                    ICollection<PoliceStationVM> returnPoliceStationResponse = dc.GetPoliceStationByDistrictId((long)filterData.DistrictId); //_DistrictService.List();
                    ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", filterData.PoliceStationId);
                }


                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                //ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");
                ViewBag.TrainingManagementTypes = returnTrainingManagementTypeResponse;
                string RoleName = Session["RoleName"].ToString();

                //EmployeeInformationVM filterData = new EmployeeInformationVM();
                //filterData.Id = filterData.Id;
                //filterData.RankId = filterData.RankId;
                //filterData.DesignationId = filterData.DesignationId;

                filterData.ReturnAllRow = true;
                returnResponse = _EmployeeInformationService.EmployeeListBySP(filterData);
                //returnResponse.entity = returnResponse.entity.Where(x => x.Email == filterData.Email).ToList();


                //if (returnResponse.entity != null)
                //{
                //    returnResponse.entity = returnResponse.entity.Take(10).OrderByDescending(x => x.Id).ToList();
                //}

                ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [HttpPost]
        public ActionResult BulkUploadTraining()
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ? System.Web.HttpContext.Current.Request.Files[0] : null;

                if (file == null)
                {
                    return Json(
                        new { Success = false, Message = "No file found", Payload = "" },
                        JsonRequestBehavior.AllowGet);
                }

                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension != ".xlsx" || fileExtension != ".xlx")
                {
                    return Json(
                        new { Success = false, Message = "Please select the excel file with .xlsx or .xls extension", Payload = "" },
                        JsonRequestBehavior.AllowGet);
                }

                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/BulkUploadTraining/");

                if (Directory.Exists(folderPath) == false)
                {
                    Directory.CreateDirectory(folderPath);
                }

                //Save file to folder
                var filePath = folderPath + Guid.NewGuid() + "_" + Path.GetFileName(file.FileName);
                file.SaveAs(filePath);

                var excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";

                //Read data from first sheet of excel into datatable
                DataTable dt = new DataTable();
                excelConString = string.Format(excelConString, filePath);

                using (OleDbConnection excelOledbConnection = new OleDbConnection(excelConString))
                {
                    using (OleDbCommand excelDbCommand = new OleDbCommand())
                    {
                        using (OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter())
                        {
                            excelDbCommand.Connection = excelOledbConnection;

                            excelOledbConnection.Open();
                            DataTable excelSchema = excelOledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                            excelOledbConnection.Close();

                            //Read Data from First Sheet.
                            excelOledbConnection.Open();
                            excelDbCommand.CommandText = "SELECT * From [" + sheetName + "]";
                            excelDataAdapter.SelectCommand = excelDbCommand;
                            excelDataAdapter.Fill(dt);
                            excelOledbConnection.Close();
                        }
                    }
                }

                DataRowCollection rows = dt.Rows;
                List<TrainingBulkUploadVM> trainingList = new List<TrainingBulkUploadVM>();

                if (rows.Count < 1)
                {
                    return Json(new { Success = false, Message = "No data found.", Payload = "" }, JsonRequestBehavior.AllowGet);
                }

                foreach (DataRow row in rows)
                {
                    var employeeIdUnknown = row.Field<double?>("employee_id");
                    var trainingIdUnknown = row.Field<double?>("training_id");

                    if (employeeIdUnknown is null || trainingIdUnknown is null)
                        continue;

                    try
                    {
                        var bulkUploadVM = new TrainingBulkUploadVM();
                        bulkUploadVM.EmployeeId = (long)employeeIdUnknown;
                        bulkUploadVM.TrainingId = (long)trainingIdUnknown;
                        trainingList.Add(bulkUploadVM);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                var trainingInfoManagementList = new List<TrainingInformationManagementMasterVM>();

                // Group data by training id to array
                var groupByData = trainingList.GroupBy(x => x.TrainingId);
                foreach (var data in groupByData)
                {
                    var trainingInfoManagement = new TrainingInformationManagementMasterVM();
                    trainingInfoManagement.TrainingManagementTypeId = data.Key;
                    trainingInfoManagement.EmployeeInformationIds = data.Select(x => x.EmployeeId).ToArray();

                    trainingInfoManagementList.Add(trainingInfoManagement);
                }

                // Covert array of ids to TrainingInformationManagementVM
                foreach (var infoList in trainingInfoManagementList)
                {
                    AddTrainingManagement(infoList);
                }

                var response = _TrainingInformationManagementMasterService.BulkUploadTraining(trainingInfoManagementList);

                if (response.executionState == ExecutionState.Success)
                    return Json(new { Success = true, Message = "Uploaded successfully.", Payload = "" }, JsonRequestBehavior.AllowGet);

                return Json(new { Success = false, Message = response.message, Payload = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Unknown error occured.", Payload = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: TrainingInformationManagementMaster/Create
        [HttpPost]
        public ActionResult PostFormData(TrainingInformationManagementMasterVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                ViewBag.DesignationId = new SelectList("");
                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    entity.Status = false;
                    entity.TrainingInformationManagementLists = new List<TrainingInformationManagementVM>();
                    AddTrainingManagement(entity);

                    // TODO: Add insert logic here
                    //TrainingInformationManagementMasterVM training = new TrainingInformationManagementMasterVM();
                    //training.TrainingManagementTypeId = entity.TrainingManagementTypeId;
                    (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnExistingResponse = _TrainingInformationManagementMasterService.GetTrainingInformationByTrainingManagementTypeId(entity.TrainingManagementTypeId);

                    if (returnExistingResponse.entity != null)
                    {
                        entity.Id = returnExistingResponse.entity.FirstOrDefault().Id;
                        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
                        Session["Message"] = "Data Saved Successfully !";
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() != "Updated")
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Create(entity);
                        Session["Message"] = "Data Saved Successfully !";
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() != "Created")
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(entity);
            }
        }


        [HttpPost]
        public ActionResult SendSMS(List<TrainingSmsVM> model)//int[] selectedIds, string subject, string messagebody, string noticeType)
        {
            long LoggedInUser = MySession.Current.UserId;

            var models = new List<TrainingSmsVM>();


            //int[] selectedIds = new int[] { };
            //string subject;
            //string messagebody;
            //string noticeType = "";
            try
            {
                if (ModelState.IsValid)
                {


                    //if (selectedIds == null)
                    //               {
                    //                   Session["Message"] = "'Select all' Checkbox";
                    //                   Session["executionState"] = ExecutionState.Failure;
                    //                   return Json(new { SessionMessage = Session["Message"] });

                    //               }
                    foreach (var item in model)
                    {
                        models.Add(
                            new TrainingSmsVM()
                            {
                                CreatedBy = LoggedInUser,
                                EmployeeInformationId = item.EmployeeInformationId,
                                TrainingManagementTypeId = item.TrainingManagementTypeId,
                                IsEmail = false,
                                IsSMS = true,
                                NoticeDate = DateTime.Now.Date,
                                NoticeBy = LoggedInUser,
                                IsActive = true,
                                CreatedAt = DateTime.Now,
                            });
                    }

                    (ExecutionState executionState, List<TrainingSmsVM> entity, string message) returnResponse = _TrainingInformationManagementMasterService.SendSMS(models);

                    if (returnResponse.executionState == ExecutionState.Success)
                    {
                        Session["Message"] = "Training notice send successfully by SMS";
                        //Session["PRLData"] = returnResponse.entity;
                        //return Json(new { SessionMessage = Session["Message"] });
                        return Json(new { Message = Session["Message"], executionState = ExecutionState.Updated }, JsonRequestBehavior.AllowGet);
                    }
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    return Json(new { Message = "Item saved Successfully.", executionState = ExecutionState.Updated }, JsonRequestBehavior.AllowGet);
                }

                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return Json(new { Message = Session["Message"], executionState = ExecutionState.Failure }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return Json(new { Message = Session["Message"], executionState = ExecutionState.Failure }, JsonRequestBehavior.AllowGet);
            }
        }

        private void AddTrainingManagement(TrainingInformationManagementMasterVM entity)
        {
            foreach (var emp in entity.EmployeeInformationIds)
            {
                TrainingInformationManagementVM trainingInformationManagement = new TrainingInformationManagementVM();
                trainingInformationManagement.TrainingInformationManagementMasterId = 0;
                trainingInformationManagement.EmployeeInformationId = emp;
                trainingInformationManagement.IsActive = true;
                trainingInformationManagement.CreatedAt = DateTime.Now;
                trainingInformationManagement.Status = false;
                trainingInformationManagement.ApprovalStatus = TrainingInformationManagementApprovalStatus.Approved;
                entity.TrainingInformationManagementLists.Add(trainingInformationManagement);
            }
        }


        // GET: TrainingInformationManagementMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetById(id);

            returnResponse.entity.TrainingInformationManagementLists = returnResponse.entity.TrainingInformationManagementLists.Where(x => x.ApprovalStatus == TrainingInformationManagementApprovalStatus.Approved).ToList();

            DropdownController dc = new DropdownController();
            List<RankVM> returnRankResponse = dc.GetRanks();
            ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
            ViewBag.DesignationId = new SelectList("");
            List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
            ViewBag.TrainingManagementTypesId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingTitle", returnResponse.entity.TrainingManagementTypeId);

            return View(returnResponse.entity);
        }

        public ActionResult TrainingCompleted(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetById(id);

            returnResponse.entity.TrainingInformationManagementLists = returnResponse.entity.TrainingInformationManagementLists.Where(x => x.ApprovalStatus == TrainingInformationManagementApprovalStatus.Approved).ToList();

            DropdownController dc = new DropdownController();
            List<RankVM> returnRankResponse = dc.GetRanks();
            ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName", "1");
            ViewBag.DesignationId = new SelectList("");
            List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
            ViewBag.TrainingManagementTypesId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingTitle", returnResponse.entity.TrainingManagementTypeId);

            return View(returnResponse.entity);
        }
        // POST: TrainingInformationManagementMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrainingInformationManagementMasterVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                ViewBag.DesignationId = new SelectList("");
                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingInformationManagementMasterController.Index), "TrainingInformationManagementMaster");
                    }


                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    if (entity.Status == true)
                    {
                        foreach (var data in entity.TrainingInformationManagementLists)
                        {
                            data.Status = true;
                        }
                    }
                    //entity.Status = true;

                    (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
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

        [HttpPost]
        public ActionResult TrainingCompleted(int id, TrainingInformationManagementMasterVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                List<RankVM> returnRankResponse = dc.GetRanks();
                ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                ViewBag.DesignationId = new SelectList("");
                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingInformationManagementMasterController.Index), "TrainingInformationManagementMaster");
                    }

                    // File
                    foreach (var item in entity.TrainingInformationManagementLists ?? Enumerable.Empty<TrainingInformationManagementVM>())
                    {
                        if (item.Certificate != null)
                        {
                            if (SaveFiles(item.Certificate, item, FileType.Document, out var fileErrorMessage) == false)
                            {
                                Session["Message"] = fileErrorMessage;

                                return Redirect($"{nameof(TrainingCompleted)}?id={item.TrainingInformationManagementMasterId}");
                            }
                            item.Certificate = null;
                        }
                    }

                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    entity.Status = true;

                    (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        var trainingManagementMasterById = _TrainingInformationManagementService.GetByTrainingInformationManagementMasterId(id);
                        //List<TrainingInformationVM> trainingInformationList = new List<TrainingInformationVM>();
                        foreach (var data in trainingManagementMasterById.entity)
                        {
                            TrainingInformationVM trainingInformation = new TrainingInformationVM();
                            trainingInformation.CountryId = null;
                            trainingInformation.CourseTitle = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.TrainingTitle;
                            trainingInformation.Institute = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.Institute;
                            trainingInformation.Location = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.Vanue;
                            trainingInformation.FromDate = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.FromDate;
                            trainingInformation.ToDate = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.ToDate;
                            trainingInformation.Grade = data.Grade;
                            trainingInformation.Position = data.Position;
                            trainingInformation.EmployeeInformationId = data.EmployeeInformationId;
                            trainingInformation.TrainingTypeId = TrainingType.LocalTraining;
                            (ExecutionState executionState, TrainingInformationVM entity, string message) returnTrainingInformationResponse = _TrainingInformationService.Create(trainingInformation);

                        }
                        Session["Message"] = "Data Saved Successfully.";
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


        // GET: TrainingInformationManagementMaster/Delete/5
        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _TrainingInformationManagementMasterService.DoesExist(id);
            //string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Leave Application deleted Successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }


        // POST: TrainingInformationManagementMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingInformationManagementMasterVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(TrainingInformationManagementMasterController.Index), "TrainingInformationManagementMaster");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
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


        public ActionResult TrainingPending(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.GetById(id);

            DropdownController dc = new DropdownController();
            //List<RankVM> returnRankResponse = dc.GetRanks();
            //ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName", "1");
            //ViewBag.DesignationId = new SelectList("");
            List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
            ViewBag.TrainingManagementTypesId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingTitle", returnResponse.entity.TrainingManagementTypeId);

            returnResponse.entity.TrainingInformationManagementLists = returnResponse.entity.TrainingInformationManagementLists.Where(x => x.ApprovalStatus == TrainingInformationManagementApprovalStatus.EmployeeRequested).ToList();

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult TrainingPending(int id, TrainingInformationManagementMasterVM entity)
        {
            try
            {
                DropdownController dc = new DropdownController();
                //List<RankVM> returnRankResponse = dc.GetRanks();
                //ViewBag.RankId = new SelectList(returnRankResponse, "Id", "RankName");
                //ViewBag.DesignationId = new SelectList("");
                List<TrainingManagementTypeVM> returnTrainingManagementTypeResponse = dc.GetTrainingManagementTypes();
                ViewBag.TrainingManagementTypeId = new SelectList(returnTrainingManagementTypeResponse, "Id", "TrainingManagementTypeName");

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingInformationManagementMasterController.Index), "TrainingInformationManagementMaster");
                    }


                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    entity.Status = false;

                    (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        var trainingManagementMasterById = _TrainingInformationManagementService.GetByTrainingInformationManagementMasterId(id);
                        //List<TrainingInformationVM> trainingInformationList = new List<TrainingInformationVM>();
                        foreach (var data in trainingManagementMasterById.entity)
                        {
                            TrainingInformationVM trainingInformation = new TrainingInformationVM();
                            trainingInformation.CountryId = null;
                            trainingInformation.CourseTitle = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.TrainingTitle;
                            trainingInformation.Institute = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.Institute;
                            trainingInformation.Location = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.Vanue;
                            trainingInformation.FromDate = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.FromDate;
                            trainingInformation.ToDate = data.TrainingInformationManagementMasterDto.TrainingManagementTypeDto.ToDate;
                            trainingInformation.Grade = data.Grade;
                            trainingInformation.Position = data.Position;
                            trainingInformation.EmployeeInformationId = data.EmployeeInformationId;
                            trainingInformation.TrainingTypeId = TrainingType.LocalTraining;
                            (ExecutionState executionState, TrainingInformationVM entity, string message) returnTrainingInformationResponse = _TrainingInformationService.Create(trainingInformation);

                        }
                        Session["Message"] = "Data Saved Successfully.";
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


        [HttpPost]
        public JsonResult SaveOtherMember(OtherTrainingMemberVM otherTrainingMember)
        {
            otherTrainingMember.IsActive = true;
            otherTrainingMember.CreatedAt = DateTime.Now;
            // TODO: Add insert logic here
            (ExecutionState executionState, OtherTrainingMemberVM entity, string message) returnResponse = _OtherTrainingMemberService.Create(otherTrainingMember);
            Session["Message"] = returnResponse.message;
            Session["executionState"] = returnResponse.executionState;

            return Json("",JsonRequestBehavior.AllowGet);
        }


        private bool SaveFiles(HttpPostedFileBase file, TrainingInformationManagementVM entity, FileType fileType, out string error)
        {
            if (file is null)
            {
                error = "File is empty";
                return false;
            }

            var (isSaved, fileUrl, _) = _FileHelper.SaveFile(file, fileType, "TrainingCertificate", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            entity.CertificateDocumentURI = fileUrl;

            error = string.Empty;
            return true;
        }
    }
}