using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.DgFood.Business.Businesses.Interface;
using System.Threading.Tasks;
using System;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels;

namespace PTSL.DgFood.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class DashboardController : ControllerBase
	{
		private readonly IEmployeeInformationBusiness employeeInformationBusiness;

		public DashboardController(IEmployeeInformationBusiness employeeInformationBusiness)
		{
			this.employeeInformationBusiness = employeeInformationBusiness;
		}

		[HttpGet("GetData")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiResponse<DashboardVM>>> GetData()
		{
			(ExecutionState executionState, DashboardVM entity, string message) responseResult;

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				var dashboard = new DashboardVM();
				var directOrRecruitCount = await employeeInformationBusiness.GetDirectAndPromotionalRecruitmentEmployee();
				var totalEmployee = await employeeInformationBusiness.GetTotalEmployeeOfficeWise();

				dashboard.DirectAndPromotionalEmployee = directOrRecruitCount;
				dashboard.TotalEmployeeOfficeWise = totalEmployee;

				responseResult.entity = dashboard;
				responseResult.executionState = ExecutionState.Success;
				responseResult.message = "Data retrieved successfully";

				var apiResponse = new WebApiResponse<DashboardVM>(responseResult);
				return Ok(apiResponse);
			}
			catch (Exception e)
			{
				responseResult.entity = null;
				responseResult.executionState = ExecutionState.Failure;
				responseResult.message = e.Message;

				var apiResponse = new WebApiResponse<DashboardVM>(responseResult);
				return StatusCode(500, apiResponse);
			}
		}
	}
}

