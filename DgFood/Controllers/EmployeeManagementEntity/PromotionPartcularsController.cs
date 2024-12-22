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
    public class PromotionPartcularsController : BaseController<IPromotionPartcularsService, PromotionPartcularsVM, PromotionPartculars>
    {
        private readonly IPromotionPartcularsService _PromotionPartcularsService;
        public PromotionPartcularsController(IPromotionPartcularsService PromotionPartcularservice) :
            base(PromotionPartcularservice)
        {
            _PromotionPartcularsService = PromotionPartcularservice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<PromotionParticularsListVM>>> GetFilterData(PromotionPartcularsFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<PromotionParticularsListVM> entity, string message) result = await _PromotionPartcularsService.GetFilterData(null, model);

            (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<PromotionParticularsListVM>> apiResponse = new WebApiResponse<List<PromotionParticularsListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<PromotionParticularsListVM>> apiResponse = new WebApiResponse<List<PromotionParticularsListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
