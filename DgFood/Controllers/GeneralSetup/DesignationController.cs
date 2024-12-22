using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
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
    public class DesignationController : BaseController<IDesignationService, DesignationVM, Designation>
    {
        private readonly IDesignationService designationervice;

        public DesignationController(IDesignationService Designationervice) :
            base(Designationervice)
        {
            designationervice=Designationervice;
        }

        [HttpGet("GetByRankAndDesignationClass")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DesignationVM>>> GetByRankAndDesignationClass([FromQuery] long? rankId, long? designationClassId)
        {
            (ExecutionState executionState, IList<DesignationVM> entity, string message) result = await designationervice.GetByRankAndDesignationClass(rankId, designationClassId);

            (ExecutionState executionState, IList<DesignationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<IList<DesignationVM>> apiResponse = new WebApiResponse<IList<DesignationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<DesignationVM>> apiResponse = new WebApiResponse<IList<DesignationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
