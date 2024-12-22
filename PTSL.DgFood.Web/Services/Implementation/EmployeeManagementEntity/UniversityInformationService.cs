using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity
{
    public class UniversityInformationService : IUniversityInformationService
    {
        public (ExecutionState executionState, List<UniversityInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<UniversityInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformationList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<UniversityInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<UniversityInformationVM>>>(json);
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
        public (ExecutionState executionState, UniversityInformationVM entity, string message) Create(UniversityInformationVM model)
        {
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformation));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<UniversityInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UniversityInformationVM>>(json);
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
        public (ExecutionState executionState, UniversityInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse;
            try
            {
                UniversityInformationVM model = new UniversityInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformation + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<UniversityInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UniversityInformationVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformationDoesExist + "/" + id));
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
        public (ExecutionState executionState, UniversityInformationVM entity, string message) Update(UniversityInformationVM model)
        {
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformation));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<UniversityInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UniversityInformationVM>>(json);
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
        public (ExecutionState executionState, UniversityInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, UniversityInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, UniversityInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UniversityInformation));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<UniversityInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UniversityInformationVM>>(json);
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