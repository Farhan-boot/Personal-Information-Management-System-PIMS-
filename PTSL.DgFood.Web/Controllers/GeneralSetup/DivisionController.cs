﻿using EnglishAndBanglaFeildValidation.Implementation;
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
    public class DivisionController : Controller
    {
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public DivisionController(): this(new DivisionService())
        //{
        //}
        public DivisionController()
        {
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Division
        public ActionResult Index()
        {
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
            
            return View(returnResponse.entity);
        }

        // GET: Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Division/Create
        public ActionResult Create()
        {
            DivisionVM entity = new DivisionVM();
            return View(entity);
        }

        // POST: Division/Create
        [HttpPost]
        public ActionResult Create(DivisionVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.Create(entity);
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

        // GET: Division/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.GetById(id);
            return View(returnResponse.entity);
        }

        // POST: Division/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DivisionVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(DivisionController.Index), "Division");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.Update(entity);
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

        // GET: Division/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DivisionService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Division deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Division/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DivisionVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DivisionController.Index), "Division");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DivisionVM entity, string message) returnResponse = _DivisionService.Update(entity);
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
