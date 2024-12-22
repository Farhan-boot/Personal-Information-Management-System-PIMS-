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
    public class RankController : Controller
    {
        private readonly IRankService _rankService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public RankController(): this(new RankService())
        //{
        //}
        public RankController()
        {
            _rankService = new RankService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Rank
        public ActionResult Index()
        {
            (ExecutionState executionState, List<RankVM> entity, string message) returnResponse = _rankService.List();
            
            return View(returnResponse.entity);
        }

        // GET: Rank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Rank/Create
        public ActionResult Create()
        {
            RankVM entity = new RankVM();
            return View(entity);
        }

        // POST: Rank/Create
        [HttpPost]
        public ActionResult Create(RankVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.Create(entity);
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

        // GET: Rank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.GetById(id);
            return View(returnResponse.entity);
        }

        // POST: Rank/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RankVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(RankController.Index), "Rank");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.Update(entity);
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

        
        // GET: Rank/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckItemExistOrNot = _rankService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckItemExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckItemExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Rank deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Rank/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RankVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(RankController.Index), "Rank");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, RankVM entity, string message) returnResponse = _rankService.Update(entity);
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
