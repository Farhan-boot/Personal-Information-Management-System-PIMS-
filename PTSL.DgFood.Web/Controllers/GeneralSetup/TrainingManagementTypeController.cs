using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class TrainingManagementTypeController : Controller
    {
        private readonly ITrainingManagementTypeService _TrainingManagementTypeService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        private readonly ITrainingPlanService _TrainingPlanService;
        //public TrainingManagementTypeController(): this(new TrainingManagementTypeService())
        //{
        //}
        public TrainingManagementTypeController()
        {
            _TrainingManagementTypeService = new TrainingManagementTypeService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
            _TrainingPlanService = new TrainingPlanService();
        }
        // GET: TrainingManagementType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) returnResponse = _TrainingManagementTypeService.List();

            foreach (var item in returnResponse.entity)
            {
                if (item.TrainingPlanType != 0)
                {
                    item.TrainingPlanTypeName = item.TrainingPlanType.GetEnumDisplayName() ?? "";
                }
            }

            return View(returnResponse.entity);
        }

        // GET: TrainingManagementType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: TrainingManagementType/Create
        public ActionResult Create()
        {
            TrainingManagementTypeVM entity = new TrainingManagementTypeVM();

            ViewBag.TrainingManagementTypes = EnumHelper.GetEnumDropdowns<TrainingLocationType>();
            ViewBag.LocalTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeLocalType>();
            ViewBag.ForeignTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeForeignType>();
            ViewBag.Countries = EnumHelper.GetEnumDropdowns<Country>();

            DropdownController dc = new DropdownController();
            List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");

            //Add New
            ViewBag.TrainingPlanTypeId = new SelectList(EnumHelper.GetEnumDropdowns<TrainingPlanType>(), "Id", "Name");
            ViewBag.SpecialTrainingTypeId = new SelectList(EnumHelper.GetEnumDropdowns<SpecialTrainingType>(), "Id", "Name");

            (ExecutionState executionState, List<TrainingPlanVM> entity, string message) returnResponseTrainingPlan = _TrainingPlanService.List();
            if (returnResponseTrainingPlan.entity != null)
            {
                ViewBag.TrainingPlanId = new SelectList(returnResponseTrainingPlan.entity, "Id", "PossibleTrainingWorkshopTopics", returnResponseTrainingPlan.entity);
            }
           
            return View(entity);
        }

        // POST: TrainingManagementType/Create
        [HttpPost]
        public ActionResult Create(TrainingManagementTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var returnResponseTrainingPlan = _TrainingPlanService.GetById(entity.TrainingPlanId);
                    entity.TrainingPlan = returnResponseTrainingPlan.entity.PossibleTrainingWorkshopTopics; 

                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
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
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }
        

        // GET: TrainingManagementType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.GetById(id);

            ViewBag.TrainingManagementTypes = EnumHelper.GetEnumDropdowns<TrainingLocationType>();
            ViewBag.LocalTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeLocalType>();
            ViewBag.ForeignTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeForeignType>();
            ViewBag.Countries = EnumHelper.GetEnumDropdowns<Country>();

            DropdownController dc = new DropdownController();
            List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");

            //New add
            ViewBag.TrainingPlanTypeId = new SelectList(EnumHelper.GetEnumDropdowns<TrainingPlanType>(), "Id", "Name", (int)returnResponse.entity.TrainingPlanType);
            ViewBag.SpecialTrainingTypeId = new SelectList(EnumHelper.GetEnumDropdowns<SpecialTrainingType>(), "Id", "Name", (int)returnResponse.entity.SpecialTrainingType);

            (ExecutionState executionState, List<TrainingPlanVM> entity, string message) returnResponseTrainingPlan = _TrainingPlanService.List();
            if (returnResponseTrainingPlan.entity != null)
            {
                ViewBag.TrainingPlanId = new SelectList(returnResponseTrainingPlan.entity, "Id", "PossibleTrainingWorkshopTopics", returnResponse.entity.TrainingPlanId);
            }

            return View(returnResponse.entity);
        }

        // POST: TrainingManagementType/Edit/5
        [HttpPost]
        public ActionResult Edit(TrainingManagementTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var returnResponseTrainingPlan = _TrainingPlanService.GetById(entity.TrainingPlanId);
                    entity.TrainingPlan = returnResponseTrainingPlan.entity.PossibleTrainingWorkshopTopics;

                    // TODO: Add update logic here
                    //if (id != entity.Id)
                    //{
                    //    return RedirectToAction(nameof(TrainingManagementTypeController.Index), "TrainingManagementType");
                    //}
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.TrainingManagementTypes = EnumHelper.GetEnumDropdowns<TrainingLocationType>();
                        ViewBag.LocalTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeLocalType>();
                        ViewBag.ForeignTrainingTypes = EnumHelper.GetEnumDropdowns<TrainingManagementTypeForeignType>();
                        ViewBag.Countries = EnumHelper.GetEnumDropdowns<Country>();

                        DropdownController dc = new DropdownController();
                        List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
                        ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName");
                        ViewBag.DistrictId = new SelectList("");
                        ViewBag.UpazillaId = new SelectList("");

                       return View(entity);
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
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        // GET: TrainingManagementType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _TrainingManagementTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "TrainingManagementType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: TrainingManagementType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingManagementTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(TrainingManagementTypeController.Index), "TrainingManagementType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse = _TrainingManagementTypeService.Update(entity);
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
