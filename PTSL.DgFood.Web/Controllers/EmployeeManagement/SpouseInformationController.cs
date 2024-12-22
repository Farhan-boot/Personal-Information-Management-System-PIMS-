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
    public class SpouseInformationController : Controller
    {
        private readonly ISpouseInformationService _SpouseInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public SpouseInformationController(): this(new SpouseInformationService())
        //{
        //}
        public SpouseInformationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _SpouseInformationService = new SpouseInformationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: SpouseInformation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<SpouseInformationVM> entity, string message) returnResponse = _SpouseInformationService.List();
            return View(returnResponse.entity);
        }
        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            SpouseInformationFilterVM entity = new SpouseInformationFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, List<SpouseInformationListVM> entity, string message) returnResponse = _SpouseInformationService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        

        // GET: SpouseInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.GetById(id);
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }
      
        // GET: SpouseInformation/Create
        public ActionResult Create()
        {
            var EmployeeInformationId = Convert.ToInt64(Session["EmployeeInformationId"]);
            if(EmployeeInformationId == 0)
            {
                Session["Message"] = "Plese Insert Employee Information.";
                Session["executionState"] = 0;
                return RedirectToAction(nameof(EmployeeInformationController.Create), "EmployeeInformation");
            }
            SpouseInformationVM entity = new SpouseInformationVM();
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnDivisionResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse.entity, "Id", "DivisionName");
            ViewBag.EmployeeInformationId = EmployeeInformationId;
            return View(entity);
        }

        
        [HttpPost]
        public ActionResult GetSpouceInformationByEmployeeId(long employeeid)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnSpouceInfoResponse = _SpouseInformationService.GetById(employeeid);
            if(returnSpouceInfoResponse.entity == null)
            {
                returnSpouceInfoResponse.entity = new SpouseInformationVM();
            }
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList(returnResponse.entity, "Id", "DivisionName");

            return PartialView("_SpouceInformationPartial", returnSpouceInfoResponse.entity);
        }
        // POST: SpouseInformation/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            { 
                SpouseInformationVM entity = entityVM.SpouseInformationVM;
                Session["SpouseData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    if (entityVM.SpouseInformationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["SpouseData"] = returnResponse.entity;
                        }
                    }
                    else
                    { 
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.Update(entity);
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.SpouseInformationVM.EmployeeInformationId });
            }
        }

        
        public ActionResult GetDistrictByDivisionId(long divisionId)
        {
            
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            var result = returnDistrictResponse.entity.Where(x=>x.DivisionId == divisionId).Select(y=> new { Id= y.Id, DistrictName = y.DistrictName});

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: SpouseInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.GetById(id);
            if(returnResponse.entity == null)
            {
                    return RedirectToAction("Index");
            }
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnDivisionResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse.entity, "Id", "DivisionName", returnResponse.entity.DivisionId);
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            ViewBag.DistrictId = new SelectList(returnDistrictResponse.entity.Where(x => x.DivisionId == returnResponse.entity.DivisionId), "Id", "DistrictName", returnResponse.entity.DistrictId);

            return View(returnResponse.entity);
        }

        // POST: SpouseInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SpouseInformationVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DivisionVM> entity, string message) returnDivisionResponse = _DivisionService.List();
                ViewBag.DivisionId = new SelectList(returnDivisionResponse.entity, "Id", "DivisionName", entity.DivisionId);
                (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
                ViewBag.DistrictId = new SelectList(returnDistrictResponse.entity.Where(x => x.DivisionId == entity.DivisionId), "Id", "DistrictName", entity.DistrictId);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(SpouseInformationController.Index), "SpouseInformation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.Update(entity);
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
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        // GET: SpouseInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "SpouseInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: SpouseInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SpouseInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(SpouseInformationController.Index), "SpouseInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse = _SpouseInformationService.Update(entity);
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