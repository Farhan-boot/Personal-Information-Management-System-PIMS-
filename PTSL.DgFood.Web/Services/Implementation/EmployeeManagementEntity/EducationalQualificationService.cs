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
    public class EducationalQualificationService : IEducationalQualificationService
    {
        public (ExecutionState executionState, List<EducationalQualificationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EducationalQualificationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualificationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EducationalQualificationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EducationalQualificationVM>>>(json);
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
        public (ExecutionState executionState, EducationalQualificationVM entity, string message) Create(EducationalQualificationVM model)
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualification));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<EducationalQualificationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EducationalQualificationVM>>(json);
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
        public (ExecutionState executionState, EducationalQualificationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse;
            try
            {
                EducationalQualificationVM model = new EducationalQualificationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualification + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EducationalQualificationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EducationalQualificationVM>>(json);
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
        public (ExecutionState executionState, EducationalQualificationVM entity, string message) Update(EducationalQualificationVM model)
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualification));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<EducationalQualificationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EducationalQualificationVM>>(json);
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
        public (ExecutionState executionState, EducationalQualificationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EducationalQualificationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EducationalQualificationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualification));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<EducationalQualificationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EducationalQualificationVM>>(json);
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

        public (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) GetFilterData(EducationalQualificationFilterVM model)
        {
            (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EducationalQualificationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EducationalQualificationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EducationalQualificationListVM>>>(json);
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