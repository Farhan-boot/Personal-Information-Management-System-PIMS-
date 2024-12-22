using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInformationController : BaseController<IEmployeeInformationService, EmployeeInformationVM, EmployeeInformation>
    {
        private readonly IEmployeeInformationService _EmployeeInformationService;
        string ConnectionString = "";
        public EmployeeInformationController(IEmployeeInformationService EmployeeInformationervice) :
            base(EmployeeInformationervice)
        {
            _EmployeeInformationService = EmployeeInformationervice;
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            ConnectionString = root.GetConnectionString("PrimeDgFoodDatabaseConnection");
        }

        //Implement here new api, if we want.
 

        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> GetFilterData(EmployeeInformationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) result = await _EmployeeInformationService.GetFilterData(null, model);

            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetEmployeeList")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> GetEmployeeList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) result = await _EmployeeInformationService.GetEmployeeList(null);
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) result = await _EmployeeInformationService.GetEmployeeList(null);

            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("EmployeeList")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationListVM>>> EmployeeList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            EmployeeInformationFilterVM model = new EmployeeInformationFilterVM();
            (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) result = await _EmployeeInformationService.EmployeeListBySP(null,model, ConnectionString); 

            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationListVM>> apiResponse = new WebApiResponse<List<EmployeeInformationListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationListVM>> apiResponse = new WebApiResponse<List<EmployeeInformationListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("GetEmployeeByEmail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> GetEmployeeByEmail([FromBody] EmployeeInformationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) result = await _EmployeeInformationService.GetEmployeeByEmail(null, model);

            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("EmployeeListBySP")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationListVM>>> EmployeeListBySP([FromBody] EmployeeInformationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }  
            (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) result = await _EmployeeInformationService.EmployeeListBySP(null, model,ConnectionString);

            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationListVM>> apiResponse = new WebApiResponse<List<EmployeeInformationListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationListVM>> apiResponse = new WebApiResponse<List<EmployeeInformationListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }


        [HttpPost("GetEmployeeByEmailWithAllIncluding")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> GetEmployeeByEmailWithAllIncluding([FromBody] EmployeeInformationFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) result = await _EmployeeInformationService.GetEmployeeByEmailWithAllIncluding(null, model);

            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<EmployeeInformationVM>> apiResponse = new WebApiResponse<List<EmployeeInformationVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetEmployeeFullInfoById/{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> GetEmployeeFullInfoById(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            (ExecutionState executionState, EmployeeInformationVM entity, string message) result = await _EmployeeInformationService.GetEmployeeFullInfoById(id);

            WebApiResponse<EmployeeInformationVM> apiResponse = new WebApiResponse<EmployeeInformationVM>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }

        [HttpGet("GetEmployeeBasicInfoByEmployeeCode/{EmployeeCode}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EmployeeInformationListVM>>> GetEmployeeBasicInfoByEmployeeCode(string EmployeeCode)
        {
            if (EmployeeCode == "" || EmployeeCode == null)
            {
                return BadRequest();
            }
            EmployeeInformationFilterVM entity = new EmployeeInformationFilterVM();
            entity.EmployeeCode = EmployeeCode;
            (ExecutionState executionState, EmployeeInformationListVM entity, string message) resultResponse;
            //(ExecutionState executionState, EmployeeInformationListVM entity, string message) result = await _EmployeeInformationService.GetEmployeeBasicInfoByEmployeeCode(EmployeeCode);
            (ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message) result = await _EmployeeInformationService.EmployeeListBySP(null,entity, ConnectionString);
            var data = result.entity.FirstOrDefault();
            resultResponse.entity = data;
            resultResponse.message = result.message;
            resultResponse.executionState = result.executionState;
            WebApiResponse<EmployeeInformationListVM> apiResponse = new WebApiResponse<EmployeeInformationListVM>(resultResponse);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }


        //[HttpGet("UpdateExistingEmployeeData")]
        ////[Authorize]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<WebApiResponse<EmployeeInformationVM>>> UpdateExistingEmployeeData()
        //{

        //    (ExecutionState executionState,  string message) result = await _EmployeeInformationService.UpdateExistingEmployeeData();

        //    WebApiResponse<EmployeeInformationVM> apiResponse = new WebApiResponse<EmployeeInformationVM>(result);

        //    if (result.executionState == ExecutionState.Failure)
        //    {
        //        return NotFound(apiResponse);
        //    }
        //    else
        //    {
        //        return Ok(apiResponse);
        //    }
        //}

    }
}
