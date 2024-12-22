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
    public class RoutesService : IRoutesService
    {
        public (ExecutionState executionState, List<RoutesVM> entity, string message) List()
        {
            (ExecutionState executionState, List<RoutesVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<RoutesVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<RoutesVM>>>(json);
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
        public (ExecutionState executionState, RoutesVM entity, string message) Create(RoutesVM model)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Routes));
                var json = new HttpHelper().Post(URL, respJson,"application/json");
                WebApiResponse<RoutesVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesVM>>(json);
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
        public (ExecutionState executionState, RoutesVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse;
            try
            {
                RoutesVM model = new RoutesVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Routes + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<RoutesVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesVM>>(json);
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
        public (ExecutionState executionState, RoutesVM entity, string message) Update(RoutesVM model)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Routes));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<RoutesVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesVM>>(json);
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
        public (ExecutionState executionState, RoutesVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, RoutesVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Routes));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<RoutesVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RoutesVM>>(json);
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

        public (ExecutionState executionState, List<RoutesVM> entity, string message) GetFilterData(RoutesVM model)
        {
            (ExecutionState executionState, List<RoutesVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RoutesGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<RoutesVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<RoutesVM>>>(json);
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