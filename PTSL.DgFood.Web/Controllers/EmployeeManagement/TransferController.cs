using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class TransferController : Controller
    {
        public readonly IModelStateValidation _ModelStateValidation;
        private readonly IEmployeeInformationService _EmployeeInformationService;
        private readonly IPostingRecordsService _PostingRecordsService;
        private readonly IEmployeeTransferService _EmployeeTransferService;
        public TransferController()
        {
            _EmployeeInformationService = new EmployeeInformationService();
            _ModelStateValidation = new ModelStateValidation();
            _PostingRecordsService = new PostingRecordsService();
            _EmployeeTransferService = new EmployeeTransferService();
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                EmployeeInformationFilterVM filtervm = new EmployeeInformationFilterVM();
                
                GenerateDropDownIndex(filtervm);
                
                returnResponse.entity = new List<EmployeeInformationListVM>();

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeInformationFilterVM filterData)
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                GenerateDropDownIndex(filterData);
                
                string RoleName = Session["RoleName"].ToString();

                returnResponse = _EmployeeInformationService.EmployeeListBySP(filterData);

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }

            return View();
        }

        public ActionResult TransferList()
        {
            (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) returnResponse;

            returnResponse = _EmployeeTransferService.List();

            if (returnResponse.entity != null)
            {
                returnResponse.entity = returnResponse.entity.OrderByDescending(x => x.Id).ToList(); 
            }
            return View(returnResponse.entity);
        }

        public PartialViewResult TransferHistoryPartial(long EmployeeInformationId)
        {
            try
            {
                PostingRecordsFilterVM entity = new PostingRecordsFilterVM();
                entity.EmployeeInformationId = EmployeeInformationId;
                (ExecutionState executionState, IList<PostingRecordsListVM> entity, string message) returnResponse = _PostingRecordsService.GetFilterData(entity);

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

        public async Task<PartialViewResult> Transfer(long? id)
        {
            if (id == null || id == 0)
            {
                return PartialView(null);
            }

            EmployeeTransferVM empTransferVM = new EmployeeTransferVM();
            empTransferVM.EmployeeInformationId = id.Value;
            GenerateDropDownTransfer(empTransferVM);

            return PartialView(empTransferVM);
        }
        [HttpPost]
        public ActionResult Transfer(EmployeeTransferVM viewModel)
        {
            try
            {
                viewModel.IsActive = true;
                viewModel.CreatedAt = DateTime.Now;
                (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) returnTransferListsResponse;
                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.Create(viewModel);
                Session["Message"] = "Data Saved Successfully !";
                Session["executionState"] = returnResponse.executionState;
                if (returnResponse.executionState.ToString() != "Created")
                {
                    Session["Message"] = returnResponse.message;
                }
                else
                {
                    EmployeeTransferFilterVM filterData = new EmployeeTransferFilterVM();
                    filterData.EmployeeInformationId = viewModel.EmployeeInformationId;
                    returnTransferListsResponse = _EmployeeTransferService.GetFilterData(filterData);
                    foreach (var data in returnTransferListsResponse.entity)
                    {
                        (ExecutionState executionState, EmployeeTransferVM entity, string message) getPostingRecordsByIdResponse = _EmployeeTransferService.GetById(data.Id);
                        if (getPostingRecordsByIdResponse.entity.Id != returnResponse.entity.Id)
                        {
                            getPostingRecordsByIdResponse.entity.IfEmployeeContinuing = false;
                        }
                        else
                        {
                            getPostingRecordsByIdResponse.entity.IfEmployeeContinuing = true;
                        }
                        (ExecutionState executionState, EmployeeTransferVM entity, string message) updateRecordsByIdResponse = _EmployeeTransferService.Update(getPostingRecordsByIdResponse.entity);

                    }

                    if (!string.IsNullOrEmpty(viewModel.UploadFiles) && !string.IsNullOrWhiteSpace(viewModel.UploadFiles))
                    {
                        UploadFiles(returnResponse.entity);
                    }

                    Session["Message"] = "Data Saved Successfully !";
                    return RedirectToAction("TransferList");
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(long id)
        {
            try
            {
                if (id == 0)
                {
                    return HttpNotFound();
                }

                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.GetById(id);
                returnResponse.entity.EmployeeInformationId = 197300001;
                GenerateDropDownTransfer(returnResponse.entity);

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
                return RedirectToAction("TransferList");
            }
        }

        public async Task<ActionResult> Edit(long id)
        {
            try
            {
                if (id == 0)
                {
                    return HttpNotFound();
                }

                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.GetById(id);
                returnResponse.entity.EmployeeInformationId = 197300001;
                GenerateDropDownTransfer(returnResponse.entity);

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
                return RedirectToAction("TransferList");
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeTransferVM viewModel)
        {
            try
            {
                viewModel.IsActive = true;
                viewModel.IsDeleted = false;
                viewModel.UpdatedAt = DateTime.Now;
                viewModel.IfEmployeeContinuing = true;

                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.Update(viewModel);
                Session["Message"] = "Data Updated Successfully !";
                Session["executionState"] = returnResponse.executionState;

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    Session["Message"] = returnResponse.message;
                }
                else
                {
                    if (!string.IsNullOrEmpty(viewModel.EditUploadFiles) && !string.IsNullOrWhiteSpace(viewModel.EditUploadFiles))
                    {
                        UploadFiles(returnResponse.entity);
                    }

                    Session["Message"] = "Data Updated Successfully !";
                    return RedirectToAction("TransferList");
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> PostingEntry(long id)
        {
            try
            {
                if (id == 0)
                {
                    return HttpNotFound();
                }

                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.GetById(id);
                returnResponse.entity.EmployeeInformationId = 197300001;
                GenerateDropDownTransfer(returnResponse.entity);

                return View(returnResponse.entity);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
                return RedirectToAction("TransferList");
            }
        }
        [HttpPost]
        public ActionResult PostingEntry(PostingRecordsVM viewModel)
        {
            try
            {
                viewModel.IsActive = true;
                viewModel.IsDeleted = false;
                viewModel.UpdatedAt = DateTime.Now;
                viewModel.IfEmployeeContinuing = true;
                PostingRecordsFilterVM filterData = new PostingRecordsFilterVM();
                filterData.EmployeeInformationId = viewModel.EmployeeInformationId;
                (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) returnPostingRecordsResponse = _PostingRecordsService.GetFilterData(filterData);
                var checkPostingRecordsExistOrNot = returnPostingRecordsResponse.entity.Where(x => x.EmployeeTransferId == viewModel.EmployeeTransferId).FirstOrDefault();
                (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse;
                if (checkPostingRecordsExistOrNot != null)
                {
                    viewModel.Id = checkPostingRecordsExistOrNot.Id;
                    returnResponse = _PostingRecordsService.Update(viewModel);
                    
                }
                else
                {
                     returnResponse = _PostingRecordsService.Create(viewModel);
                }
                
                Session["Message"] = "Data Saved Successfully !";
                Session["executionState"] = returnResponse.executionState;

                if (returnResponse.executionState.ToString() == "Failure")
                {
                    Session["Message"] = returnResponse.message;
                }
                else
                {

                     returnPostingRecordsResponse = _PostingRecordsService.GetFilterData(filterData);
                    foreach(var data in returnPostingRecordsResponse.entity)
                    {
                        (ExecutionState executionState, PostingRecordsVM entity, string message) getPostingRecordsByIdResponse = _PostingRecordsService.GetById(data.Id);
                        if(getPostingRecordsByIdResponse.entity.EmployeeTransferId != viewModel.EmployeeTransferId)
                        {
                            getPostingRecordsByIdResponse.entity.IfEmployeeContinuing = false;
                        }
                        else
                        {
                            getPostingRecordsByIdResponse.entity.IfEmployeeContinuing = true;
                        }
                        (ExecutionState executionState, PostingRecordsVM entity, string message) updateRecordsByIdResponse = _PostingRecordsService.Update(getPostingRecordsByIdResponse.entity);

                    }

                    (ExecutionState executionState, EmployeeTransferVM entity, string message) returnTransferResponse = _EmployeeTransferService.GetById(viewModel.EmployeeTransferId);
                    returnTransferResponse.entity.PostingDate = viewModel.PostingDate;
                    returnTransferResponse.entity.IsPostingCompleted = true;
                    (ExecutionState executionState, EmployeeTransferVM entity, string message) updateTransferResponse = _EmployeeTransferService.Update(returnTransferResponse.entity);
                    Session["Message"] = "Data Saved Successfully !";
                    return RedirectToAction("TransferList");
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }
            return RedirectToAction("PostingEntry/" + viewModel.EmployeeTransferId);
        }
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse;
            if (id == 0)
            {
                returnResponse.message = "This data can not be deleted!";
            }

            returnResponse = _EmployeeTransferService.Delete(id);

            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Data deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        private void UploadFiles(EmployeeTransferVM viewModel)
        {
            long EmpId = viewModel.EmployeeInformationId;
            try
            {
                string path = Server.MapPath("~/Content/UploadedTransferDocument/" + EmpId + "/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(path))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(path);
                }

                HttpFileCollectionBase files = Request.Files;

                for (int i = 0; i < files.Count; i++)
                {
                    var Name = "Emp-Transfer";// files.AllKeys[i];
                    HttpPostedFileBase file = files[i];
                    string[] currtintTime_str = DateTime.Now.ToShortTimeString().Split(':');
                    string extension = System.IO.Path.GetExtension(file.FileName);
                    string newFileName = EmpId + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + currtintTime_str[0] + "-" + currtintTime_str[1] + "-" + Name + extension;
                    if (extension.ToUpper() == ".JPG" || extension.ToUpper() == ".JPEG" || extension.ToUpper() == ".GIF" ||
                        extension.ToUpper() == ".PNG" || extension.ToUpper() == ".BMP" || extension.ToUpper() == ".PDF")
                    {
                        file.SaveAs(path + newFileName);
                        viewModel.UploadFiles= EmpId + "/" + newFileName;
                    }
                }

                (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse = _EmployeeTransferService.Update(viewModel);
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
            }
        }

        public ActionResult PostingDetails(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.GetById(id);
            //$('#PromotionParticular_Rank').text(response.data.Rank.RankName);
            // $('#PromotionParticular_Designation').text(response.data.Designation.DesignationName);
            string PeriodFrom = returnResponse.entity.PeriodFrom != null ? Convert.ToDateTime(returnResponse.entity.PeriodFrom).ToString("dd-MM-yyyy") : "";
            string PeriodTo = returnResponse.entity.PeriodTo != null ? Convert.ToDateTime(returnResponse.entity.PeriodTo).ToString("dd-MM-yyyy") : "";
            string WorkingAs = returnResponse.entity.WorkingAsId != 0 ? EnumHelper.GetEnumDisplayName((WorkingAs)(int)returnResponse.entity.WorkingAsId) : "";

            return Json(new { data = returnResponse.entity, PeriodFrom, PeriodTo, WorkingAs }, JsonRequestBehavior.AllowGet);
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

        private async void GenerateDropDownTransfer(EmployeeTransferVM empTransferVM)
        {
            DropdownController dc = new DropdownController();

            List<RankVM> returnPostingRecordsRankResponse = dc.GetRanks();
            ViewBag.PostingRecordsRankId = new SelectList(returnPostingRecordsRankResponse, "Id", "RankName", empTransferVM.RankId);
            List<DesignationClassVM> returnPostingRecordsDesignationClassResponse = dc.GetDesignationClasses();
            ViewBag.PostingRecordsDesignationClassId = new SelectList(returnPostingRecordsDesignationClassResponse, "Id", "DesignationClassName", empTransferVM.DesignationClassId);
            List<DesignationVM> resturnDesignationVMResponse = dc.GetDesignations();
            ViewBag.PostingRecordsDesignationId = new SelectList(resturnDesignationVMResponse, "Id", "DesignationName", empTransferVM.DesignationId);
            List<PostResponsibilityVM> returnPostingRecordsPostResponsibilityResponse = dc.GetPostResponsibilities();
            ViewBag.PostingRecordsPostResponsibilityId = new SelectList(returnPostingRecordsPostResponsibilityResponse, "Id", "PostResponsibilityName", empTransferVM.PostResponsibilityId);
            List<PostingTypeVM> returnPostingRecordsPostingTypeResponse = dc.GetPostingTypes();
            ViewBag.PostingRecordsPostingTypeId = new SelectList(returnPostingRecordsPostingTypeResponse, "Id", "PostingTypeName", empTransferVM.MainPostingTypeId);
            List<PostingVM> returnPostingResponse = dc.GetPostings();
            ViewBag.PostingRecordsPostingId = new SelectList(returnPostingResponse, "Id", "PostingName", empTransferVM.PostingId);
            List<DropdownVM> returnPostingRecordsWorkingAsResponse = dc.GetWorkingAs();
            ViewBag.PostingRecordsWorkingAsId = new SelectList(returnPostingRecordsWorkingAsResponse, "Id", "Name", empTransferVM.WorkingAsId);
            List<DivisionVM> returnPostingRecordsFromDivisionResponse = dc.GetDivisions();
            ViewBag.PostingRecordsFromDivisionId = new SelectList(returnPostingRecordsFromDivisionResponse, "Id", "DivisionName", empTransferVM.TransferFromDivisionId);
            List<DistrictVM> returnDistrictResponse = dc.GetDistricts();
            ViewBag.PostingRecordsFromDistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", empTransferVM.TransferFromDistrictId);
            ViewBag.PostingRecordsToDivisionId = new SelectList(returnPostingRecordsFromDivisionResponse, "Id", "DivisionName", empTransferVM.TransferToDivisionId);
            ViewBag.PostingRecordsToDistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", empTransferVM.TransferToDistrictId);


            ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsDesignationClassResponse, "Id", "DesignationClassName", empTransferVM.CurrDesignationClassId);
            ViewBag.PostingRecordsCrntDesgId = new SelectList(resturnDesignationVMResponse, "Id", "DesignationName", empTransferVM.CrntDesgId);
            List<PostingTypeVM> returnPostingRecordsDeppostingTypeResponse = dc.GetPostingTypes();
            ViewBag.PostingRecordsDeppostingTypeId = new SelectList(returnPostingRecordsDeppostingTypeResponse, "Id", "PostingTypeName", empTransferVM.DeppostingTypeId);
            ViewBag.PostingRecordsDepPostingId = new SelectList(returnPostingResponse, "Id", "PostingName", empTransferVM.DepPostingId);
        }

        private void GenerateDropDownIndex(EmployeeInformationFilterVM filterData)
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
        }

    }
}