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
    public class CalculationMethodService : ICalculationMethodService
    {
        public (ExecutionState executionState, List<CalculationMethodVM> entity, string message) List()
        {
            (ExecutionState executionState, List<CalculationMethodVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethodList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<CalculationMethodVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<CalculationMethodVM>>>(json);
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
        public (ExecutionState executionState, CalculationMethodVM entity, string message) Create(CalculationMethodVM model)
        {
            (ExecutionState executionState, CalculationMethodVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethod));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<CalculationMethodVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<CalculationMethodVM>>(json);
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
        public (ExecutionState executionState, CalculationMethodVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, CalculationMethodVM entity, string message) returnResponse;
            try
            {
                CalculationMethodVM model = new CalculationMethodVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethod + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<CalculationMethodVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<CalculationMethodVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethodDoesExist + "/" + id));
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
        public (ExecutionState executionState, CalculationMethodVM entity, string message) Update(CalculationMethodVM model)
        {
            (ExecutionState executionState, CalculationMethodVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethod));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<CalculationMethodVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<CalculationMethodVM>>(json);
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
        public (ExecutionState executionState, CalculationMethodVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, CalculationMethodVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, CalculationMethodVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.CalculationMethod));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<CalculationMethodVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<CalculationMethodVM>>(json);
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