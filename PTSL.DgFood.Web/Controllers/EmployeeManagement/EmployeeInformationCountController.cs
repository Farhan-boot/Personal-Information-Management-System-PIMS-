using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class EmployeeInformationCountController : Controller
    {
        private readonly IEmployeeInformationCountService _EmployeeInformationCountService;
        public readonly IModelStateValidation _ModelStateValidation;
        public EmployeeInformationCountController()
        {
            _EmployeeInformationCountService = new EmployeeInformationCountService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Category
        public ActionResult Index()
        {
            (ExecutionState executionState, List<EmployeeInformationCountVM> entity, string message) returnResponse = _EmployeeInformationCountService.List();
            return View(returnResponse.entity);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            EmployeeInformationCountVM entity = new EmployeeInformationCountVM();
            DropdownController dc = new DropdownController();
            List<DesignationVM> returnDesignation = dc.GetDesignations();
            //ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName", returnResponse.entity.DistrictId);
            ViewBag.DesignationID = new SelectList("");// new SelectList(null, "Id", "DesignationName");

            List<RankVM> returnPromotionPartcularsRankResponse = dc.GetRanks();
            ViewBag.RankId = new SelectList(returnPromotionPartcularsRankResponse, "Id", "RankName");
            ICollection<DesignationClassVM> returnOfficialInformationPresentDesignationClassResponse = dc.GetDesignationClasses();
            ViewBag.DesignationClassId = new SelectList(returnOfficialInformationPresentDesignationClassResponse, "Id", "DesignationClassName");

            return View(entity);
        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(EmployeeInformationCountVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    DropdownController dc = new DropdownController();
                    List<DesignationVM> returnDesignation = dc.GetDesignations();
                    ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName", entity.DesignationID);

                    List<RankVM> returnPromotionPartcularsRankResponse = dc.GetRanks();
                    ViewBag.RankId = new SelectList(returnPromotionPartcularsRankResponse, "Id", "RankName", entity.RankId);

                    ICollection<DesignationClassVM> returnOfficialInformationPresentDesignationClassResponse = dc.GetDesignationClasses();
                    ViewBag.DesignationClassId = new SelectList(returnOfficialInformationPresentDesignationClassResponse, "Id", "DesignationClassName", entity.DesignationClassId);


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
        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DropdownController dc = new DropdownController();
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.GetById(id);

            List<DesignationVM> returnDesignation = dc.GetDesignations();
            ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName", returnResponse.entity.DesignationID);

            List<RankVM> returnPromotionPartcularsRankResponse = dc.GetRanks();
            ViewBag.RankId = new SelectList(returnPromotionPartcularsRankResponse, "Id", "RankName", returnResponse.entity.RankId);

            ICollection<DesignationClassVM> returnOfficialInformationPresentDesignationClassResponse = dc.GetDesignationClasses();
            ViewBag.DesignationClassId = new SelectList(returnOfficialInformationPresentDesignationClassResponse, "Id", "DesignationClassName", returnResponse.entity.DesignationClassId);

            return View(returnResponse.entity);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeInformationCountVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(EmployeeInformationCountController.Index), "Category");
                    }
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.Update(entity);
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

        // GET: Category/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _EmployeeInformationCountService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Category deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeInformationCountVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(EmployeeInformationCountController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse = _EmployeeInformationCountService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}