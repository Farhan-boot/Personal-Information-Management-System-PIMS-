using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Agreement;
using PTSL.DgFood.Api.Helpers;
//using PTSL.DgFood.Api.Helpers;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface;

namespace PTSL.DgFood.Api.Controllers.SystemUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<IUserService, UserVM, User>
    {
        private readonly IUserService _userService;
        private IConfiguration _config;
        private IEmployeeInformationService _employeeInformationService;
        public AccountController(IUserService userService, IConfiguration config, IEmployeeInformationService employeeInformationService) :
            base(userService)
        {
            _config = config;
            _userService = userService;
			_employeeInformationService = employeeInformationService;

		}

        //Implement here new api, if we want.

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<LoginResultVM>>> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, UserVM entity, string message) result = await _userService.UserLogin(model);

            (ExecutionState executionState, LoginResultVM entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                LoginResultVM loginResult = new LoginResultVM
                {
                    UserId = result.entity.Id,
                    UserEmail = result.entity.UserEmail,
                    UserName = result.entity.UserName,
                    RoleName = result.entity.RoleName,
                    Token = GenerateJSONWebToken.GetToken(result.entity, _config),
					EmployeeInformationId = result.entity.EmployeeInformationId
				};
                //HttpContext.Session.SetString("UserId", loginResult.UserId.ToString());
                responseResult.entity = loginResult;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<LoginResultVM> apiResponse = new WebApiResponse<LoginResultVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<LoginResultVM> apiResponse = new WebApiResponse<LoginResultVM>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("UserLists")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<UserDropdownVM>>> UserLists()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<UserVM> entity, string message) result = await _userService.List();

            (ExecutionState executionState, List<UserDropdownVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                List<UserDropdownVM> users = new List<UserDropdownVM>(); 
                foreach (var data in result.entity)
                {
                    UserDropdownVM userDropdownVM = new UserDropdownVM();
                    userDropdownVM.Id = data.Id;
                    userDropdownVM.UserEmail = data.UserEmail;
                    userDropdownVM.UserName = data.UserName;
                    users.Add(userDropdownVM);

                }
                responseResult.entity = users;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<UserDropdownVM>> apiResponse = new WebApiResponse<List<UserDropdownVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<UserDropdownVM>> apiResponse = new WebApiResponse<List<UserDropdownVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("EmployeeUserLists")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<UserVM>>>> EmployeeUserLists()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<UserVM> entity, string message) result = await _userService.EmployeeUserLists();

            (ExecutionState executionState, IList<UserVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                var apiResponse = new WebApiResponse<IList<UserVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                var apiResponse = new WebApiResponse<IList<UserVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

		[HttpGet("EmployeeInformation/{employeeInformationId}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiResponse<UserVM>>> GetUserByEmployeeInformationId(long employeeInformationId)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

			(ExecutionState executionState, UserVM entity, string message) result = await _userService.GetByEmployeeInformationId(employeeInformationId);

			(ExecutionState executionState, UserVM entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<UserVM> apiResponse = new WebApiResponse<UserVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<UserVM> apiResponse = new WebApiResponse<UserVM>(responseResult);
                return NotFound(apiResponse);
            }
        }


		[HttpPost("CountByEmail")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiResponse<long>>> CountByEmail(LoginVM user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			(ExecutionState executionState, long entity, string message) result = await _userService.CountByEmail(user.UserEmail);

			(ExecutionState executionState, long entity, string message) responseResult;

			if (result.executionState == ExecutionState.Success)
			{
				responseResult.entity = result.entity;
				responseResult.message = result.message;
				responseResult.executionState = result.executionState;
				WebApiResponse<long> apiResponse = new WebApiResponse<long>(responseResult);
				return Ok(apiResponse);
			}
			else
			{
				responseResult.entity = 0;
				responseResult.message = result.message;
				responseResult.executionState = result.executionState;

				WebApiResponse<long> apiResponse = new WebApiResponse<long>(responseResult);
				return NotFound(apiResponse);
			}
		}

	}
}
