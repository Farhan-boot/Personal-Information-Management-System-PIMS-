using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.EmployeeManagementEntity
{
    public class EmployeePostingDetailsService : IEmployeePostingDetailsService
    {
        public (ExecutionState executionState, List<EmployeePostingDetailsVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EmployeePostingDetailsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeePostingDetailsList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeePostingDetailsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeePostingDetailsVM>>>(json);
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
        public (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Create(EmployeePostingDetailsVM model)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeePostingDetails));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<EmployeePostingDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeePostingDetailsVM>>(json);
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
        public (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse;
            try
            {
                EmployeePostingDetailsVM model = new EmployeePostingDetailsVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeePostingDetails + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeePostingDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeePostingDetailsVM>>(json);
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
        public (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Update(EmployeePostingDetailsVM model)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeePostingDetails));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<EmployeePostingDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeePostingDetailsVM>>(json);
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
        public (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeePostingDetails));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<EmployeePostingDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeePostingDetailsVM>>(json);
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