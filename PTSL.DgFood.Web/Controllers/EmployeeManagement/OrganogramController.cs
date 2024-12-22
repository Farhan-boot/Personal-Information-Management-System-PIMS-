using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using Newtonsoft.Json;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model.ViewModel;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class OrganogramController : Controller
    {
        private readonly IOrganogramService _OrganogramService;
        public readonly IModelStateValidation _ModelStateValidation;
        public readonly IDesignationService _DesignationService;
        public readonly IPostingTypeService _PostingTypeService;
        public readonly IPostingService _PostingService;
        public OrganogramController()
        {
            _OrganogramService = new OrganogramService();
            _ModelStateValidation = new ModelStateValidation();
            _DesignationService = new DesignationService();
            _PostingTypeService = new PostingTypeService();
            _PostingService = new PostingService();
        }
        // GET: Category
        public ActionResult Index()
        {
            OrganogramDetailsVM entity = new OrganogramDetailsVM();
            DropdownController dc = new DropdownController();
            List<PostingTypeVM> returnPostingRecordsResponse = dc.GetPostingTypes();
            ViewBag.PostingTypeId = new SelectList(returnPostingRecordsResponse, "Id", "PostingTypeName");
            ICollection<PostingVM> returnPostingResponse = dc.GetPostings();
            ViewBag.PostingId = new SelectList(returnPostingResponse, "Id", "PostingName"); 
            List<DesignationVM> returnDesignation = dc.GetDesignations();
            ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName");
            ViewBag.OrganogramOfficeTypes = EnumHelper.GetEnumDropdowns<OrganogramOfficeType>();

            List<RootObject> node = new List<RootObject>();

            //List<OrganogramVM> organogramlist = new List<OrganogramVM>();
            (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) organogramlist = _OrganogramService.ListDetails();
            ViewBag.ParentPostingId = new SelectList("");
            if (organogramlist.entity != null)
            {
                List<OrganogramDetailsVM> ParentList = organogramlist.entity.Where(x => x.IsParent == true).ToList();
                ViewBag.ParentPostingId = new SelectList(ParentList, "Id", "Name");
                
                foreach (var item in organogramlist.entity)
                {
                    RootObject child = new RootObject();
                    child.id = Convert.ToInt32(item.Id);

                    var remain = (item.TotalPost - item.EmployeeCount);
                    var totalRemain = remain < 0 ? 0 : remain;
                    var permanentString = item.IsPermanent == false ? " (Non-Permanent)," : "";
                    child.text = item.Name + (item.IsParent == false ? $",{permanentString} Total Posts ({item.TotalPost}), Remaining ({totalRemain})" : "");
                    child.parentid = Convert.ToInt32(item.ParentId);

                    if (item.IsPermanent == false)
                    {
                        child.li_attr.__class = "non_permanent";
                    }

                    node.Add(child);
                }

            } 

            List<RootObject> xxx = BuildTree(node);

            string json = JsonConvert.SerializeObject(xxx);
            ViewBag.nodeData = json; 

            return View(entity);
        }

        static List<RootObject> BuildTree(List<RootObject> items)
        {
            items.ForEach(i => i.children = items.Where(ch => ch.parentid == i.id).ToList());
            return items.Where(i => i.parentid == 0).ToList();
        }

        [HttpGet]
        public JsonResult GetOrganogramInfoById(long id)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) organogramData = _OrganogramService.GetById(id);
            return Json(new { Result = "Success", organogramData.entity }, JsonRequestBehavior.AllowGet);
        } 

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            OrganogramVM entity = new OrganogramVM();
            DropdownController dc = new DropdownController();
            List<PostingTypeVM> returnPostingRecordsResponse = dc.GetPostingTypes();
            ViewBag.PostingTypeId = new SelectList(returnPostingRecordsResponse, "Id", "PostingTypeName");
            ICollection<PostingVM> returnPostingResponse = dc.GetPostings();
            ViewBag.PostingId = new SelectList(returnPostingResponse, "Id", "PostingName"); 
            ViewBag.ParentPostingId = new SelectList(returnPostingResponse, "Id", "PostingName");


            List<DesignationVM> returnDesignation = dc.GetDesignations();
            ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName");
            
            return View(entity);
        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(OrganogramVM entity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    entity.Name = "";
                    if(entity.DesignationID > 0)
                    {
                        (ExecutionState executionState, DesignationVM entity, string message) returnDesignationById = _DesignationService.GetById(entity.DesignationID);
                        entity.Name = returnDesignationById.entity.DesignationName;
                    }
                    else if (entity.PostingId > 0)
                    {
                        (ExecutionState executionState, PostingVM entity, string message) returnPostingById = _PostingService.GetById(entity.PostingId);
                        entity.Name = returnPostingById.entity.PostingName;
                    }
                    else if (entity.OrganogramOfficeType > 0)
                    {
                        entity.Name = entity.OrganogramOfficeType.GetEnumDisplayName();
                    }

                    if(entity.Id > 0)
                    {
                        (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                    }
                    else
                    {
                        (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                } 
                return RedirectToAction("Index");
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                //return View(entity);
                return RedirectToAction("Index");
            }
        }
        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DropdownController dc = new DropdownController();
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.GetById(id);
             
            /*
            List<PostingTypeVM> returnPostingRecordsResponse = dc.GetPostingTypes();
            ViewBag.PostingTypeId = new SelectList(returnPostingRecordsResponse, "Id", "PostingTypeName", returnResponse.entity.PostingTypeId);
            */

            ICollection<PostingVM> returnPostingResponse = dc.GetPostings();
            ViewBag.PostingId = new SelectList(returnPostingResponse, "Id", "PostingName", returnResponse.entity.PostingId);
            ViewBag.ParentId = new SelectList(returnPostingResponse, "Id", "PostingName", returnResponse.entity.ParentId);
            List<DesignationVM> returnDesignation = dc.GetDesignations();
            ViewBag.DesignationID = new SelectList(returnDesignation, "Id", "DesignationName", returnResponse.entity.DesignationID);
            return View(returnResponse.entity);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrganogramVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(OrganogramController.Index), "Category");
                    }
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.Update(entity);
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

        // GET: Category/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _OrganogramService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() == "Success")
            {
                (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.Delete(id);
                if (returnResponse.executionState.ToString() == "Success")
                {
                    returnResponse.message = "Organogram deleted successfully.";
                }
                return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OrganogramVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(OrganogramController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, OrganogramVM entity, string message) returnResponse = _OrganogramService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetParentOfficeByOfficeTypeId(int id)
        {
            (ExecutionState executionState, List<OrganogramVM> entity, string message) organogramlist = _OrganogramService.List();
            if (organogramlist.entity != null)
            {
                // FIX: coa.PostingTypeId == id &&
                var parentOfficeList = organogramlist.entity.Where(coa => coa.IsDeleted == false && (int)coa.OrganogramOfficeType == id && coa.IsParent == true).ToList().Select(pour => new
                {
                    Id = pour.Id,
                    ParentID = pour.ParentId,
                    Name = pour.Name
                }
                ).ToList().OrderBy(x => x.Name);

                var parentOfficeListJson = JsonConvert.SerializeObject(parentOfficeList);
                return Json(parentOfficeListJson, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonConvert.SerializeObject(null), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetEmployeeByPostDesignation(OrganogramOfficeType officeType, long postingId, long designationId, bool? isPermanent)
        {
            var organogramList = _OrganogramService.GetEmployeeByPostDesignation(officeType, postingId, designationId, isPermanent);

            return Json(organogramList.entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrganogramByPostDesignation(OrganogramOfficeType officeType, long postingId, long designationId, bool? isPermanent)
        {
			var result = _OrganogramService.GetOrganogramByPostDesignation(officeType, postingId, designationId, isPermanent);

            return Json(result.entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsOrganogramPostAvailable(OrganogramOfficeType officeType, long postingId, long designationId, bool? isPermanent)
        {
			var result = _OrganogramService.IsOrganogramPostAvailable(officeType, postingId, designationId, isPermanent);

            return Json(result.entity, JsonRequestBehavior.AllowGet);
        }
    }
}