using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class UpazillaController : Controller
    {
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        public readonly IModelStateValidation _ModelStateValidation;

        public UpazillaController()
        {
            _DistrictService = new DistrictService();
            _UpazillaService = new UpazillaService();
            _ModelStateValidation = new ModelStateValidation();
        }
        public ActionResult Index()
        {
            (ExecutionState executionState, List<UpazillaVM> entity, string message) returnResponse = _UpazillaService.List();
             return View(returnResponse.entity);
        }

        // GET: Upazilla/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Upazilla/Create
        public ActionResult Create()
        {
            UpazillaVM entity = new UpazillaVM();
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnResponse = _DistrictService.List();
            ViewBag.DistrictId = new SelectList(returnResponse.entity, "Id", "DistrictName");
            return View(entity);
        }

        // POST: Upazilla/Create
        [HttpPost]
        public ActionResult Create(UpazillaVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Create(entity);
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

        // GET: Upazilla/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.GetById(id);
            (ExecutionState executionState, List<DistrictVM> entity, string message) DistrictLists = _DistrictService.List();

            ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", returnResponse.entity.DistrictId);

            return View(returnResponse.entity);
        }

        // POST: Upazilla/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpazillaVM entity)
        {
            try
            {
                (ExecutionState executionState, List<DistrictVM> entity, string message) DistrictLists = _DistrictService.List();
                ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", entity.DistrictId);
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(UpazillaController.Index), "Upazilla");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.DistrictId = new SelectList(DistrictLists.entity, "Id", "DistrictName", returnResponse.entity.DistrictId);
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

        // GET: Upazilla/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _UpazillaService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Upazilla deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Upazilla/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UpazillaVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(UpazillaController.Index), "Upazilla");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Update(entity);
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
