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
    public class ServiceHistoryController : Controller
    {
        private readonly IServiceHistoryService _ServiceHistoryService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public ServiceHistoryController(): this(new ServiceHistoryService())
        //{
        //}
        public ServiceHistoryController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _ServiceHistoryService = new ServiceHistoryService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: ServiceHistory

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            ServiceHistoryFilterVM entity = new ServiceHistoryFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<ServiceHistoryListVM> entity, string message) returnResponse = _ServiceHistoryService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

         
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse = _ServiceHistoryService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            string DateOfGovtService = returnResponse.entity.DateOfGovtService != null ? Convert.ToDateTime(returnResponse.entity.DateOfGovtService).ToString("dd-MM-yyyy") : "";
            string DateOfGazetted = returnResponse.entity.DateOfGazetted != null ? Convert.ToDateTime(returnResponse.entity.DateOfGazetted).ToString("dd-MM-yyyy") : "";
            string EncadrementDate = returnResponse.entity.EncadrementDate != null ? Convert.ToDateTime(returnResponse.entity.EncadrementDate).ToString("dd-MM-yyyy") : "";
            string Cadre = returnResponse.entity.CadreId != 0 && returnResponse.entity.CadreId != null ? EnumHelper.GetEnumDisplayName((Cadre)(int)returnResponse.entity.CadreId) : "";
            return Json(new { data = returnResponse.entity, DateOfGovtService, DateOfGazetted, EncadrementDate, Cadre }, JsonRequestBehavior.AllowGet);
        }
        // POST: ServiceHistory/Create
        [HttpPost]
       
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                ServiceHistoryVM entity = entityVM.ServiceHistoryVM;
                Session["ServiceHistoryData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if(entityVM.ServiceHistoryVM.CadreId == null)
                    {
                        entityVM.ServiceHistoryVM.CadreId = 0;
                    }
                    if (entityVM.ServiceHistoryVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse = _ServiceHistoryService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["ServiceHistoryData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse = _ServiceHistoryService.Update(entity);
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.ServiceHistoryVM.EmployeeInformationId });
            }
        }

       
         
        // GET: ServiceHistory/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse = _ServiceHistoryService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "ServiceHistory deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: ServiceHistory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ServiceHistoryVM entity)
        {
            try
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse = _ServiceHistoryService.Update(entity);
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