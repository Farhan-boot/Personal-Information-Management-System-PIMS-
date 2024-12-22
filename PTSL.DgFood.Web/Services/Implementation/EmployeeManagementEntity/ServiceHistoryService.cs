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
    public class ServiceHistoryService : IServiceHistoryService
    {
        public (ExecutionState executionState, List<ServiceHistoryVM> entity, string message) List()
        {
            (ExecutionState executionState, List<ServiceHistoryVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistoryList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<ServiceHistoryVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ServiceHistoryVM>>>(json);
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
        public (ExecutionState executionState, ServiceHistoryVM entity, string message) Create(ServiceHistoryVM model)
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistory));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<ServiceHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ServiceHistoryVM>>(json);
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
        public (ExecutionState executionState, ServiceHistoryVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse;
            try
            {
                ServiceHistoryVM model = new ServiceHistoryVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistory + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<ServiceHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ServiceHistoryVM>>(json);
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
        public (ExecutionState executionState, ServiceHistoryVM entity, string message) Update(ServiceHistoryVM model)
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistory));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<ServiceHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ServiceHistoryVM>>(json);
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
        public (ExecutionState executionState, ServiceHistoryVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, ServiceHistoryVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, ServiceHistoryVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistory));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<ServiceHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ServiceHistoryVM>>(json);
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


        public (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) GetFilterData(ServiceHistoryFilterVM model)
        {
            (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ServiceHistoryGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<ServiceHistoryListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ServiceHistoryListVM>>>(json);
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