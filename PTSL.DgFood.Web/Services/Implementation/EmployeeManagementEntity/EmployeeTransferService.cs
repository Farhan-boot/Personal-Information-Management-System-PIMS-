using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity
{
    public class EmployeeTransferService : IEmployeeTransferService
    {
        public (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransferList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeTransferVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeTransferVM>>>(json);
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
        public (ExecutionState executionState, EmployeeTransferVM entity, string message) Create(EmployeeTransferVM model)
        {
            (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransfer));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<EmployeeTransferVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeTransferVM>>(json);
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
        public (ExecutionState executionState, EmployeeTransferVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse;
            try
            {
                EmployeeTransferVM model = new EmployeeTransferVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransfer + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeTransferVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeTransferVM>>(json);
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
        public (ExecutionState executionState, EmployeeTransferVM entity, string message) Update(EmployeeTransferVM model)
        {
            (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransfer));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<EmployeeTransferVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeTransferVM>>(json);
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
        public (ExecutionState executionState, EmployeeTransferVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EmployeeTransferVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeeTransferVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransfer));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<EmployeeTransferVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeTransferVM>>(json);
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

        public (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) GetFilterData(EmployeeTransferFilterVM model)
        {
            (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeTransferGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeTransferVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeTransferVM>>>(json);
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