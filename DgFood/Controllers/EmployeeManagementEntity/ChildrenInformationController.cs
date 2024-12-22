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
    public class ChildrenInformationController : BaseController<IChildrenInformationService, ChildrenInformationVM, ChildrenInformation>
    {
        private readonly IChildrenInformationService _ChildrenInformationService;
        public ChildrenInformationController(IChildrenInformationService ChildrenInformationervice) :
            base(ChildrenInformationervice)
        {
            _ChildrenInformationService = ChildrenInformationervice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ChildrenInformationListVM>>> GetFilterData(ChildrenInformationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) result = await _ChildrenInformationService.GetFilterData(null, model);

            (ExecutionState executionState, List<ChildrenInformationListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<ChildrenInformationListVM>> apiResponse = new WebApiResponse<List<ChildrenInformationListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<ChildrenInformationListVM>> apiResponse = new WebApiResponse<List<ChildrenInformationListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
