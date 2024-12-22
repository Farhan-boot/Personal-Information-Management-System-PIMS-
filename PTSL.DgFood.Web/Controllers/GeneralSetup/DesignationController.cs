using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DesignationController : Controller
    {
        private readonly IDesignationService _DesignationService;
        private readonly IDesignationClassService _DesignationClassService;
        private readonly IRankService _RankService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public DesignationController(): this(new DesignationService())
        //{
        //}
        public DesignationController()
        {
            _DesignationService = new DesignationService();
            _DesignationClassService = new DesignationClassService();
            _RankService = new RankService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Designation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<DesignationVM> entity, string message) returnResponse = _DesignationService.List();
             return View(returnResponse.entity);
        }

        // GET: Designation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.GetById(id); // GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Designation/Create
        public ActionResult Create()
        {
            DesignationVM entity = new DesignationVM();
            (ExecutionState executionState, List<DesignationClassVM> entity, string message) returnResponse = _DesignationClassService.List();
            (ExecutionState executionState, List<RankVM> entity, string message) returnRankResponse = _RankService.List();
            ViewBag.DesignationClassId = new SelectList(returnResponse.entity, "Id", "DesignationClassName");
            ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName");
            return View(entity);
        }

        // POST: Designation/Create
        [HttpPost]
        public ActionResult Create(DesignationVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DesignationClassVM> entity, string message) DesignationClassLists = _DesignationClassService.List();
                ViewBag.DesignationClassId = new SelectList(DesignationClassLists.entity, "Id", "DesignationClassName", entity.DesignationClassId);

                (ExecutionState executionState, List<RankVM> entity, string message) returnRankResponse = _RankService.List();
                ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName", entity.RankId);

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        ViewBag.DesignationClassId = new SelectList(DesignationClassLists.entity, "Id", "DesignationClassName", entity.DesignationClassId);                         
                        ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName",entity.RankId);
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

        // GET: Designation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.GetById(id);
            (ExecutionState executionState, List<DesignationClassVM> entity, string message) DesignationClassLists = _DesignationClassService.List();
            ViewBag.DesignationClassId = new SelectList(DesignationClassLists.entity, "Id", "DesignationClassName", returnResponse.entity.DesignationClassId);

            
            (ExecutionState executionState, List<RankVM> entity, string message) returnRankResponse = _RankService.List();
            ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName", returnResponse.entity.RankId);

            return View(returnResponse.entity);
        }

        // POST: Designation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DesignationVM entity)
        {
            try
            {
                (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.GetById(id);
                (ExecutionState executionState, List<DesignationClassVM> entity, string message) DesignationClassLists = _DesignationClassService.List();
                ViewBag.DesignationClassId = new SelectList(DesignationClassLists.entity, "Id", "DesignationClassName", returnResponse.entity.DesignationClassId);


                (ExecutionState executionState, List<RankVM> entity, string message) returnRankResponse = _RankService.List();
                ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName", returnResponse.entity.RankId);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(DesignationController.Index), "Designation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    returnResponse = _DesignationService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    { 
                        ViewBag.DesignationClassId = new SelectList(DesignationClassLists.entity, "Id", "DesignationClassName", entity.DesignationClassId);
                         
                        ViewBag.RankId = new SelectList(returnRankResponse.entity, "Id", "RankName", entity.RankId);
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

        // GET: Designation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DesignationService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }

            (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Designation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Designation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DesignationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DesignationController.Index), "Designation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DesignationVM entity, string message) returnResponse = _DesignationService.Update(entity);
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
