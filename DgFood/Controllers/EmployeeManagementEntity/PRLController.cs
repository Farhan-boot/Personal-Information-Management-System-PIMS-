using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.MailSetup;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using System.Threading.Tasks;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Api.Helpers;
using System.Collections.Generic;
using System.Linq;
using PTSL.DgFood.Service.Services.Interface.MailService;

namespace PTSL.DgFood.Api.Controllers.EmployeeManagementEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PRLController : BaseController<IPRLService, PRL_VM, PRL>
    {
        public readonly IPRLService _prlService;
        private readonly IMailService _mailService;
        public PRLController(IPRLService prlService, IMailService mail) : base(prlService)
        {
            _prlService = prlService;
            _mailService = mail;
        }

        [HttpPost("PRLNotice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<PRL_VM>>>> CreateAsync([FromBody]IList<PRL_VM> model)
        {
            (ExecutionState executionState, IList<PRL_VM> entity, string message) returnResponse;
            var list = new List<PRL_VM>();
            string noticeType = model.Select(x => x.IsEmail).FirstOrDefault() == true ? "E-Mail" : "SMS";

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<PRL_VM> entity, string[] prlSendingWay, string message) resultEntity = await _prlService.CreateAsync(model, noticeType);
            returnResponse = (executionState: resultEntity.executionState, entity: resultEntity.entity, message: resultEntity.message);

            if (resultEntity.executionState == ExecutionState.Success)
            {
                if(noticeType == "E-Mail")
                {
                    EmailRequestConfiguration configData = ConfigurationHelper.GetEmailApiConfiguration();
                    EmailApi data = new EmailApi
                    {
                        secretkey = configData.Secretkey,
                        FromMail = configData.FromMail,
                        ToMail = resultEntity.prlSendingWay,
                        Subject = model.Select(x => x.MessageSubject).FirstOrDefault() == null ? configData.Subject : model.Select(x => x.MessageSubject).FirstOrDefault(),
                        Body = model.Select(x => x.MessageBody).FirstOrDefault()
                    };

                    string mailJson = JsonConvert.SerializeObject(data);
                    var emailSend = HttpApiHelper.Post(configData.BaseUrl, mailJson, "application/json");
                }
                else
                {
                    SmsRequestConfiguration smsConfiguration = ConfigurationHelper.GetSmsApiConfiguration();

                    foreach(var number in resultEntity.prlSendingWay)
                    {
                        SmsRequest sms = new SmsRequest
                        {
                            ToContactNumber = number,
                            Message = returnResponse.entity.Select(x => x.MessageBody).FirstOrDefault()
                        };
                        await _mailService.SendMobileAsync(sms, smsConfiguration);
                    }
                }

                returnResponse.entity = resultEntity.entity;
                returnResponse.message = resultEntity.message;
                returnResponse.executionState = resultEntity.executionState;
                WebApiResponse<IList<PRL_VM>> apiResponse = new WebApiResponse<IList<PRL_VM>>(returnResponse);
                return Ok(apiResponse);
            }
            else
            {
                returnResponse.entity = null;
                returnResponse.message = resultEntity.message;
                returnResponse.executionState = resultEntity.executionState;
                WebApiResponse<IList<PRL_VM>> apiResponse = new WebApiResponse<IList<PRL_VM>>(returnResponse);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("PRLList")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PRLList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            (ExecutionState executionState, IList<OfficialInformationVM> prlList, string message) result = await _prlService.PRLList();
            (ExecutionState executionState, IList<OfficialInformationVM> prlList, string message) returnResponse;
            if (result.executionState == ExecutionState.Retrieved)
            {
                returnResponse.prlList = result.prlList;
                returnResponse.message = result.message;
                returnResponse.executionState = result.executionState;
                WebApiResponse<IList<OfficialInformationVM>> apiResponse = new WebApiResponse<IList<OfficialInformationVM>>(result);
                return Ok(apiResponse);
            }
            else
            {
                returnResponse.prlList = null;
                returnResponse.message = result.message;
                returnResponse.executionState = result.executionState;
                WebApiResponse<IList<OfficialInformationVM>> apiResponse = new WebApiResponse<IList<OfficialInformationVM>>(result);
                return NotFound(apiResponse);
            }
        }
    }
}