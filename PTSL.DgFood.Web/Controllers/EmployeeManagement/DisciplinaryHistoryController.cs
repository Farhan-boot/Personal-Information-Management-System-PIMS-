using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    public class DisciplinaryHistoryController : Controller
    {
        private readonly IDisciplinaryHistoryService _disciplinaryHistoryService;
        public readonly IModelStateValidation _ModelStateValidation;

        public DisciplinaryHistoryController()
        {
            _ModelStateValidation = new ModelStateValidation();
            _disciplinaryHistoryService = new DisciplinaryHistoryService();
        }

        // GET: DisciplinaryHistory
        [HttpPost]
        public ActionResult Create(FormCollection form, DisciplinaryHistoryVM entity)
        {
            string disciplinaryAndCriminalId = form["DisciplinaryAndCriminalId"];
            string employeeId = form["empId"];
            IList<DocumentVM> documents = new List<DocumentVM>();
            entity.Documents = new List<DocumentVM>();

            try
            {
                Session["DisciplinaryHistoryData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entity.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        entity.SubmissonDate = entity.CreatedAt;
                        entity.DisciplinaryAndCriminalId = long.Parse(disciplinaryAndCriminalId);

                        var fileUrl = UploadFile(entity);
                        if (fileUrl == null)
                        {
                            Session["Message"] = "Failed to upload file. Please select a valid image.";
                            Session["executionState"] = ExecutionState.Failure;
                            return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = employeeId });
                        }
                        foreach(var url in fileUrl)
                        {
                            entity.Documents.Add(new DocumentVM { Name = url.Name });
                        }
                        entity.DocumentFile = null;
                        (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) returnResponse = _disciplinaryHistoryService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["Message"] = "New Disciplinary History item added.";
                            Session["DisciplinaryActionsData"] = returnResponse.entity;
                        }
                    }
                    else
                    {
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) returnResponse = _disciplinaryHistoryService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = employeeId});
            }
            catch
            {
                return RedirectToAction("Create", "DisciplinaryActionsAndCriminalProsecution", new { id = employeeId});
            }
        }

        // Upload
        public IList<DocumentVM> UploadFile(DisciplinaryHistoryVM entity)
        {
            var entityId = entity.Id;
            IList<DocumentVM> NewFile = null;
            IList<DocumentVM> documents = new List<DocumentVM>();


            if (entity.DocumentFile != null)
            {
                string path = Server.MapPath("~/Content/DisciplinaryHistory/" + entityId + "/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(path))
                {
                    //If Directory (Folder) does not exists.Create it.
                    Directory.CreateDirectory(path);
                }

                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    var Name = "DisciplinaryActionsDocs";// files.AllKeys[i];
                    HttpPostedFileBase file = files[i];
                    string[] currtintTime_str = DateTime.Now.ToShortTimeString().Split(':');
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = i + entityId + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + currtintTime_str[0] + "-" + currtintTime_str[1] + "-" + Name + extension;

                    if (extension.ToUpper() == ".DOCX" || extension.ToUpper() == ".DOC" || extension.ToUpper() == ".PDF" ||
                        extension.ToUpper() == ".ODT" || extension.ToUpper() == ".XLS" || extension.ToUpper() == ".XLSX")
                    {
                        file.SaveAs(path + newFileName);
                        documents.Add( new DocumentVM(){ Name = entityId + "/" + newFileName });
                     
                        NewFile = documents;
                    }
                }

                return NewFile;
            }

            return null;
        }
    }
}