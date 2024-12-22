using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingInformationManagementController : BaseController<ITrainingInformationManagementService, TrainingInformationManagementVM, TrainingInformationManagement>
    {
        private readonly ITrainingInformationManagementService _TrainingInformationManagementService;
        public TrainingInformationManagementController(ITrainingInformationManagementService TrainingInformationManagementervice) :
            base(TrainingInformationManagementervice)
        {
            _TrainingInformationManagementService = TrainingInformationManagementervice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingInformationManagementVM>>> GetFilterData(TrainingInformationManagementFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message) result = await _TrainingInformationManagementService.GetFilterData(null, model);

            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<TrainingInformationManagementVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetByTrainingInformationManagementMasterId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingInformationManagementVM>>> GetByTrainingInformationManagementMasterId(long? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message) result = await _TrainingInformationManagementService.GetByTrainingInformationManagementMasterId(id);

            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<TrainingInformationManagementVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

    }
}
