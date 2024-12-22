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
    public class PresentAddressService : IPresentAddressService
    {
        public (ExecutionState executionState, List<PresentAddressVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PresentAddressVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddressList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PresentAddressVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PresentAddressVM>>>(json);
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
        public (ExecutionState executionState, PresentAddressVM entity, string message) Create(PresentAddressVM model)
        {
            (ExecutionState executionState, PresentAddressVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddress));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PresentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PresentAddressVM>>(json);
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
        public (ExecutionState executionState, PresentAddressVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PresentAddressVM entity, string message) returnResponse;
            try
            {
                PresentAddressVM model = new PresentAddressVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddress + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PresentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PresentAddressVM>>(json);
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
        public (ExecutionState executionState, PresentAddressVM entity, string message) Update(PresentAddressVM model)
        {
            (ExecutionState executionState, PresentAddressVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddress));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PresentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PresentAddressVM>>(json);
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
        public (ExecutionState executionState, PresentAddressVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PresentAddressVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PresentAddressVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddress));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PresentAddressVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PresentAddressVM>>(json);
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


        public (ExecutionState executionState, List<PresentAddressListVM> entity, string message) GetFilterData(PresentAddressFilterVM model)
        {
            (ExecutionState executionState, List<PresentAddressListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PresentAddressGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PresentAddressListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PresentAddressListVM>>>(json);
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