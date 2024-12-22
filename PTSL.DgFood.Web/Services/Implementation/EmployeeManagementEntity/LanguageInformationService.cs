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
    public class LanguageInformationService : ILanguageInformationService
    {
        public (ExecutionState executionState, List<LanguageInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<LanguageInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<LanguageInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LanguageInformationVM>>>(json);
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
        public (ExecutionState executionState, LanguageInformationVM entity, string message) Create(LanguageInformationVM model)
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<LanguageInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LanguageInformationVM>>(json);
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
        public (ExecutionState executionState, LanguageInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse;
            try
            {
                LanguageInformationVM model = new LanguageInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<LanguageInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LanguageInformationVM>>(json);
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
        public (ExecutionState executionState, LanguageInformationVM entity, string message) Update(LanguageInformationVM model)
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<LanguageInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LanguageInformationVM>>(json);
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
        public (ExecutionState executionState, LanguageInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, LanguageInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, LanguageInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<LanguageInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LanguageInformationVM>>(json);
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

 
        public (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) GetFilterData(LanguageInformationFilterVM model)
        {
            (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LanguageInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<LanguageInfoListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LanguageInfoListVM>>>(json);
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