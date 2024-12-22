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
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class TrainingInformationController : Controller
    {
        private readonly ITrainingInformationService _TrainingInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public TrainingInformationController(): this(new TrainingInformationService())
        //{
        //}
        public TrainingInformationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _TrainingInformationService = new TrainingInformationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: TrainingInformation

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            TrainingInformationFilterVM entity = new TrainingInformationFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<TrainingInfoListVM> entity, string message) returnResponse = _TrainingInformationService.GetFilterData(entity);

            return View(returnResponse.entity);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse = _TrainingInformationService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            string FromDate = returnResponse.entity.FromDate.ToString("dd-MM-yyyy");
            string ToDate = returnResponse.entity.ToDate.ToString("dd-MM-yyyy");
            string Country = returnResponse.entity.CountryId != null && returnResponse.entity.CountryId != 0 ? EnumHelper.GetEnumDisplayName((Country)(int)returnResponse.entity.CountryId) : ""; 
            string TrainingType = returnResponse.entity.TrainingTypeId != 0 && returnResponse.entity.TrainingTypeId != null ? EnumHelper.GetEnumDisplayName((TrainingType)(int)returnResponse.entity.TrainingTypeId) : "";
            return Json(new { data = returnResponse.entity, FromDate,ToDate , Country, TrainingType }, JsonRequestBehavior.AllowGet);
        }
        // POST: TrainingInformation/Create
        [HttpPost]
       
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                TrainingInformationVM entity = entityVM.TrainingInformationVM;
                Session["TrainingInformationData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if(entityVM.TrainingInformationVM.CountryId == null)
                    {
                        entityVM.TrainingInformationVM.CountryId = 0;
                    }
                    if (entityVM.TrainingInformationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse = _TrainingInformationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["TrainingInformationData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse = _TrainingInformationService.Update(entity);
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.TrainingInformationVM.EmployeeInformationId });
            }
        }

       
         
        // GET: TrainingInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse = _TrainingInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "TrainingInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: TrainingInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingInformationVM entity)
        {
            try
            { 
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse = _TrainingInformationService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }    }
}