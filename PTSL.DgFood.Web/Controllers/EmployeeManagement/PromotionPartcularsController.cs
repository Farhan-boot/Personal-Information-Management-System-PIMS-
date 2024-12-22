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
    public class PromotionPartcularsController : Controller
    {
        private readonly IPromotionPartcularsService _PromotionPartcularsService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PromotionPartcularsController(): this(new PromotionPartcularsService())
        //{
        //}
        public PromotionPartcularsController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _PromotionPartcularsService = new PromotionPartcularsService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PromotionPartcularsv               
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PromotionPartcularsVM> entity, string message) returnResponse = _PromotionPartcularsService.List();
            return View(returnResponse.entity);
        }

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            PromotionPartcularsFilterVM entity = new PromotionPartcularsFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<PromotionParticularsListVM> entity, string message) returnResponse = _PromotionPartcularsService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        // GET: PromotionPartculars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse = _PromotionPartcularsService.GetById(id);
            //$('#PromotionParticular_Rank').text(response.data.Rank.RankName);
            // $('#PromotionParticular_Designation').text(response.data.Designation.DesignationName);
            string PromotionDate = returnResponse.entity.PromotionDate != null ? Convert.ToDateTime(returnResponse.entity.PromotionDate).ToString("dd-MM-yyyy") : "";
            string NatureOfPromotion = returnResponse.entity.PromtionNatureId != 0 ? returnResponse.entity.PromtionNatureDTO.PromtionNatureName.ToString() : "";
            string GODate = returnResponse.entity.GODate != null ? Convert.ToDateTime(returnResponse.entity.GODate).ToString("dd-MM-yyyy") : "";
            string YearOfPayScale = returnResponse.entity.PayScaleYearInfoId != 0 ? returnResponse.entity.PayScaleYearInfoDTO.PayScaleYearInfoName.ToString() : "";
              
            return Json(new { data = returnResponse.entity, PromotionDate, NatureOfPromotion, GODate , YearOfPayScale }, JsonRequestBehavior.AllowGet);
        }
      
     
        // POST: PromotionPartculars/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            { 
                PromotionPartcularsVM entity = entityVM.PromotionPartcularsVM;
                Session["PromotionPartcularsData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entityVM.PromotionPartcularsVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse = _PromotionPartcularsService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["PromotionPartcularsData"] = returnResponse.entity;
                        }
                    }
                    else
                    {
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse = _PromotionPartcularsService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.PromotionPartcularsVM.EmployeeInformationId });
            }
        }
         
         
        // GET: PromotionPartculars/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse = _PromotionPartcularsService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PromotionPartculars deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PromotionPartculars/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PromotionPartcularsVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PromotionPartcularsController.Index), "PromotionPartculars");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse = _PromotionPartcularsService.Update(entity);
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