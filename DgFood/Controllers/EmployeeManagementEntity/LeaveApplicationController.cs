using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Api.Helpers;
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
    public class LeaveApplicationController : BaseController<ILeaveApplicationService, LeaveApplicationVM, LeaveApplication>
    {
        private readonly ILeaveApplicationService _LeaveApplicationService;
        //private IConfiguration _config;
        
        public LeaveApplicationController(ILeaveApplicationService LeaveApplicationervice) :
            base(LeaveApplicationervice)
        {
           // _config = config;
            _LeaveApplicationService = LeaveApplicationervice;


        }

        //Implement here new api, if we want.

        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<LeaveApplicationVM>>> GetFilterData([FromBody] LeaveApplicationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //QueryOptions<LeaveApplication> queryOptions = null;
            (ExecutionState executionState, IList<LeaveApplicationVM> entity, string message) result = await _LeaveApplicationService.GetFilterData(null, model);

            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<LeaveApplicationVM>> apiResponse = new WebApiResponse<List<LeaveApplicationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<LeaveApplicationVM>> apiResponse = new WebApiResponse<List<LeaveApplicationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

    }
}
