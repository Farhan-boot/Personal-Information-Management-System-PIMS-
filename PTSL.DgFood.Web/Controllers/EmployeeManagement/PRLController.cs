using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class PRLController : Controller
    {
        public readonly IModelStateValidation _ModelStateValidation;
        public readonly IPRLService _prlservice;

        public PRLController()
        {
            _ModelStateValidation = new ModelStateValidation();
            _prlservice = new PRLService();
        }

        // GET: PRL
        public async Task<ActionResult> Index()
        {
            (ExecutionState executionState, IList<OfficialInformationVM> entity, string message) returnResponse = await _prlservice.List();
            ViewBag.PRLEmails = new SelectList(returnResponse.entity.Select(x => x.EmployeeInformationDTO), "EmployeeInformationId", "Email");
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Create(int[] selectedIds, string subject, string messagebody, string noticeType)
        {
            long LoggedInUser = MySession.Current.UserId;  

            var models =new List<PRL_VM>();
            try
            {
                if (ModelState.IsValid)
                {
                    if(selectedIds == null)
                    {
                        Session["Message"] = "'Select all' Checkbox";
                        Session["executionState"] = ExecutionState.Failure;
                        return Json(new { SessionMessage = Session["Message"] });

                    }
                    foreach (var id in selectedIds)
                    {
                        models.Add(
                            new PRL_VM()
                            {
                                CreatedBy = LoggedInUser,
                                EmployeeInformationId = id,
                                MessageBody = messagebody,
                                MessageSubject = subject,
                                IsEmail = noticeType == "E-Mail" ? true : false,
                                IsSMS = noticeType == "SMS" ? true : false,
                                NoticeDate = DateTime.Now.Date,
                                NoticeBy = LoggedInUser,
                                IsActive = true,
                                CreatedAt = DateTime.Now,
                            });
                    }

                    (ExecutionState executionState, IList<PRL_VM> entity, string message) returnResponse = _prlservice.Create(models);

                    if (returnResponse.executionState == ExecutionState.Success)
                    {
                        Session["Message"] = noticeType == "SMS" ? "PRL notice send successfully by SMS" : "PRL notice send successfully by E-mail";
                        Session["PRLData"] = returnResponse.entity;
                        return Json(new { SessionMessage = Session["Message"] });
                    }
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    return RedirectToAction("Index", "PRL");
                }

                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return RedirectToAction("Index","PRL");
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return RedirectToAction("Index", "PRL");
            }
        }
    }
}