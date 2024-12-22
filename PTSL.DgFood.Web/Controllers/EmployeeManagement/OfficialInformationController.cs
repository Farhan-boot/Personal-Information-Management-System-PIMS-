using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class OfficialInformationController : Controller
    {
        private readonly IOfficialInformationService _OfficialInformationService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        public readonly IOrganogramService _OrganogramService;
        public readonly IModelStateValidation _ModelStateValidation;

        public OfficialInformationController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _OfficialInformationService = new OfficialInformationService();
            _OrganogramService = new OrganogramService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: OfficialInformation
        public ActionResult Index()
        {
            (ExecutionState executionState, List<OfficialInformationVM> entity, string message) returnResponse = _OfficialInformationService.List();
            return View(returnResponse.entity);
        }

        
        // POST: OfficialInformation/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                OfficialInformationVM entity = entityVM.OfficialInformationVM;
                entity.OrderNumber = entity.OrderNumber ?? string.Empty;

                // Validate if designation is available start
                /*
                var joinOfficeType = entityVM.OfficialInformationVM.JoinOrganogramOfficeType;
                var joinPostingId = entityVM.OfficialInformationVM.JoinPostingId;
                var joiningDesgId = entityVM.OfficialInformationVM.JoiningDesgId;
                var joiningIsPermanent = entityVM.OfficialInformationVM.IsFirstJoiningPostPermanent;

                var joinResult = _OrganogramService.GetOrganogramByPostDesignation(joinOfficeType, joinPostingId, joiningDesgId, joiningIsPermanent);
                if (joinResult.entity != null)
                {
                    if (joinResult.entity.TotalPost <= 0)
                    {
                        Session["Message"] = "Joining does not have any available empty post.";
                        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });
                    }
                }
                else
                {
                    Session["Message"] = "No organogram found for this designation and posting.";
                    return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });
                }

                var presentOrganogramOfficeType = entityVM.OfficialInformationVM.PresentOrganogramOfficeType;
                var presentPostingId = entityVM.OfficialInformationVM.PostingId;
                var presentDesignationId = entityVM.OfficialInformationVM.PresentDesignationId;
                var presentIsPermanent = entityVM.OfficialInformationVM.IsPresentPostingPermanent;

                var presentResult = _OrganogramService.GetOrganogramByPostDesignation(presentOrganogramOfficeType, presentPostingId, presentDesignationId, presentIsPermanent);
                if (presentResult.entity != null)
                {
                    if (presentResult.entity.TotalPost <= 0)
                    {
                        Session["Message"] = "Selected present posting does not have any available empty post.";
                        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });
                    }
                }
                else
                {
                    Session["Message"] = "No organogram found for this designation and posting.";
                    return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });
                }
                */
                // Validate if designation is available end

                Session["OfficialInformationData"] = entity;
                Session["executionState"] = 0;

                //if (ModelState.IsValid)
                //{
                    if (entityVM.OfficialInformationVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse = _OfficialInformationService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["OfficialInformationData"] = returnResponse.entity;
                        }
                    }
                    else
                    {
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse = _OfficialInformationService.Update(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;

                    }
                //}
/*                else
                {
                    var message = ModelState.FirstErrorMessage();
                    Session["Message"] = message;
                }
*/                //return View(entity);
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });

            }
            catch
            {
                //return View(entityVM);
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.OfficialInformationVM.EmployeeInformationId });
            }
        }

       
        // GET: OfficialInformation/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse = _OfficialInformationService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "OfficialInformation deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: OfficialInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OfficialInformationVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(OfficialInformationController.Index), "OfficialInformation");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse = _OfficialInformationService.Update(entity);
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