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
    public class PayScaleYearInfoController : Controller
    {
        private readonly IPayScaleYearInfoService _PayScaleYearInfoService;
        private readonly IDivisionService _DivisionService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PayScaleYearInfoController(): this(new PayScaleYearInfoService())
        //{
        //}
        public PayScaleYearInfoController()
        {
            _PayScaleYearInfoService = new PayScaleYearInfoService();
            _DivisionService = new DivisionService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PayScaleYearInfo
        public ActionResult Index()
        {
            (ExecutionState executionState, List<PayScaleYearInfoVM> entity, string message) returnResponse = _PayScaleYearInfoService.List();
             return View(returnResponse.entity);
        }

        // GET: PayScaleYearInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: PayScaleYearInfo/Create
        public ActionResult Create()
        {
            PayScaleYearInfoVM entity = new PayScaleYearInfoVM();            
            return View(entity);
        }

        // POST: PayScaleYearInfo/Create
        [HttpPost]
        public ActionResult Create(PayScaleYearInfoVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.Create(entity);
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
        

        // GET: PayScaleYearInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: PayScaleYearInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PayScaleYearInfoVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(PayScaleYearInfoController.Index), "PayScaleYearInfo");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.Update(entity);
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

        // GET: PayScaleYearInfo/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _PayScaleYearInfoService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            }
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PayScaleYearInfo deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PayScaleYearInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PayScaleYearInfoVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(PayScaleYearInfoController.Index), "PayScaleYearInfo");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse = _PayScaleYearInfoService.Update(entity);
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
