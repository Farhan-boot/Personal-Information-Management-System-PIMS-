using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PTSL.DgFood.Web.Services.Implementation.GeneralSetup
{
    public class UserService : IUserService
    {
        public (ExecutionState executionState, List<UserVM> entity, string message) List()
        {
            (ExecutionState executionState, List<UserVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UserList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<UserVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<UserVM>>>(json);
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

        public (ExecutionState executionState, List<UserVM> entity, string message) EmployeeUserLists()
        {
            (ExecutionState executionState, List<UserVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UserEmployeeUserLists));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<UserVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<UserVM>>>(json);
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

        public (ExecutionState executionState, UserVM entity, string message) Create(UserVM model)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.User));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<UserVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UserVM>>(json);
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
        public (ExecutionState executionState, UserVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                UserVM model = new UserVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.User + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<UserVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UserVM>>(json);
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

        public (ExecutionState executionState, UserVM entity, string message) GetByEmployeeInformationId(long? employeeInformationId)
		{
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                UserVM model = new UserVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UserByEmployeeInformationId + "/" + employeeInformationId));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<UserVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UserVM>>(json);
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

        public (ExecutionState executionState, long entity, string message) CountByEmail(string userEmail)
		{
            (ExecutionState executionState, long entity, string message) returnResponse;
            try
            {
				LoginVM model = new LoginVM()
                {
                    UserEmail = userEmail
                };
                var respJson = JsonConvert.SerializeObject(model);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UserCountByEmail));
                var json = new HttpHelper().Post(URL, respJson, "application/json");

                WebApiResponse<long> responseJson = JsonConvert.DeserializeObject<WebApiResponse<long>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = 0;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, UserVM entity, string message) Update(UserVM model)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.User));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<UserVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UserVM>>(json);
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
        public (ExecutionState executionState, UserVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, UserVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.User));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<UserVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<UserVM>>(json);
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

        public (ExecutionState executionState, LoginResultVM entity, string message) UserLogin(LoginVM model)
        {
            (ExecutionState executionState, LoginResultVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.UserLogin));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<LoginResultVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LoginResultVM>>(json);
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