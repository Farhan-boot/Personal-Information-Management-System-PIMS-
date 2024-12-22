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
    public class PayScaleYearInfoService : IPayScaleYearInfoService
    {
        public (ExecutionState executionState, List<PayScaleYearInfoVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PayScaleYearInfoVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfoList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PayScaleYearInfoVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PayScaleYearInfoVM>>>(json);
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
        public (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Create(PayScaleYearInfoVM model)
        {
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfo));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PayScaleYearInfoVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PayScaleYearInfoVM>>(json);
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
        public (ExecutionState executionState, PayScaleYearInfoVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse;
            try
            {
                PayScaleYearInfoVM model = new PayScaleYearInfoVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfo + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PayScaleYearInfoVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PayScaleYearInfoVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfoDoesExist + "/" + id));
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
        public (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Update(PayScaleYearInfoVM model)
        {
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfo));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PayScaleYearInfoVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PayScaleYearInfoVM>>(json);
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
        public (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PayScaleYearInfoVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PayScaleYearInfoVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PayScaleYearInfo));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PayScaleYearInfoVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PayScaleYearInfoVM>>(json);
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