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
    public class AccesslistController : Controller
    {
        private readonly IAccesslistService _AccesslistService;
        private readonly IModuleService _ModuleService;
        //public AccesslistController(): this(new AccesslistService())
        //{
        //}
        public AccesslistController()
        {
            _AccesslistService = new AccesslistService();
            _ModuleService = new ModuleService();
        }
        // GET: Accesslist
        public ActionResult Index()
        {
            (ExecutionState executionState, List<AccesslistVM> entity, string message) returnResponse = _AccesslistService.List();
             return View(returnResponse.entity);
        }

        // GET: Accesslist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Accesslist/Create
        public ActionResult Create()
        {
            AccesslistVM entity = new AccesslistVM();
            (ExecutionState executionState, List<ModuleVM> entity, string message) returnResponse = _ModuleService.List();
            ViewBag.BaseModule = new SelectList(returnResponse.entity, "Id", "ModuleName");
            return View(entity);
        }

        // POST: Accesslist/Create
        [HttpPost]
        public ActionResult Create(AccesslistVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        (ExecutionState executionState, List<ModuleVM> entity, string message) ModuleLists = _ModuleService.List();

                        ViewBag.BaseModule = new SelectList(ModuleLists.entity, "Id", "ModuleName", entity.BaseModule);
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

        // GET: Accesslist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.GetById(id);
            (ExecutionState executionState, List<ModuleVM> entity, string message) ModuleLists = _ModuleService.List();

            ViewBag.BaseModule = new SelectList(ModuleLists.entity, "Id", "ModuleName", returnResponse.entity.BaseModule);

            return View(returnResponse.entity);
        }

        // POST: Accesslist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AccesslistVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(AccesslistController.Index), "Accesslist");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        (ExecutionState executionState, List<ModuleVM> entity, string message) ModuleLists = _ModuleService.List();
                        ViewBag.BaseModule = new SelectList(ModuleLists.entity, "Id", "ModuleName", returnResponse.entity.BaseModule);
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

        // GET: Accesslist/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Accesslist deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Accesslist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AccesslistVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(AccesslistController.Index), "Accesslist");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, AccesslistVM entity, string message) returnResponse = _AccesslistService.Update(entity);
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
