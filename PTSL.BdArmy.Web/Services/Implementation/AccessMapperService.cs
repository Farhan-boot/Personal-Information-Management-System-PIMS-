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
    public class AccessMapperService : IAccessMapperService
    {
        public (ExecutionState executionState, List<AccessMapperVM> entity, string message) List()
        {
            (ExecutionState executionState, List<AccessMapperVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccessMapperList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<AccessMapperVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<AccessMapperVM>>>(json);
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
        public (ExecutionState executionState, AccessMapperVM entity, string message) Create(AccessMapperVM model)
        {
            (ExecutionState executionState, AccessMapperVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccessMapper));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<AccessMapperVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccessMapperVM>>(json);
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
        public (ExecutionState executionState, AccessMapperVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, AccessMapperVM entity, string message) returnResponse;
            try
            {
                AccessMapperVM model = new AccessMapperVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccessMapper + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<AccessMapperVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccessMapperVM>>(json);
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
        public (ExecutionState executionState, AccessMapperVM entity, string message) Update(AccessMapperVM model)
        {
            (ExecutionState executionState, AccessMapperVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccessMapper));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<AccessMapperVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccessMapperVM>>(json);
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
        public (ExecutionState executionState, AccessMapperVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, AccessMapperVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, AccessMapperVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.AccessMapper));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<AccessMapperVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<AccessMapperVM>>(json);
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