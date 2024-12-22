using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;

namespace PTSL.DgFood.Web.Services.Implementation.GeneralSetup
{
    public class UpazillaService : IUpazillaService
    {
        public (ExecutionState executionState, List<UpazillaVM> entity, string message) List()
        {
            (ExecutionState executionState, List<UpazillaVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UpazillaList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<UpazillaVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<UpazillaVM>>>(json);
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
        public (ExecutionState executionState, UpazillaVM entity, string message) Create(UpazillaVM model)
        {
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Upazilla));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<UpazillaVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UpazillaVM>>(json);
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
        public (ExecutionState executionState, UpazillaVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse;
            try
            {
                UpazillaVM model = new UpazillaVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Upazilla + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<UpazillaVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UpazillaVM>>(json);
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

        public (ExecutionState executionState, List<UpazillaVM> entity, string message) GetUpazillaByDivisionId(long? id)
        {
            (ExecutionState executionState, List<UpazillaVM> entity, string message) returnResponse;
            try
            {
                UpazillaVM model = new UpazillaVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Upazilla + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<UpazillaVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<UpazillaVM>>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UpazillaDoesExist + "/" + id));
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
        public (ExecutionState executionState, UpazillaVM entity, string message) Update(UpazillaVM model)
        {
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Upazilla));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<UpazillaVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UpazillaVM>>(json);
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
        public (ExecutionState executionState, UpazillaVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, UpazillaVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Upazilla));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<UpazillaVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UpazillaVM>>(json);
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