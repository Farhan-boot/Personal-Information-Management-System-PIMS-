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
    public class TrainingInformationManagementService : ITrainingInformationManagementService
    {
        public (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) List()
        {
            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInformationManagementVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementVM>>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Create(TrainingInformationManagementVM model)
        {
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagement));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse;
            try
            {
                TrainingInformationManagementVM model = new TrainingInformationManagementVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagement + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<TrainingInformationManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementVM>>(json);
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
        public (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetByTrainingInformationManagementMasterId(long? id)
        {
            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                List<TrainingInformationManagementVM> model = new List<TrainingInformationManagementVM>();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetByTrainingInformationManagementMasterId + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInformationManagementVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementVM>>>(json);
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
        

        public (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Update(TrainingInformationManagementVM model)
        {
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagement));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, TrainingInformationManagementVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, TrainingInformationManagementVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagement));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<TrainingInformationManagementVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementVM>>(json);
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

         
        public (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetFilterData(TrainingInformationManagementVM model)
        {
            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementVM>>>(json);
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
        public (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetByEmployeeId(TrainingInformationManagementVM model)
        {
            (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementVM>>>(json);
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