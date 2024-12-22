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
    public class EmployeeTransferController : BaseController<IEmployeeTransferService, EmployeeTransferVM, EmployeeTransfer>
    {
        private readonly IEmployeeTransferService _EmployeeTransferService;
        public EmployeeTransferController(IEmployeeTransferService EmployeeTransferervice) :
            base(EmployeeTransferervice)
        {
            _EmployeeTransferService = EmployeeTransferervice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeTransferVM>>> GetFilterData(EmployeeTransferFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeTransferVM> entity, string message) result = await _EmployeeTransferService.GetFilterData(null, model);

            (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeTransferVM>> apiResponse = new WebApiResponse<List<EmployeeTransferVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeTransferVM>> apiResponse = new WebApiResponse<List<EmployeeTransferVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
