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
    public class EducationalQualificationController : Controller
    {
        private readonly IEducationalQualificationService _EducationalQualificationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public EducationalQualificationController(): this(new EducationalQualificationService())
        //{
        //}
        public EducationalQualificationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _EducationalQualificationService = new EducationalQualificationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: EducationalQualification

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            EducationalQualificationFilterVM entity = new EducationalQualificationFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<EducationalQualificationListVM> entity, string message) returnResponse = _EducationalQualificationService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }
        // POST: EducationalQualification/Create
        [HttpPost]
       
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                EducationalQualificationVM entity = entityVM.EducationalQualificationVM;
                Session["EducationalQualificationData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entityVM.EducationalQualificationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["EducationalQualificationData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.Update(entity);
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.EducationalQualificationVM.EmployeeInformationId });
            }
        }

        public ActionResult GetDistrictByDivisionId(long divisionId)
        {
            
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            var result = returnDistrictResponse.entity.Where(x=>x.DivisionId == divisionId).Select(y=> new { Id= y.Id, DistrictName = y.DistrictName});

            return Json(result, JsonRequestBehavior.AllowGet);
        }
         
        // GET: EducationalQualification/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "EducationalQualification deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: EducationalQualification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EducationalQualificationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                //if (id != entity.Id)
                //{
                //    return RedirectToAction(nameof(EducationalQualificationController.Index), "EducationalQualification");
                //}
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse = _EducationalQualificationService.Update(entity);
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