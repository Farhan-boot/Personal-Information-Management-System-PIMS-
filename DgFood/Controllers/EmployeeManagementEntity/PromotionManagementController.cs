using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionManagementController : BaseController<IPromotionManagementService, PromotionManagementVM, PromotionManagement>
    {
        private readonly IPromotionManagementService _PromotionManagementService;
        public PromotionManagementController(IPromotionManagementService PromotionManagementservice) : base(PromotionManagementservice)
        {
            _PromotionManagementService = PromotionManagementservice;
        }
        //Implement here new api, if we want.
        //[HttpPost("GetFilterData")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<WebApiResponse<PromotionManagementListVM>>> GetFilterData(PromotionManagementFilterVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    (ExecutionState executionState, IList<PromotionManagementListVM> entity, string message) result = await _PromotionManagementService.GetFilterData(null, model);

        //    (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) responseResult;

        //    if (result.executionState == ExecutionState.Retrieved)
        //    {

        //        responseResult.entity = result.entity.ToList();
        //        responseResult.message = result.message;
        //        responseResult.executionState = result.executionState;
        //        WebApiResponse<List<PromotionManagementListVM>> apiResponse = new WebApiResponse<List<PromotionManagementListVM>>(responseResult);
        //        return Ok(apiResponse);
        //    }
        //    else
        //    {
        //        responseResult.entity = null;
        //        responseResult.message = result.message;
        //        responseResult.executionState = result.executionState;

        //        WebApiResponse<List<PromotionManagementListVM>> apiResponse = new WebApiResponse<List<PromotionManagementListVM>>(responseResult);
        //        return NotFound(apiResponse);
        //    }
        //}

        [HttpGet("PromotionList")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<PromotionManagementListVM>>> PromotionList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<PromotionManagementListVM> entity, string message) result = await _PromotionManagementService.PromotionList(null);

            (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<PromotionManagementListVM>> apiResponse = new WebApiResponse<List<PromotionManagementListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<PromotionManagementListVM>> apiResponse = new WebApiResponse<List<PromotionManagementListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

    }
}
