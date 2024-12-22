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
    public class TrainingInformationManagementMasterService : ITrainingInformationManagementMasterService
    {
        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) List()
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMasterList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Create(TrainingInformationManagementMasterVM model)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMaster));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationManagementMasterVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementMasterVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;
            try
            {
                TrainingInformationManagementMasterVM model = new TrainingInformationManagementMasterVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMaster + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<TrainingInformationManagementMasterVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementMasterVM>>(json);
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
        public (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) GetByIdWithTrainingManagementAndType(long? id)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;
            try
            {
                TrainingInformationManagementMasterVM model = new TrainingInformationManagementMasterVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMasterGetByIdWithTrainingManagementAndType + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<TrainingInformationManagementMasterVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementMasterVM>>(json);
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
        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMasterGetCompletedByFromToDate));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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
        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetTrainingInformationByTrainingManagementTypeId(long? id)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                TrainingInformationManagementMasterVM model = new TrainingInformationManagementMasterVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetTrainingInformationByTrainingManagementTypeId + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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
         
        public (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Update(TrainingInformationManagementMasterVM model)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMaster));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<TrainingInformationManagementMasterVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementMasterVM>>(json);
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
         
        public (ExecutionState executionState, List<TrainingSmsVM> entity, string message) SendSMS(List<TrainingSmsVM> model)
		{
            (ExecutionState executionState, List<TrainingSmsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementSendSms));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingSmsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingSmsVM>>>(json);
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

        public (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMaster));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<TrainingInformationManagementMasterVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingInformationManagementMasterVM>>(json);
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

         
        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetFilterData(TrainingInformationManagementMasterVM model)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMasterGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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
        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetByEmployeeId(TrainingInformationManagementMasterVM model)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingInformationManagementMasterGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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

        public (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) BulkUploadTraining(List<TrainingInformationManagementMasterVM> model)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingBulkUpload));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<List<TrainingInformationManagementMasterVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingInformationManagementMasterVM>>>(json);
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