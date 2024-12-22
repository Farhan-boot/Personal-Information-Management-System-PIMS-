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
    public class PmsGroupController : Controller
    {
        private readonly IPmsGroupService _PmsGroupService;
        //public PmsGroupController(): this(new PmsGroupService())
        //{
        //}
        public PmsGroupController()
        {
            _PmsGroupService = new PmsGroupService();
        }
        // GET: PmsGroup
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PmsGroupVM> entity, string message) returnResponse = _PmsGroupService.List();
             return View(returnResponse.entity);
        }

        // GET: PmsGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: PmsGroup/Create
        public ActionResult Create()
        {
            PmsGroupVM entity = new PmsGroupVM();
            return View(entity);
        }

        // POST: PmsGroup/Create
        [HttpPost]
        public ActionResult Create(PmsGroupVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.Create(entity);
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
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PmsGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.GetById(id);
            
            return View(returnResponse.entity);
        }

        // POST: PmsGroup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PmsGroupVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(PmsGroupController.Index), "PmsGroup");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.Update(entity);
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
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PmsGroup/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PmsGroup deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PmsGroup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PmsGroupVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PmsGroupController.Index), "PmsGroup");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PmsGroupVM entity, string message) returnResponse = _PmsGroupService.Update(entity);
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
