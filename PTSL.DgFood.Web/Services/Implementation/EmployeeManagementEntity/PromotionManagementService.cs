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
    public class PromotionManagementService : IPromotionManagementService
    {
        public (ExecutionState executionState, List<PromotionManagementVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PromotionManagementVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagementList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PromotionManagementVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PromotionManagementVM>>>(json);
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
        public (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) PromotionList()
        {
            (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetPromotionList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PromotionManagementListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PromotionManagementListVM>>>(json);
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
        public (ExecutionState executionState, PromotionManagementVM entity, string message) Create(PromotionManagementVM model)
        {
            (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagement));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PromotionManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionManagementVM>>(json);
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
        public (ExecutionState executionState, PromotionManagementVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse;
            try
            {
                PromotionManagementVM model = new PromotionManagementVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagement + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PromotionManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionManagementVM>>(json);
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
        public (ExecutionState executionState, PromotionManagementVM entity, string message) Update(PromotionManagementVM model)
        {
            (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagement));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PromotionManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionManagementVM>>(json);
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
        public (ExecutionState executionState, PromotionManagementVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PromotionManagementVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PromotionManagementVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagement));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PromotionManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PromotionManagementVM>>(json);
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
        public (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) GetFilterData(PromotionManagentFilterVM model)
        {
            (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PromotionManagementGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PromotionManagementListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PromotionManagementListVM>>>(json);
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