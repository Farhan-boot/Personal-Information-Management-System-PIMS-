using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.GeneralSetup
{
    public class TrainingManagementTypeService : ITrainingManagementTypeService
    {
        public (ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementTypeList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<TrainingManagementTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TrainingManagementTypeVM>>>(json);
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
        public (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Create(TrainingManagementTypeVM model)
        {
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementType));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<TrainingManagementTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingManagementTypeVM>>(json);
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
        public (ExecutionState executionState, TrainingManagementTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse;
            try
            {
                TrainingManagementTypeVM model = new TrainingManagementTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementType + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<TrainingManagementTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingManagementTypeVM>>(json);
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

        public (ExecutionState executionState, IList<TrainingManagementTypeVM> entity, string message) ListLatest(int take)
        {
            (ExecutionState executionState, IList<TrainingManagementTypeVM> entity, string message) returnResponse;
            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementTypeListLatest + "/" + take));
                var json = new HttpHelper().Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<IList<TrainingManagementTypeVM>>>(json);
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

        public (ExecutionState executionState, string message) DoesExist(long? id)
        {
            (ExecutionState executionState, string message) returnResponse;
            try
            {
                DegreeVM model = new DegreeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementTypeDoesExist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<DegreeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DegreeVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                //returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                //returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Update(TrainingManagementTypeVM model)
        {
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementType));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<TrainingManagementTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingManagementTypeVM>>(json);
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
        public (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, TrainingManagementTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, TrainingManagementTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TrainingManagementType));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<TrainingManagementTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TrainingManagementTypeVM>>(json);
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