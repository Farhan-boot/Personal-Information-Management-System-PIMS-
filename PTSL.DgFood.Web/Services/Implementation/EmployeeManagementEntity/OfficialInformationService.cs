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
    public class OfficialInformationService : IOfficialInformationService
    {
        public (ExecutionState executionState, List<OfficialInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OfficialInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<OfficialInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OfficialInformationVM>>>(json);
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
        public (ExecutionState executionState, OfficialInformationVM entity, string message) Create(OfficialInformationVM model)
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<OfficialInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OfficialInformationVM>>(json);
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
        public (ExecutionState executionState, OfficialInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse;
            try
            {
                OfficialInformationVM model = new OfficialInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<OfficialInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OfficialInformationVM>>(json);
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
        public (ExecutionState executionState, OfficialInformationVM entity, string message) Update(OfficialInformationVM model)
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<OfficialInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OfficialInformationVM>>(json);
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
        public (ExecutionState executionState, OfficialInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OfficialInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OfficialInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<OfficialInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OfficialInformationVM>>(json);
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


        public (ExecutionState executionState, List<OfficialInformationVM> entity, string message) GetFilterData(OfficialInformationFilterVM model)
        {
            (ExecutionState executionState, List<OfficialInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OfficialInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<OfficialInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OfficialInformationVM>>>(json);
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