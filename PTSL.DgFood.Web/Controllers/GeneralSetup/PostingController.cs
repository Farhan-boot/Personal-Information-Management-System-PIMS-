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
    public class PostingController : Controller
    {
        private readonly IPostingService _PostingService;
        private readonly IPostingTypeService _PostingTypeService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PostingController(): this(new PostingService())
        //{
        //}
        public PostingController()
        {
            _PostingService = new PostingService();
            _PostingTypeService = new PostingTypeService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Posting
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PostingVM> entity, string message) returnResponse = _PostingService.List();
             return View(returnResponse.entity);
        }

        // GET: Posting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Posting/Create
        public ActionResult Create()
        {
            PostingVM entity = new PostingVM();
            (ExecutionState executionState, List<PostingTypeVM> entity, string message) returnResponse = _PostingTypeService.List();
            ViewBag.PostingTypeId = new SelectList(returnResponse.entity, "Id", "PostingTypeName");
            return View(entity);
        }

        // POST: Posting/Create
        [HttpPost]
        public ActionResult Create(PostingVM entity)
        {
            try
            {
                (ExecutionState executionState, List<PostingTypeVM> entity, string message) PostingTypeLists = _PostingTypeService.List();

                ViewBag.PostingTypeId = new SelectList(PostingTypeLists.entity, "Id", "PostingTypeName", entity.PostingTypeId);

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        ViewBag.PostingTypeId = new SelectList(PostingTypeLists.entity, "Id", "PostingTypeName", entity.PostingTypeId);
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

        // GET: Posting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.GetById(id);
            (ExecutionState executionState, List<PostingTypeVM> entity, string message) PostingTypeLists = _PostingTypeService.List();

            ViewBag.PostingTypeId = new SelectList(PostingTypeLists.entity, "Id", "PostingTypeName", returnResponse.entity.PostingTypeId);

            return View(returnResponse.entity);
        }

        // POST: Posting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostingVM entity)
        {
            try
            {

                (ExecutionState executionState, List<PostingTypeVM> entity, string message) PostingTypeLists = _PostingTypeService.List();
                ViewBag.PostingTypeId = new SelectList(PostingTypeLists.entity, "Id", "PostingTypeName", entity.PostingTypeId);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(PostingController.Index), "Posting");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        ViewBag.PostingTypeId = new SelectList(PostingTypeLists.entity, "Id", "PostingTypeName", returnResponse.entity.PostingTypeId);
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

        // GET: Posting/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _PostingService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Posting deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Posting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PostingVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PostingController.Index), "Posting");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PostingVM entity, string message) returnResponse = _PostingService.Update(entity);
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
