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
    public class DisciplinaryActionsAndCriminalProsecutionController : BaseController<IDisciplinaryActionsAndCriminalProsecutionService, DisciplinaryActionsAndCriminalProsecutionVM, DisciplinaryActionsAndCriminalProsecution>
    {
        private readonly IDisciplinaryActionsAndCriminalProsecutionService _DisciplinaryActionsAndCriminalProsecutionService;
        public DisciplinaryActionsAndCriminalProsecutionController(IDisciplinaryActionsAndCriminalProsecutionService DisciplinaryActionsAndCriminalProsecutionervice) :
            base(DisciplinaryActionsAndCriminalProsecutionervice)
        {
            _DisciplinaryActionsAndCriminalProsecutionService = DisciplinaryActionsAndCriminalProsecutionervice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DisciplinaryActionsAndCriminalProsecutionListVM>>> GetFilterData(DisciplinaryActionsAndCriminalProsecutionFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) result = await _DisciplinaryActionsAndCriminalProsecutionService.GetFilterData(null, model);

            (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>> apiResponse = new WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>> apiResponse = new WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("GetEmployeeByDisciplinaryActionsFilter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationByDisciplinaryVM>>> GetEmployeeByDisciplinaryActionsFilter(DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeInformationByDisciplinaryVM> entity, string message) result = await _DisciplinaryActionsAndCriminalProsecutionService.GetEmployeeByFilter(model);

            (ExecutionState executionState, List<EmployeeInformationByDisciplinaryVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Success)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationByDisciplinaryVM>> apiResponse = new WebApiResponse<List<EmployeeInformationByDisciplinaryVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationByDisciplinaryVM>> apiResponse = new WebApiResponse<List<EmployeeInformationByDisciplinaryVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
