using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity
{
    public class LeaveApplicationService : ILeaveApplicationService
    {
        public (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplicationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<LeaveApplicationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LeaveApplicationVM>>>(json);
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
        public (ExecutionState executionState, LeaveApplicationVM entity, string message) Create(LeaveApplicationVM model)
        {
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplication));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<LeaveApplicationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveApplicationVM>>(json);
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
        public (ExecutionState executionState, LeaveApplicationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse;
            try
            {
                LeaveApplicationVM model = new LeaveApplicationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplication + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<LeaveApplicationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveApplicationVM>>(json);
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
        public (ExecutionState executionState, LeaveApplicationVM entity, string message) Update(LeaveApplicationVM model)
        {
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplication));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<LeaveApplicationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveApplicationVM>>(json);
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
        public (ExecutionState executionState, LeaveApplicationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, LeaveApplicationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, LeaveApplicationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplication));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<LeaveApplicationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LeaveApplicationVM>>(json);
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

         
        public (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) GetFilterData(LeaveApplicationVM model)
        {
            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplicationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<LeaveApplicationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LeaveApplicationVM>>>(json);
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
        public (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) GetByEmployeeId(LeaveApplicationVM model)
        {
            (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LeaveApplicationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<LeaveApplicationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LeaveApplicationVM>>>(json);
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
         
    }
}