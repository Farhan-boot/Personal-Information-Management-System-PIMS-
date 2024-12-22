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
    public class OtherTrainingMemberService : IOtherTrainingMemberService
    {
        public (ExecutionState executionState, List<OtherTrainingMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OtherTrainingMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMemberList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<OtherTrainingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherTrainingMemberVM>>>(json);
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
        public (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Create(OtherTrainingMemberVM model)
        {
            (ExecutionState executionState, OtherTrainingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMember));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<OtherTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherTrainingMemberVM>>(json);
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
        public (ExecutionState executionState, OtherTrainingMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OtherTrainingMemberVM entity, string message) returnResponse;
            try
            {
                OtherTrainingMemberVM model = new OtherTrainingMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMember + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<OtherTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherTrainingMemberVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMemberDoesExist + "/" + id));
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
        public (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Update(OtherTrainingMemberVM model)
        {
            (ExecutionState executionState, OtherTrainingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMember));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<OtherTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherTrainingMemberVM>>(json);
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
        public (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OtherTrainingMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OtherTrainingMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherTrainingMember));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<OtherTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherTrainingMemberVM>>(json);
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