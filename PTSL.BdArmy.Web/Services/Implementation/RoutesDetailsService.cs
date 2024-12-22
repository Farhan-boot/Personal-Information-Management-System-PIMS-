using Newtonsoft.Json;
using PTSL.BdArmy.Common.Entity.BdArmy;
using PTSL.BdArmy.Web.Helper;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using PTSL.BdArmy.Web.Services.Interface;
using PTSL.BdArmy.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.BdArmy.Web.Services.Implementation.GeneralSetup
{
    public class RoutesDetailsService : IRoutesDetailsService
    {
        public (ExecutionState executionState, List<RoutesDetailsVM> entity, string message) List()
        {
            (ExecutionState executionState, List<RoutesDetailsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesDetailsList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<RoutesDetailsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<RoutesDetailsVM>>>(json);
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
        public (ExecutionState executionState, RoutesDetailsVM entity, string message) Create(RoutesDetailsVM model)
        {
            (ExecutionState executionState, RoutesDetailsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesDetails));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<RoutesDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesDetailsVM>>(json);
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
        public (ExecutionState executionState, RoutesDetailsVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, RoutesDetailsVM entity, string message) returnResponse;
            try
            {
                RoutesDetailsVM model = new RoutesDetailsVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesDetails + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<RoutesDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesDetailsVM>>(json);
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
        public (ExecutionState executionState, RoutesDetailsVM entity, string message) Update(RoutesDetailsVM model)
        {
            (ExecutionState executionState, RoutesDetailsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesDetails));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<RoutesDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesDetailsVM>>(json);
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
        public (ExecutionState executionState, RoutesDetailsVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, RoutesDetailsVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, RoutesDetailsVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesDetails));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<RoutesDetailsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesDetailsVM>>(json);
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