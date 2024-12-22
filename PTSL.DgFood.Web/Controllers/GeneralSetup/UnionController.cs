using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class UnionController : Controller
    {
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;
        public readonly IModelStateValidation _ModelStateValidation;

        public UnionController()
        {
            _UpazillaService = new UpazillaService();
            _UnionService = new UnionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        public ActionResult Index()
        {
            (ExecutionState executionState, List<UnionVM> entity, string message) returnResponse = _UnionService.List();
             return View(returnResponse.entity);
        }

        // GET: Union/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Union/Create
        public ActionResult Create()
        {
            UnionVM entity = new UnionVM();
            (ExecutionState executionState, List<UpazillaVM> entity, string message) returnResponse = _UpazillaService.List();
            ViewBag.UpazillaId = new SelectList(returnResponse.entity, "Id", "Name");
            return View(entity);
        }

        // POST: Union/Create
        [HttpPost]
        public ActionResult Create(UnionVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.Create(entity);
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

        // GET: Union/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.GetById(id);
            (ExecutionState executionState, List<UpazillaVM> entity, string message) UpazillaLists = _UpazillaService.List();

            ViewBag.UpazillaId = new SelectList(UpazillaLists.entity, "Id", "Name", returnResponse.entity.UpazillaId);

            return View(returnResponse.entity);
        }

        // POST: Union/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UnionVM entity)
        {
            try
            {
                (ExecutionState executionState, List<UpazillaVM> entity, string message) UpazillaLists = _UpazillaService.List();
                ViewBag.UpazillaId = new SelectList(UpazillaLists.entity, "Id", "UpazillaName", entity.UpazillaId);
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(UnionController.Index), "Union");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.UpazillaId = new SelectList(UpazillaLists.entity, "Id", "UpazillaName", returnResponse.entity.UpazillaId);
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

        // GET: Union/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _UnionService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}

            (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Union deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Union/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UnionVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(UnionController.Index), "Union");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, UnionVM entity, string message) returnResponse = _UnionService.Update(entity);
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
