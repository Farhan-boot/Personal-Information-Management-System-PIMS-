using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class ChildrenInformationController : Controller
    {
        private readonly IChildrenInformationService _ChildrenInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IModelStateValidation _ModelStateValidation;
        //public ChildrenInformationController(): this(new ChildrenInformationService())
        //{
        //}
        public ChildrenInformationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _ChildrenInformationService = new ChildrenInformationService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: ChildrenInformation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<ChildrenInformationVM> entity, string message) returnResponse = _ChildrenInformationService.List();
            return View(returnResponse.entity);
        }

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            ChildrenInformationFilterVM entity = new ChildrenInformationFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) returnResponse = _ChildrenInformationService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        // GET: ChildrenInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            string Gender = returnResponse.entity.GenderId.ToString();
            string DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth).ToString("dd-MM-yyyy");
            return Json(new { data = returnResponse.entity,Gender, DateOfBirth }, JsonRequestBehavior.AllowGet);
        }

        // GET: ChildrenInformation/Create
        public ActionResult Create()
        {
            var EmployeeInformationId = Convert.ToInt64(Session["EmployeeInformationId"]);
            if(EmployeeInformationId == 0)
            {
                Session["Message"] = "Plese Insert Employee Information.";
                Session["executionState"] = 0;
                return RedirectToAction(nameof(EmployeeInformationController.Create), "EmployeeInformation");
            }
            ChildrenInformationVM entity = new ChildrenInformationVM();
            var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
                             select new
                             {
                                 Id = (int)e,
                                 Name = e.ToString()
                             };
            ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
            ViewBag.EmployeeInformationId = EmployeeInformationId;
            return View(entity);
        }

        
        // POST: ChildrenInformation/Create
        [HttpPost]
        //public ActionResult Create(ChildrenInformationVM entity)
        //{
        //    try
        //    {
        //        var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
        //                         select new
        //                         {
        //                             Id = (int)e,
        //                             Name = e.ToString()
        //                         };
        //        ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
        //        if (ModelState.IsValid)
        //        {
        //            entity.IsActive = true;
        //            entity.CreatedAt = DateTime.Now;
        //            // TODO: Add insert logic here
        //            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Create(entity);
        //            Session["Message"] = returnResponse.message;
        //            Session["executionState"] = returnResponse.executionState;

        //            if (returnResponse.executionState.ToString() != "Created")
        //            {

        //                return View(entity);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        return View(entity);

        //    }
        //    catch
        //    {
        //        return View(entity);
        //    }
        //}
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                Session["ChildrenInformationData"] = entityVM.ChildrenInformationVM;
                Session["executionState"] = ExecutionState.Failure;
                ChildrenInformationVM entity = entityVM.ChildrenInformationVM;
                if (ModelState.IsValid)
                {
                    if (entityVM.ChildrenInformationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        //entity.CreatedBy = Convert.ToInt32(User.Identity.Name);
                        // TODO: Add insert logic here
                        (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["ChildrenInformationData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                    }
                }
                else
                {
                    Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                }
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });

            }
            catch
            {
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.ChildrenInformationVM.EmployeeInformationId });
            }
        }

        public ActionResult GetDistrictByDivisionId(long divisionId)
        {
            
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            var result = returnDistrictResponse.entity.Where(x=>x.DivisionId == divisionId).Select(y=> new { Id= y.Id, DistrictName = y.DistrictName});

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: ChildrenInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.GetById(id);
            if(returnResponse.entity == null)
            {
                    return RedirectToAction("Index");
            }
            var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
                             select new
                             {
                                 Id = (int)e,
                                 Name = e.ToString()
                             };
            ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", returnResponse.entity.GenderId);
            return View(returnResponse.entity);
        }

        // POST: ChildrenInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ChildrenInformationVM entity)
        {
            try
            {
                var GenderList = from Gender e in Enum.GetValues(typeof(Gender))
                                 select new
                                 {
                                     Id = (int)e,
                                     Name = e.ToString()
                                 };
                ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", entity.GenderId);
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(ChildrenInformationController.Index), "ChildrenInformation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Update(entity);
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
                
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        // GET: ChildrenInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "ChildrenInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: ChildrenInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ChildrenInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(ChildrenInformationController.Index), "ChildrenInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse = _ChildrenInformationService.Update(entity);
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