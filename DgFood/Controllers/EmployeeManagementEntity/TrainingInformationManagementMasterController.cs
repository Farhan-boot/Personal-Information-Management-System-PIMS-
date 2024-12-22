using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
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
    public class TrainingInformationManagementMasterController : BaseController<ITrainingInformationManagementMasterService, TrainingInformationManagementMasterVM, TrainingInformationManagementMaster>
    {
        private readonly ITrainingInformationManagementMasterService _TrainingInformationManagementMasterService;
        public TrainingInformationManagementMasterController(ITrainingInformationManagementMasterService TrainingInformationManagementMasterervice) :
            base(TrainingInformationManagementMasterervice)
        {
            _TrainingInformationManagementMasterService = TrainingInformationManagementMasterervice;
        }

        [HttpGet("GetTrainingInformationByTrainingManagementTypeId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingInformationManagementMasterVM>>> GetTrainingInformationByTrainingManagementTypeId(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //TrainingInformationManagementMasterVM filterData = new TrainingInformationManagementMasterVM();
            QueryOptions<TrainingInformationManagementMasterVM> filterData = new QueryOptions<TrainingInformationManagementMasterVM>();
            filterData.FilterExpression = x => x.TrainingManagementTypeId == (long)id;

            (ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message) result = await _TrainingInformationManagementMasterService.GetTrainingInformationByTrainingManagementTypeId(id);

            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("TrainingBulkUpload")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingInformationManagementMasterVM>>> BulkUploadTraining(List<TrainingInformationManagementMasterVM> trainingInformationManagements = null)
        {
            if (!ModelState.IsValid || trainingInformationManagements == null)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message) result = await _TrainingInformationManagementMasterService.BulkUploadTraining(trainingInformationManagements);

            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetByIdWithTrainingManagementAndType/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<TrainingInformationManagementMasterVM>>> GetByIdWithTrainingManagementAndType([FromRoute] long id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) result = await _TrainingInformationManagementMasterService.GetByIdWithTrainingManagementAndType(id);

            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<TrainingInformationManagementMasterVM> apiResponse = new WebApiResponse<TrainingInformationManagementMasterVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<TrainingInformationManagementMasterVM> apiResponse = new WebApiResponse<TrainingInformationManagementMasterVM>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("GetCompletedByFromToDate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<TrainingInformationManagementMasterVM>>>> GetCompletedByFromToDate([FromBody] GetTrainingFilterDataByDateVM filter)
        {
            if (filter == null)
            {
                return BadRequest();
            }

            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) result = await _TrainingInformationManagementMasterService.GetCompletedByFromToDate(filter);

            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<TrainingInformationManagementMasterVM>> apiResponse = new WebApiResponse<List<TrainingInformationManagementMasterVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
