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
    public class PermanentAddressService : IPermanentAddressService
    {
        public (ExecutionState executionState, List<PermanentAddressVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PermanentAddressVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddressList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PermanentAddressVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PermanentAddressVM>>>(json);
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
        public (ExecutionState executionState, PermanentAddressVM entity, string message) Create(PermanentAddressVM model)
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddress));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PermanentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PermanentAddressVM>>(json);
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
        public (ExecutionState executionState, PermanentAddressVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse;
            try
            {
                PermanentAddressVM model = new PermanentAddressVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddress + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PermanentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PermanentAddressVM>>(json);
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
        public (ExecutionState executionState, PermanentAddressVM entity, string message) Update(PermanentAddressVM model)
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddress));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PermanentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PermanentAddressVM>>(json);
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
        public (ExecutionState executionState, PermanentAddressVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PermanentAddressVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PermanentAddressVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddress));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PermanentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PermanentAddressVM>>(json);
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


        public (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) GetFilterData(PermanentAddressFilterVM model)
        {
            (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PermanentAddressGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PermanentAddressListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PermanentAddressListVM>>>(json);
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