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
    public class EmployeeInformationService : IEmployeeInformationService
    {
        public (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationVM>>>(json);
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

        public (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) EmployeeList()
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationListVM>>>(json);
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
        public (ExecutionState executionState, EmployeeInformationVM entity, string message) Create(EmployeeInformationVM model)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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
        public (ExecutionState executionState, EmployeeInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                EmployeeInformationVM model = new EmployeeInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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

        public (ExecutionState executionState, EmployeeInformationVM entity, string message) GetEmployeeFullInfoById(long? id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                EmployeeInformationVM model = new EmployeeInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetEmployeeFullInfoById + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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

        public (ExecutionState executionState, EmployeeInformationVM entity, string message) Update(EmployeeInformationVM model)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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
        public (ExecutionState executionState, EmployeeInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EmployeeInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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

        public (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) GetFilterData(EmployeeInformationFilterVM model)
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                //var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetFilterData),respJson, "application/json");
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationListVM>>>(json);
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
        public (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeByEmail(EmployeeInformationVM model)
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetEmployeeByEmail));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationVM>>>(json);
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
        public (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeByEmailWithAllIncluding(EmployeeInformationVM model)
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetEmployeeByEmailWithAllIncluding));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationVM>>>(json);
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
        public (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) GetEmployeeList()
        {
            (ExecutionState executionState, List<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetEmployeeList));
                //var json = new HttpHelper().Post(URL, respJson, "application/json");
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationVM>>>(json);
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

        public (ExecutionState executionState, EmployeeInformationVM entity, string message) GetEmployeeBasicInfoById(long? id)
        {
            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse;
            try
            {
                EmployeeInformationVM model = new EmployeeInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetEmployeeBasicInfoByEmployeeCode+ "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<EmployeeInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EmployeeInformationVM>>(json);
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


        public (ExecutionState executionState, string message) UpdateExistingEmployeeData()
        {
            (ExecutionState executionState, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UpdateExistingEmployeeData));
                //var json = new HttpHelper().Post(URL, respJson, "application/json");
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) EmployeeListBySP(EmployeeInformationFilterVM model)
        {
            (ExecutionState executionState, List<EmployeeInformationListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                //var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationGetFilterData),respJson, "application/json");
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EmployeeInformationEmployeeListBySP));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<EmployeeInformationListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EmployeeInformationListVM>>>(json);
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