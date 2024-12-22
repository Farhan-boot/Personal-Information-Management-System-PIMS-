using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.GeneralSetup
{
    public class LeaveTypeInformationService : ILeaveTypeInformationService
    {
        public (ExecutionState executionState, List<LeaveTypeInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<LeaveTypeInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<LeaveTypeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LeaveTypeInformationVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Create(LeaveTypeInformationVM model)
        {
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<LeaveTypeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveTypeInformationVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, LeaveTypeInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse;
            try
            {
                LeaveTypeInformationVM model = new LeaveTypeInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<LeaveTypeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveTypeInformationVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, string message) DoesExist(long? id)
        {
            (ExecutionState executionState, string message) returnResponse;
            try
            {
                DegreeVM model = new DegreeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformationDoesExist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<DegreeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DegreeVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                //returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                //returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Update(LeaveTypeInformationVM model)
        {
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<LeaveTypeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveTypeInformationVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, LeaveTypeInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, LeaveTypeInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveTypeInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<LeaveTypeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveTypeInformationVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This color is not exist.";
                }

            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

       

    }
}