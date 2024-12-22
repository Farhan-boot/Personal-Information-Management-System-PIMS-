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
    public class PromotionPartcularsService : IPromotionPartcularsService
    {
        public (ExecutionState executionState, List<PromotionPartcularsVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PromotionPartcularsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartcularsList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PromotionPartcularsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PromotionPartcularsVM>>>(json);
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
        public (ExecutionState executionState, PromotionPartcularsVM entity, string message) Create(PromotionPartcularsVM model)
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartculars));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PromotionPartcularsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionPartcularsVM>>(json);
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
        public (ExecutionState executionState, PromotionPartcularsVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse;
            try
            {
                PromotionPartcularsVM model = new PromotionPartcularsVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartculars + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PromotionPartcularsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionPartcularsVM>>(json);
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
        public (ExecutionState executionState, PromotionPartcularsVM entity, string message) Update(PromotionPartcularsVM model)
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartculars));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PromotionPartcularsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionPartcularsVM>>(json);
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
        public (ExecutionState executionState, PromotionPartcularsVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PromotionPartcularsVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PromotionPartcularsVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartculars));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PromotionPartcularsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionPartcularsVM>>(json);
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
        public (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) GetFilterData(PromotionPartcularsFilterVM model)
        {
            (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionPartcularsGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PromotionParticularsListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PromotionParticularsListVM>>>(json);
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