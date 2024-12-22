using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation
{
    public class OrganogramService : IOrganogramService
    {
        public (ExecutionState executionState, List<OrganogramVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OrganogramVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OrganogramList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<OrganogramVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OrganogramVM>>>(json);
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
        public (ExecutionState executionState, OrganogramVM entity, string message) Create(OrganogramVM model)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Organogram));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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
        public (ExecutionState executionState, OrganogramVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse;
            try
            {
                OrganogramVM model = new OrganogramVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Organogram + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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
                OrganogramVM model = new OrganogramVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OrganogramDoesExist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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
        public (ExecutionState executionState, OrganogramVM entity, string message) Update(OrganogramVM model)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Organogram));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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
        public (ExecutionState executionState, OrganogramVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OrganogramVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OrganogramCustomDelete));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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

        public (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) ListDetails()
        {
            (ExecutionState executionState, List<OrganogramDetailsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OrganogramDetailsList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<OrganogramDetailsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OrganogramDetailsVM>>>(json);
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

        public (ExecutionState executionState, OrganogramVM entity, string message) GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            (ExecutionState executionState, OrganogramVM entity, string message) returnResponse;
            try
            {
                OrganogramVM model = new OrganogramVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, $"{URLHelper.OrganogramByPostDesignation}?officeType={(int)officeType}&postingId={postingId}&designationId={designationId}&isPermanent={isPermanent}");
                var json = new HttpHelper().Get(URL);
                WebApiResponse<OrganogramVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OrganogramVM>>(json);
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

        public (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            (ExecutionState executionState, IList<EmployeeInformationVM> entity, string message) returnResponse;
            try
            {
                OrganogramVM model = new OrganogramVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, $"{URLHelper.OrganogramListByPostDesignation}?officeType={(int)officeType}&postingId={postingId}&designationId={designationId}&isPermanent={isPermanent}");
                var json = new HttpHelper().Get(URL);
                WebApiResponse<IList<EmployeeInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<IList<EmployeeInformationVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = new List<EmployeeInformationVM>();
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, bool entity, string message) IsOrganogramPostAvailable(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;
            try
            {
                OrganogramVM model = new OrganogramVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, $"{URLHelper.OrganogramListIsOrganogramPostAvailable}?officeType={(int)officeType}&postingId={postingId}&designationId={designationId}&isPermanent={isPermanent}");
                var json = new HttpHelper().Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
    }
}