using Newtonsoft.Json;
using PTSL.BdArmy.Web.Helper;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using PTSL.BdArmy.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.BdArmy.Web.Services.Implementation.GeneralSetup
{
    public class AccesslistService : IAccesslistService
    {
        public (ExecutionState executionState, List<AccesslistVM> entity, string message) List()
        {
            (ExecutionState executionState, List<AccesslistVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccesslistList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<AccesslistVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<AccesslistVM>>>(json);
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
        public (ExecutionState executionState, AccesslistVM entity, string message) Create(AccesslistVM model)
        {
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Accesslist));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<AccesslistVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccesslistVM>>(json);
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
        public (ExecutionState executionState, AccesslistVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse;
            try
            {
                AccesslistVM model = new AccesslistVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Accesslist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<AccesslistVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccesslistVM>>(json);
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
        public (ExecutionState executionState, AccesslistVM entity, string message) Update(AccesslistVM model)
        {
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Accesslist));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<AccesslistVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccesslistVM>>(json);
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
        public (ExecutionState executionState, AccesslistVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, AccesslistVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, AccesslistVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Accesslist));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<AccesslistVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccesslistVM>>(json);
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