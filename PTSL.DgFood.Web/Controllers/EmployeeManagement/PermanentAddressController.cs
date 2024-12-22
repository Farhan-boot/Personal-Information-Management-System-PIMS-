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
    public class PermanentAddressController : Controller
    {
        private readonly IPermanentAddressService _PermanentAddressService;
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IEnglishAndBanglaValidation _EnglishAndBanglaValidation;
        public readonly IModelStateValidation _ModelStateValidation;
        //public PermanentAddressController(): this(new PermanentAddressService())
        //{
        //}
        public PermanentAddressController()
        {
            _DivisionService = new DivisionService();
            _DistrictService = new DistrictService();
            _PermanentAddressService = new PermanentAddressService();
            _EnglishAndBanglaValidation = new EnglishAndBanglaValidation();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: PermanentAddress

        public ActionResult GetFilterData(long EmployeeInformationId)
        {
            PermanentAddressFilterVM entity = new PermanentAddressFilterVM();
            entity.EmployeeInformationId = EmployeeInformationId;
            (ExecutionState executionState, IList<PermanentAddressListVM> entity, string message) returnResponse = _PermanentAddressService.GetFilterData(entity);

            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse = _PermanentAddressService.GetById(id);
            //returnResponse.entity.DateOfBirth = Convert.ToDateTime(returnResponse.entity.DateOfBirth);
            return Json(returnResponse.entity, JsonRequestBehavior.AllowGet);
        }

        public (bool success, string Message) ValidateBanglaAndEnglishField(PermanentAddressVM entity)
        {

            (bool success, string Message) returnResponse;

            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.PostOfficeInBangla, 2);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Post Office Bangla is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.PostOfficeInEnglish, 1);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Post Office English is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.VillageHouseNoAndRoadInBangla, 2);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Address Name Bangla is Invalid !";
                return returnResponse;
            }
            returnResponse = _EnglishAndBanglaValidation.ValidateBanglaAndEnglishField(entity.VillageHouseNoAndRoadInEnglish, 1);
            if (returnResponse.success == false)
            {
                returnResponse.Message = "Address Name English is Invalid !";
                return returnResponse;
            }


            //returnResponse = _EnglishAndBanglaValidation.ValidateListOfBanglaAndEnglishField(data);
            return returnResponse;
        }

        // POST: PermanentAddress/Create
        [HttpPost]
       
        public ActionResult Create(EmployeeViewModel entityVM)
        {
            try
            {
                PermanentAddressVM entity = entityVM.PermanentAddressVM;
                Session["PermanentAddressData"] = entity;
                Session["executionState"] = 0;
                if (ModelState.IsValid)
                {
                    (bool success, string Message) isFormValid = ValidateBanglaAndEnglishField(entity);
                    if (isFormValid.success == false)
                    {
                        Session["Message"] = isFormValid.Message;
                        return RedirectToAction("Edit", "EmployeeInformation", new { id = entity.EmployeeInformationId });
                    }
                    if (entityVM.PermanentAddressVM.Id == 0)
                    {
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.Now;
                        // TODO: Add insert logic here
                        (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse = _PermanentAddressService.Create(entity);
                        Session["Message"] = returnResponse.message;
                        Session["executionState"] = returnResponse.executionState;
                        if (returnResponse.executionState.ToString() == "Created")
                        {
                            Session["PermanentAddressData"] = returnResponse.entity;
                        }
                    }
                    else
                    {

                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.UpdatedAt = DateTime.Now;
                        (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse = _PermanentAddressService.Update(entity);
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
                return RedirectToAction("Edit", "EmployeeInformation", new { id = entityVM.PermanentAddressVM.EmployeeInformationId });
            }
        }

        public ActionResult GetDistrictByDivisionId(long divisionId)
        {
            
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnDistrictResponse = _DistrictService.List();
            var result = returnDistrictResponse.entity.Where(x=>x.DivisionId == divisionId).Select(y=> new { Id= y.Id, DistrictName = y.DistrictName});

            return Json(result, JsonRequestBehavior.AllowGet);
        }
         
        // GET: PermanentAddress/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse = _PermanentAddressService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "PermanentAddress deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: PermanentAddress/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PermanentAddressVM entity)
        {
            try
            {
                // TODO: Add update logic here
                //if (id != entity.Id)
                //{
                //    return RedirectToAction(nameof(PermanentAddressController.Index), "PermanentAddress");
                //}
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse = _PermanentAddressService.Update(entity);
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