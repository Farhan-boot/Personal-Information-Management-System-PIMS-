using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganogramController : BaseController<IOrganogramService, OrganogramVM, Organogram>
    {
        private readonly IOrganogramService _OrganogramService;
		private readonly IOrganogramBusiness business;

		public OrganogramController(IOrganogramService OrganogramService, IOrganogramBusiness business) :
            base(OrganogramService)
        {
            _OrganogramService = OrganogramService;
			this.business = business;
		}

        [HttpGet("ListDetails")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<OrganogramDetailsVM>>> ListDetails()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<OrganogramDetailsVM> entity, string message) result = await _OrganogramService.ListDetails();

            (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<OrganogramDetailsVM>> apiResponse = new WebApiResponse<List<OrganogramDetailsVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<OrganogramDetailsVM>> apiResponse = new WebApiResponse<List<OrganogramDetailsVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPut("CustomDelete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<OrganogramVM>>> CustomDelete([FromBody] OrganogramVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<OrganogramVM> entity, string message) result = await _OrganogramService.CustomDelete(model.Id);

            (ExecutionState executionState, List<OrganogramVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Success)
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<OrganogramVM>> apiResponse = new WebApiResponse<List<OrganogramVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<OrganogramVM>> apiResponse = new WebApiResponse<List<OrganogramVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("OrganogramByPostDesignation")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<OrganogramVM>>> GetOrganogramByPostDesignation([FromQuery] OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

			isPermanent = isPermanent is null ? true : isPermanent;

            (ExecutionState executionState, OrganogramVM entity, string message) result = await _OrganogramService.GetOrganogramByPostDesignation(officeType, postingId, designationId, isPermanent);

            (ExecutionState executionState, OrganogramVM entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<OrganogramVM> apiResponse = new WebApiResponse<OrganogramVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<OrganogramVM> apiResponse = new WebApiResponse<OrganogramVM>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetEmployeeByPostDesignation")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<EmployeeInformationVM>>>> GetEmployeeByPostDesignation([FromQuery] OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeInformationVM> organogramList, string message) result = await _OrganogramService.GetEmployeeByPostDesignation(officeType, postingId, designationId, isPermanent);

            (ExecutionState executionState, IList<EmployeeInformationVM> organogramList, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.organogramList = result.organogramList;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<IList<EmployeeInformationVM>> apiResponse = new WebApiResponse<IList<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.organogramList = new List<EmployeeInformationVM>();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<IList<EmployeeInformationVM>> apiResponse = new WebApiResponse<IList<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
        }

        [HttpGet("IsOrganogramPostAvailable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<bool>>> IsOrganogramPostAvailable([FromQuery] OrganogramOfficeType officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, bool entity, string message) result = await business.IsOrganogramPostAvailable(officeType, postingId, designationId, isPermanent);

            (ExecutionState executionState, bool entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                var apiResponse = new WebApiResponse<bool>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = false;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                var apiResponse = new WebApiResponse<bool>(responseResult);
                return Ok(apiResponse);
            }
        }
    }
}
