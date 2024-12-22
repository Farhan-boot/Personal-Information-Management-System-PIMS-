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
    public class PostingRecordsController : BaseController<IPostingRecordsService, PostingRecordsVM, PostingRecords>
    {
        private readonly IPostingRecordsService _PostingRecordsService;
        public PostingRecordsController(IPostingRecordsService PostingRecordservice) :
            base(PostingRecordservice)
        {
            _PostingRecordsService = PostingRecordservice;
        }
        //Implement here new api, if we want.
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<PostingRecordsListVM>>> GetFilterData(PostingRecordsFilterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<PostingRecordsListVM> entity, string message) result = await _PostingRecordsService.GetFilterData(null, model);

            (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<PostingRecordsListVM>> apiResponse = new WebApiResponse<List<PostingRecordsListVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<PostingRecordsListVM>> apiResponse = new WebApiResponse<List<PostingRecordsListVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
