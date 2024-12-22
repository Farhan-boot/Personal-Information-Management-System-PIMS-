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
    public class TrainingInformationService : ITrainingInformationService
    {
        public (ExecutionState executionState, List<TrainingInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<TrainingInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationVM>>>(json);
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
        public (ExecutionState executionState, TrainingInformationVM entity, string message) Create(TrainingInformationVM model)
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse;
            try
            {
                TrainingInformationVM model = new TrainingInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<TrainingInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationVM entity, string message) Update(TrainingInformationVM model)
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, TrainingInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, TrainingInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<TrainingInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationVM>>(json);
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


        public (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) GetFilterData(TrainingInformationFilterVM model)
        {
            (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInfoListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInfoListVM>>>(json);
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