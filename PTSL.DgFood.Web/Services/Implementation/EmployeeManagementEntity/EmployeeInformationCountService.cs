using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation
{
    public class EmployeeInformationCountService : IEmployeeInformationCountService
    {
        public (ExecutionState executionState, List<EmployeeInformationCountVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EmployeeInformationCountVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCountList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationCountVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationCountVM>>>(json);
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
        public (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Create(EmployeeInformationCountVM model)
        {
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCount));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<EmployeeInformationCountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationCountVM>>(json);
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
        public (ExecutionState executionState, EmployeeInformationCountVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse;
            try
            {
                EmployeeInformationCountVM model = new EmployeeInformationCountVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCount + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeInformationCountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationCountVM>>(json);
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
                EmployeeInformationCountVM model = new EmployeeInformationCountVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCountDoesExist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeInformationCountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationCountVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Update(EmployeeInformationCountVM model)
        {
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCount));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<EmployeeInformationCountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationCountVM>>(json);
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
        public (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EmployeeInformationCountVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeeInformationCountVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationCount));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<EmployeeInformationCountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationCountVM>>(json);
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