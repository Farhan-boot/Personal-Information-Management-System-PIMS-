using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class PostResponsibilityController : Controller
    {
        private readonly IPostResponsibilityService _PostResponsibilityService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PostResponsibilityController(): this(new PostResponsibilityService())
        //{
        //}
        public PostResponsibilityController()
        {
            _PostResponsibilityService = new PostResponsibilityService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PostResponsibility
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PostResponsibilityVM> entity, string message) returnResponse = _PostResponsibilityService.List();
             return View(returnResponse.entity);
        }

        // GET: PostResponsibility/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: PostResponsibility/Create
        public ActionResult Create()
        {
            PostResponsibilityVM entity = new PostResponsibilityVM();
            return View(entity);
        }

        // POST: PostResponsibility/Create
        [HttpPost]
        public ActionResult Create(PostResponsibilityVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.Create(entity);
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
        

        // GET: PostResponsibility/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.GetById(id);
            return View(returnResponse.entity);
        }

        // POST: PostResponsibility/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostResponsibilityVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(PostResponsibilityController.Index), "PostResponsibility");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.Update(entity);
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

        // GET: PostResponsibility/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _PostResponsibilityService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PostResponsibility deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PostResponsibility/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PostResponsibilityVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PostResponsibilityController.Index), "PostResponsibility");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse = _PostResponsibilityService.Update(entity);
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
