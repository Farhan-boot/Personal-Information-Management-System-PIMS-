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
    public class SpouseInformationService : ISpouseInformationService
    {
        public (ExecutionState executionState, List<SpouseInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SpouseInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<SpouseInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SpouseInformationVM>>>(json);
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
        public (ExecutionState executionState, SpouseInformationVM entity, string message) Create(SpouseInformationVM model)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<SpouseInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpouseInformationVM>>(json);
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
        public (ExecutionState executionState, SpouseInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse;
            try
            {
                SpouseInformationVM model = new SpouseInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<SpouseInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpouseInformationVM>>(json);
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
        public (ExecutionState executionState, SpouseInformationVM entity, string message) Update(SpouseInformationVM model)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<SpouseInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpouseInformationVM>>(json);
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
        public (ExecutionState executionState, SpouseInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SpouseInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SpouseInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<SpouseInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpouseInformationVM>>(json);
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


        public (ExecutionState executionState, List<SpouseInformationListVM> entity, string message) GetFilterData(SpouseInformationFilterVM model)
        {
            (ExecutionState executionState, List<SpouseInformationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpouseInformationGetFilterData), respJson, "application/json");
                //var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<SpouseInformationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SpouseInformationListVM>>>(json);
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