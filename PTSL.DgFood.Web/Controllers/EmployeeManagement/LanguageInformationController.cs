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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class LanguageInformationController : Controller
    {
        private readonly ILanguageInformationService _LanguageInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public LanguageInformationController(): this(new LanguageInformationService())
        //{
        //}
        public LanguageInformationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _LanguageInformationService = new LanguageInformationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: LanguageInformation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<LanguageInformationVM> entity, string message) returnResponse = _LanguageInformationService.List();
            return View(returnResponse.entity);
        }

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            LanguageInformationFilterVM entity = new LanguageInformationFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<LanguageInfoListVM> entity, string message) returnResponse = _LanguageInformationService.GetFilterData(entity);

            return View(returnResponse.entity);
        }
        // GET: LanguageInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            //string Gender = returnResponse.entity.GenderId.ToString();
            //string DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth).ToString("dd-MM-yyyy");
            return Json(new { data = returnResponse.entity }, JsonRequestBehavior.AllowGet);
        }

        // GET: LanguageInformation/Create
        public ActionResult Create()
        {
            var EmployeeInformationId = Convert.ToInt64(Session["EmployeeInformationId"]);
            if(EmployeeInformationId == 0)
            {
                Session["Message"] = "Plese Insert Employee Information.";
                Session["executionState"] = 0;
                return RedirectToAction(nameof(EmployeeInformationController.Create), "EmployeeInformation");
            }
            DropdownController dc = new DropdownController();
            LanguageInformationVM entity = new LanguageInformationVM();
            List<LanguageVM> returnPostingRecordsCurrDesignationClassResponse = dc.GetLanguages();
            ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsCurrDesignationClassResponse, "Id", "LanguageName");

            
            ViewBag.EmployeeInformationId = EmployeeInformationId;
            return View(entity);
        }

        
        // POST: LanguageInformation/Create
        [HttpPost]
         
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                LanguageInformationVM entity = entityVM.LanguageInformationVM;
                Session["LanguageInformationData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entityVM.LanguageInformationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["LanguageInformationData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });

            }
            catch
            {
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.LanguageInformationVM.EmployeeInformationId });
            }
        }

        public ActionResult GetDistrictByDivisionId(long divisionId)
        {
            
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            var result = returnDistrictResponse.entity.Where(x=>x.DivisionId == divisionId).Select(y=> new { Id= y.Id, DistrictName = y.DistrictName});

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: LanguageInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.GetById(id);
            if(returnResponse.entity == null)
            {
                    return RedirectToAction("Index");
            }
            var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
                             select new
                             {
                                 Id = (int)e,
                                 Name = e.ToString()
                             };

            DropdownController dc = new DropdownController();
            List<LanguageVM> returnPostingRecordsCurrDesignationClassResponse = dc.GetLanguages();
            ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsCurrDesignationClassResponse, "Id", "LanguageName", returnResponse.entity.LanguageId);

            return View(returnResponse.entity);
        }

        // POST: LanguageInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LanguageInformationVM entity)
        {
            try
            {
                
                DropdownController dc = new DropdownController();
                List<LanguageVM> returnPostingRecordsCurrDesignationClassResponse = dc.GetLanguages();
                ViewBag.PostingRecordsCurrDesignationClassId = new SelectList(returnPostingRecordsCurrDesignationClassResponse, "Id", "LanguageName", entity.LanguageId);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(LanguageInformationController.Index), "LanguageInformation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.Update(entity);
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
                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        // GET: LanguageInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "LanguageInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: LanguageInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LanguageInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(LanguageInformationController.Index), "LanguageInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse = _LanguageInformationService.Update(entity);
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