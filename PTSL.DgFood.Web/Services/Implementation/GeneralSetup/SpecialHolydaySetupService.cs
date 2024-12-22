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
    public class SpecialHolydaySetupService : ISpecialHolydaySetupService
    {
        public (ExecutionState executionState, List<SpecialHolydaySetupVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SpecialHolydaySetupVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetupList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<SpecialHolydaySetupVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SpecialHolydaySetupVM>>>(json);
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
        public (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Create(SpecialHolydaySetupVM model)
        {
            (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetup));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<SpecialHolydaySetupVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpecialHolydaySetupVM>>(json);
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
        public (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) returnResponse;
            try
            {
                SpecialHolydaySetupVM model = new SpecialHolydaySetupVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetup + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<SpecialHolydaySetupVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpecialHolydaySetupVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetupDoesExist + "/" + id));
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
        public (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Update(SpecialHolydaySetupVM model)
        {
            (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetup));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<SpecialHolydaySetupVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpecialHolydaySetupVM>>(json);
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
        public (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SpecialHolydaySetup));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<SpecialHolydaySetupVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SpecialHolydaySetupVM>>(json);
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