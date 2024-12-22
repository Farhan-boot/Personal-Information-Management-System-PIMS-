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
    public class ChildrenInformationService : IChildrenInformationService
    {
        public (ExecutionState executionState, List<ChildrenInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<ChildrenInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<ChildrenInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ChildrenInformationVM>>>(json);
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
        public (ExecutionState executionState, ChildrenInformationVM entity, string message) Create(ChildrenInformationVM model)
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<ChildrenInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ChildrenInformationVM>>(json);
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
        public (ExecutionState executionState, ChildrenInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse;
            try
            {
                ChildrenInformationVM model = new ChildrenInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<ChildrenInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ChildrenInformationVM>>(json);
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
        public (ExecutionState executionState, ChildrenInformationVM entity, string message) Update(ChildrenInformationVM model)
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<ChildrenInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ChildrenInformationVM>>(json);
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
        public (ExecutionState executionState, ChildrenInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, ChildrenInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, ChildrenInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<ChildrenInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ChildrenInformationVM>>(json);
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
         

        public (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) GetFilterData(ChildrenInformationFilterVM model)
        {
            (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ChildrenInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<IList<ChildrenInformationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<IList<ChildrenInformationListVM>>>(json);
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