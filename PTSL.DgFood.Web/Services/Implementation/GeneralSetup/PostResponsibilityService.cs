using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.GeneralSetup
{
    public class PostResponsibilityService : IPostResponsibilityService
    {
        public (ExecutionState executionState, List<PostResponsibilityVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PostResponsibilityVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibilityList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PostResponsibilityVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PostResponsibilityVM>>>(json);
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
        public (ExecutionState executionState, PostResponsibilityVM entity, string message) Create(PostResponsibilityVM model)
        {
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibility));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PostResponsibilityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostResponsibilityVM>>(json);
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
        public (ExecutionState executionState, PostResponsibilityVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse;
            try
            {
                PostResponsibilityVM model = new PostResponsibilityVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibility + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PostResponsibilityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostResponsibilityVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibilityDoesExist + "/" + id));
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
        public (ExecutionState executionState, PostResponsibilityVM entity, string message) Update(PostResponsibilityVM model)
        {
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibility));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PostResponsibilityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostResponsibilityVM>>(json);
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
        public (ExecutionState executionState, PostResponsibilityVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PostResponsibilityVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PostResponsibilityVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostResponsibility));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PostResponsibilityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostResponsibilityVM>>(json);
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