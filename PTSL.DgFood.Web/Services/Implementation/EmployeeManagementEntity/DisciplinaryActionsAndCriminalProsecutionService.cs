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
    public class DisciplinaryActionsAndCriminalProsecutionService : IDisciplinaryActionsAndCriminalProsecutionService
    {
        public (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionVM> entity, string message) List()
        {
            (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecutionList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionVM>>>(json);
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
        public (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Create(DisciplinaryActionsAndCriminalProsecutionVM model)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecution));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM>>(json);
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
        public (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse;
            try
            {
                DisciplinaryActionsAndCriminalProsecutionVM model = new DisciplinaryActionsAndCriminalProsecutionVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecution + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM>>(json);
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
        public (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Update(DisciplinaryActionsAndCriminalProsecutionVM model)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecution));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM>>(json);
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
        public (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecution));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DisciplinaryActionsAndCriminalProsecutionVM>>(json);
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
        public (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) GetFilterData(DisciplinaryActionsAndCriminalProsecutionFilterVM model)
        {
            (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecutionGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<DisciplinaryActionsAndCriminalProsecutionListVM>>>(json);
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
        public (ExecutionState executionState, List<EmployeeInformationByDisciplinaryVM> entity, string message) GetEmployeeByDisciplinaryActionsFilter(DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM model)
        {
            (ExecutionState executionState, List<EmployeeInformationByDisciplinaryVM> entity, string message) returnResponse;
            try
            {
                var requestJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DisciplinaryActionsAndCriminalProsecutionGetEmployeeByDisciplinaryActionsFilter));
                var json = new HttpHelper().Post(URL, requestJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationByDisciplinaryVM>>>(json);
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