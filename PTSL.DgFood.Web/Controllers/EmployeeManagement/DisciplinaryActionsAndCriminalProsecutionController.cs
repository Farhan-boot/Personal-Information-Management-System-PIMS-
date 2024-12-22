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
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class DisciplinaryActionsAndCriminalProsecutionController : Controller
    {
        private readonly IDisciplinaryActionsAndCriminalProsecutionService _DisciplinaryActionsAndCriminalProsecutionService;
        private readonly ICategoryService _categoryService;
        private readonly IPresentStatusService _presentStatusService;
        private readonly IDistrictService _DistrictService;
        private readonly IEmployeeInformationService _EmployeeInformationService;
        public readonly IModelStateValidation _ModelStateValidation;
        public DisciplinaryActionsAndCriminalProsecutionController()
        {
            _categoryService = new CategoryService();
            _presentStatusService = new PresentStatusService();
            _DistrictService = new DistrictService();
            _EmployeeInformationService = new EmployeeInformationService();
            _DisciplinaryActionsAndCriminalProsecutionService = new DisciplinaryActionsAndCriminalProsecutionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: DisciplinaryActionsAndCriminalProsecution
        //public ActionResult Index()
        //{
        //    (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionVM> entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.List();
        //    return View(returnResponse.entity);
        //}


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

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            DisciplinaryActionsAndCriminalProsecutionFilterVM entity = new DisciplinaryActionsAndCriminalProsecutionFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        // GET: DisciplinaryActionsAndCriminalProsecution/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.GetById(id);
            
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(long id)
        {
            DisciplinaryActionsAndCriminalProsecutionVM entity = new DisciplinaryActionsAndCriminalProsecutionVM();
            CategoryVM district = new CategoryVM();
            (ExecutionState executionState, List<CategoryVM> entity, string message) returnCategoryResponse = _categoryService.List();
            ViewBag.CategoryId = new SelectList(returnCategoryResponse.entity, "Id", "CategoryName");

            PresentStatusVM presentStatus = new PresentStatusVM();
            (ExecutionState executionState, List<PresentStatusVM> entity, string message) returnPresentStatusResponse = _presentStatusService.List();
            ViewBag.PresentStatusId = new SelectList(returnPresentStatusResponse.entity, "Id", "PresentStatusName");
            var emp = _EmployeeInformationService.GetEmployeeFullInfoById(id);
            if(emp.entity.NameEnglish == null)
            {
                return RedirectToAction("Index", "DisciplinaryActionsAndCriminalProsecution"/*, new { id = entity.EmployeeInformationId }*/);
            }
            var name = emp.entity.NameEnglish;
            EmployeeViewModel employee = new EmployeeViewModel();
            EmployeeInformationVM employeeInformationVM = new EmployeeInformationVM()
            {
                Id = id,
                NameEnglish = name,
            };
            employee.EmployeeInformationVM = employeeInformationVM;
            employee.DisciplinaryActionsAndCriminalProsecutionVM = entity;

            return View(employee);
        }

        // POST: DisciplinaryActionsAndCriminalProsecution/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            { 
                DisciplinaryActionsAndCriminalProsecutionVM entity = entityVM.DisciplinaryActionsAndCriminalProsecutionVM;
                entity.DisciplinaryHistories = new List<DisciplinaryHistoryVM>();
                IList<DocumentVM> documentVM = new List<DocumentVM>();

                Session["DisciplinaryActionsData"] = entity;
                Session["executionState"] = 0;
                var files = Request.Files;
                if (ModelState.IsValid)
                {
                    if (entityVM.DisciplinaryActionsAndCriminalProsecutionVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;

                        var fileUrl = UploadFile(entity);
                        if (string.IsNullOrEmpty(fileUrl))
                        {
                            Session["Message"] = "Failed to upload file. Please select a valid file.";
                            Session["executionState"] = ExecutionState.Failure;
                            return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = entityVM.DisciplinaryActionsAndCriminalProsecutionVM.EmployeeInformationId });
                        }
                        entity.Document = fileUrl;
                       
                        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["Message"] = "New Disciplinary item added.";
                            Session["DisciplinaryActionsData"] = returnResponse.entity;
                        }
                    }
                    else
                    {
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = entity.EmployeeInformationId });

            }
            catch
            {
                //return View(entityVM);
                return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = entityVM.DisciplinaryActionsAndCriminalProsecutionVM.EmployeeInformationId });
            }
        }
         
        // GET: DisciplinaryActionsAndCriminalProsecution/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Disciplinary Actions deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: DisciplinaryActionsAndCriminalProsecution/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DisciplinaryActionsAndCriminalProsecutionVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DisciplinaryActionsAndCriminalProsecutionController.Index), "DisciplinaryActionsAndCriminalProsecution");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.Update(entity);
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

        //public ActionResult UpdateDisciplinaryActionsStatus(long? did, long? empid)
        //{
        //    Session["DisciplinaryActionsId"] = did;
        //    return RedirectToAction("Edit", new { id = empid });
        //}

        //[HttpPost]
        //public ActionResult Edit(EmployeeViewModel entityVM)
        //{
        //    EmployeeInformationVM entity = entityVM.EmployeeInformationVM;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            entity.IsActive = true;
        //            entity.IsDeleted = false;
        //            entity.UpdatedAt = DateTime.Now;
        //            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.Update(entity);
        //            Session["Message"] = returnResponse.message;
        //            Session["executionState"] = returnResponse.executionState;
        //            if (returnResponse.executionState.ToString() != "Updated")
        //            {
        //                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
        //            }
        //            else
        //            {
        //                DisciplinaryActionsAndCriminalProsecutionVM disciplinarentity = entityVM.DisciplinaryActionsAndCriminalProsecutionVM;
        //                Session["DisciplinaryActionsData"] = disciplinarentity;
        //                Session["executionState"] = 0;
        //                var files = Request.Files;
        //                UploadFile(disciplinarentity);
        //                return RedirectToAction("Index");
        //            }
        //        }

        //        Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);

        //        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.Id });
        //    }
        //}

        //public ActionResult UpdateEmployeeHistory(int id)
        //{
        //    if (id == null)
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.GetById(id);

        //    return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult UpdateEmployeeHistory(FormCollection form, DisciplinaryHistoryVM entity)
        {
            string empId = form["empId"];
            string disciplinaryAndCriminalId = form["DisciplinaryAndCriminalId"];
            try
            {
                if(ModelState.IsValid)
                {
                    if (empId == null)
                    {
                        return RedirectToAction(nameof(DisciplinaryActionsAndCriminalProsecutionController.Index), "DisciplinaryActionsAndCriminalProsecution");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    DisciplinaryActionsAndCriminalProsecutionVM disciplinaryModel = new DisciplinaryActionsAndCriminalProsecutionVM()
                    {
                        Id = long.Parse(disciplinaryAndCriminalId),
                        //Document = entity.Document,
                        Description = entity.Description,
                        PresentStatusId = entity.PresentStatusId,
                        EmployeeInformationId = long.Parse(empId)
                    };

                    if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                    {
                        var documentUrl = UploadFile(disciplinaryModel);
                        if (string.IsNullOrEmpty(documentUrl))
                        {
                            Session["Message"] = "Failed to upload file. Please select a valid image.";
                            Session["executionState"] = ExecutionState.Failure;
                            return View(entity);
                        }
                        disciplinaryModel.Document = documentUrl;
                    }
                    else
                    {
                        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnExistingResponse = _DisciplinaryActionsAndCriminalProsecutionService.GetById(entity.Id);
                        disciplinaryModel.Document = returnExistingResponse.entity.Document;
                    }
                    (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse = _DisciplinaryActionsAndCriminalProsecutionService.Update(disciplinaryModel);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return RedirectToAction("Create");
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
            catch (Exception)
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return RedirectToAction("Create");
            }
        }

        // Upload
        public string UploadFile(DisciplinaryActionsAndCriminalProsecutionVM entity)
        {
            var entityId = entity.Id;
            string NewFile = "";

            if (string.IsNullOrEmpty(entity.Document) == false)
            {
                string path = Server.MapPath("~/Content/DisciplinaryActionsAndCriminalProsecution/" + entityId + "/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(path))
                {
                    //If Directory (Folder) does not exists.Create it.
                    Directory.CreateDirectory(path);
                }

                HttpFileCollectionBase files = Request.Files;
                //var files = System.Web.HttpContext.Current.Request.Files;


                for (int i = 0; i < files.Count; i++)
                {
                    var Name = "DisciplinaryActionsDocs";// files.AllKeys[i];
                    HttpPostedFileBase file = files[i];
                    //var file = files[i];
                    string[] currtintTime_str = DateTime.Now.ToShortTimeString().Split(':');
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = entityId + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + currtintTime_str[0] + "-" + currtintTime_str[1] + "-" + Name + extension;

                    if (extension.ToUpper() == ".DOCX" || extension.ToUpper() == ".DOC" || extension.ToUpper() == ".PDF" ||
                        extension.ToUpper() == ".ODT" || extension.ToUpper() == ".XLS" || extension.ToUpper() == ".XLSX")
                    {
                        file.SaveAs(path + newFileName);
                        entity.Document = entityId + "/" + newFileName;
                        NewFile = entity.Document;
                    }
                }

                return NewFile;
            }

            return null;
        }
    }
}