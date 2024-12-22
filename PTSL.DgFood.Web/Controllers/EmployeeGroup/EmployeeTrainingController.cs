using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeGroup
{
	// Only for Employee Group

	[SessionAuthorize]
	public class EmployeeTrainingController : Controller
	{
		public readonly ITrainingInformationManagementMasterService _TrainingInformationManagementMasterService;
		private readonly ITrainingManagementTypeService _TrainingManagementTypeService;
		public readonly IModelStateValidation _ModelStateValidation;

		public EmployeeTrainingController()
		{
			_ModelStateValidation = new ModelStateValidation();
			_TrainingManagementTypeService = new TrainingManagementTypeService();
			_TrainingInformationManagementMasterService = new TrainingInformationManagementMasterService();
		}

		public ActionResult Index()
		{
			(ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) returnResponse = _TrainingManagementTypeService.List();

			return View(returnResponse.entity);
		}

		public ActionResult Apply(long employeeId, long trainingManagementTypeId)
		{
			try
			{
				TrainingInformationManagementMasterVM entity = new TrainingInformationManagementMasterVM();

				entity.EmployeeInformationIds = new long[] { employeeId };
				entity.TrainingManagementTypeId = trainingManagementTypeId;
				entity.IsActive = true;
				entity.CreatedAt = DateTime.Now;
				entity.Status = false;
				entity.TrainingInformationManagementLists = new List<TrainingInformationManagementVM>();

				
                //(ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
                //return Json(new { Success = true, Message = "Successfully saved data." });

                if (ModelState.IsValid)
				{
					AddTrainingManagement(entity);

					// TODO: Add insert logic here
					//TrainingInformationManagementMasterVM training = new TrainingInformationManagementMasterVM();
					//training.TrainingManagementTypeId = entity.TrainingManagementTypeId;
					(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnExistingResponse = _TrainingInformationManagementMasterService.GetTrainingInformationByTrainingManagementTypeId(entity.TrainingManagementTypeId);

					if (returnExistingResponse.entity != null)
					{
						entity.Id = returnExistingResponse.entity.FirstOrDefault().Id;

						var alreadyApplied = returnExistingResponse.entity.Any(x => x.TrainingInformationManagementLists
							.Any(
								y => y.EmployeeInformationId == entity.EmployeeInformationIds[0] 
								&& y.ApprovalStatus == TrainingInformationManagementApprovalStatus.EmployeeRequested
							));

						if (alreadyApplied)
						{
							return Json(new { Message = "Item saved Successfully.", executionState = ExecutionState.Updated }, JsonRequestBehavior.AllowGet);
						}

						(ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Update(entity);
						Session["Message"] = "Data Saved Successfully !";
						Session["executionState"] = returnResponse.executionState;
						if (returnResponse.executionState != ExecutionState.Updated)
						{
							return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
						}
						else
						{
							return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
						}
					}
					else
					{
						(ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse = _TrainingInformationManagementMasterService.Create(entity);
						Session["Message"] = "Data Saved Successfully !";
						Session["executionState"] = returnResponse.executionState;
						if (returnResponse.executionState.ToString() != "Created")
						{
							return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
						}
						else
						{
							return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
						}
					}
				}
				else
				{
					Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
				}
				return Json(new { Message = "Failed to save data.", executionState = ExecutionState.Failure });
			}
			catch (Exception ex)
			{
				return Json(new { Message = "Failed to save data.", executionState = ExecutionState.Failure });
			}

		}

		private void AddTrainingManagement(TrainingInformationManagementMasterVM entity)
		{
			foreach (var emp in entity.EmployeeInformationIds)
			{
				TrainingInformationManagementVM trainingInformationManagement = new TrainingInformationManagementVM();
				trainingInformationManagement.TrainingInformationManagementMasterId = 0;
				trainingInformationManagement.EmployeeInformationId = emp;
				trainingInformationManagement.IsActive = true;
				trainingInformationManagement.CreatedAt = DateTime.Now;
				trainingInformationManagement.Status = false;
				trainingInformationManagement.ApprovalStatus = TrainingInformationManagementApprovalStatus.EmployeeRequested;
				entity.TrainingInformationManagementLists.Add(trainingInformationManagement);
			}
		}
	}
}
