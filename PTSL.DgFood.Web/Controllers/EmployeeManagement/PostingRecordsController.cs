using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class PostingRecordsController : Controller
    {
        private readonly IPostingRecordsService _PostingRecordsService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PostingRecordsController(): this(new PostingRecordsService())
        //{
        //}
        public PostingRecordsController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _PostingRecordsService = new PostingRecordsService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PostingRecords
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PostingRecordsVM> entity, string message) returnResponse = _PostingRecordsService.List();
            return View(returnResponse.entity);
        }

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            PostingRecordsFilterVM entity = new PostingRecordsFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<PostingRecordsListVM> entity, string message) returnResponse = _PostingRecordsService.GetFilterData(entity);

            return View(returnResponse.entity);
        }
        // GET: PostingRecords/Details/5
        public ActionResult Details(int? id)
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


        // POST: PostingRecords/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            { 
                PostingRecordsVM entity = entityVM.PostingRecordsVM;
                Session["PostingRecordsData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entityVM.PostingRecordsVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["PostingRecordsData"] = returnResponse.entity;
                            UploadPhoto(entity);
                        }
                    }
                    else
                    {
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        if (entity.UploadFiles == null)
                        {
                            (ExecutionState executionState, PostingRecordsVM entity, string message) returnEmpResponse = _PostingRecordsService.GetById(entity.Id);
                            entity.UploadFiles = returnEmpResponse.entity.UploadFiles;

                        }
                        (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.Update(entity);
                        
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        UploadPhoto(entity);

                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                //return View(entity);
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });

            }
            catch
            {
                //return View(entityVM);
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.PostingRecordsVM.EmployeeInformationId });
            }
        }

        public void UploadPhoto(PostingRecordsVM entity)
        {
            var EmpId = entity.EmployeeInformationId;

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
                var Name = "Transfer-File";// files.AllKeys[i];
                HttpPostedFileBase file = files[i];
                string[] currtintTime_str = DateTime.Now.ToShortTimeString().Split(':');
                string extension = System.IO.Path.GetExtension(file.FileName);
                string newFileName = EmpId + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + currtintTime_str[0] + "-" + currtintTime_str[1] + "-" + Name + extension;
                if (extension.ToUpper() == ".JPG" || extension.ToUpper() == ".JPEG" || extension.ToUpper() == ".GIF" ||
                        extension.ToUpper() == ".PNG" || extension.ToUpper() == ".BMP" || extension.ToUpper() == ".PDF")
                {
                    file.SaveAs(path + newFileName);
                    entity.UploadFiles = EmpId + "/" + newFileName;
                }
            }

            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.Update(entity);


        }

        // GET: PostingRecords/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PostingRecords deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PostingRecords/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PostingRecordsVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PostingRecordsController.Index), "PostingRecords");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse = _PostingRecordsService.Update(entity);
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
    }
}