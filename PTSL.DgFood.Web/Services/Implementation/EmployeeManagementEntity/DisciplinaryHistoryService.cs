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
    public class DisciplinaryHistoryService : IDisciplinaryHistoryService
    {
        public (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) returnResponse;
            try
            {
                DisciplinaryHistoryVM model = new DisciplinaryHistoryVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryHistory + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<DisciplinaryHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryHistoryVM>>(json);
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
        public (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) Create(DisciplinaryHistoryVM model)
        {
            (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryHistory));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<DisciplinaryHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryHistoryVM>>(json);
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
        public (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) Update(DisciplinaryHistoryVM model)
        {
            (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryHistory));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<DisciplinaryHistoryVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryHistoryVM>>(json);
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