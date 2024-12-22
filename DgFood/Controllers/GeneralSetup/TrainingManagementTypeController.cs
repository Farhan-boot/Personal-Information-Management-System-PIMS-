using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Api.Helpers;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.MailSetup;
using PTSL.DgFood.Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSL.DgFood.Service.Services.Interface.MailService;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingManagementTypeController : BaseController<ITrainingManagementTypeService, TrainingManagementTypeVM, TrainingManagementType>
    {
        private readonly ITrainingManagementTypeService _trainingManagementTypeService;
		private readonly IMailService _mailService;
		private readonly IEmployeeInformationService _employeeInformationService;

		public TrainingManagementTypeController(ITrainingManagementTypeService trainingManagementTypeService, IMailService mailService, IEmployeeInformationService employeeInformationService) :
            base(trainingManagementTypeService)
        {
            _trainingManagementTypeService = trainingManagementTypeService;
			_mailService = mailService;
			_employeeInformationService = employeeInformationService;
        }

		[HttpPost("SendSms")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiResponse<IList<TrainingSmsVM>>>> SendSms([FromBody] IList<TrainingSmsVM> model)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}


			if (model.Select(x=> x.IsSMS).FirstOrDefault())
			{
				SmsRequestConfiguration smsConfiguration = ConfigurationHelper.GetSmsApiConfiguration();

				var trainingManagementTypeResponse = await _trainingManagementTypeService.GetAsync(model.FirstOrDefault().TrainingManagementTypeId);

				if (trainingManagementTypeResponse.executionState != ExecutionState.Retrieved)
				{
					WebApiResponse<IList<TrainingSmsVM>> apiResponse2 = new WebApiResponse<IList<TrainingSmsVM>>((trainingManagementTypeResponse.executionState, null, "Invalid training type"));
					return Ok(apiResponse2);
				}

				string trainingTitle = trainingManagementTypeResponse.entity.TrainingTitle;
				string messageBody = $"You are selected for a training program. Training Title: {trainingTitle}.";

				foreach (var item in model)
                {
					var empInfoResponse = await _employeeInformationService.GetAsync(item.EmployeeInformationId);
					

					SmsRequest sms = new SmsRequest
					{
						ToContactNumber = empInfoResponse.entity.MobileNumber,
						Message = messageBody
					};
					await _mailService.SendMobileAsync(sms, smsConfiguration);
				}
            }

			WebApiResponse<IList<TrainingSmsVM>> apiResponse = new WebApiResponse<IList<TrainingSmsVM>>((ExecutionState.Success, model, "Successfully sent SMS"));
			
			return Ok(apiResponse);
		}

        [HttpGet("ListLatest/{take}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingManagementTypeVM>>> ListLatest(int take)
        {
            var result = await _trainingManagementTypeService.ListLatest(take);
            (ExecutionState executionState, IList<TrainingManagementTypeVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                var apiResponse = new WebApiResponse<IList<TrainingManagementTypeVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                var apiResponse = new WebApiResponse<IList<TrainingManagementTypeVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
