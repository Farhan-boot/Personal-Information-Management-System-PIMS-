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
    public class PostingRecordsService : IPostingRecordsService
    {
        public (ExecutionState executionState, List<PostingRecordsVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PostingRecordsVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecordsList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PostingRecordsVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PostingRecordsVM>>>(json);
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
        public (ExecutionState executionState, PostingRecordsVM entity, string message) Create(PostingRecordsVM model)
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecords));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                WebApiResponse<PostingRecordsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostingRecordsVM>>(json);
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
        public (ExecutionState executionState, PostingRecordsVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse;
            try
            {
                PostingRecordsVM model = new PostingRecordsVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecords + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PostingRecordsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostingRecordsVM>>(json);
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
        public (ExecutionState executionState, PostingRecordsVM entity, string message) Update(PostingRecordsVM model)
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecords));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PostingRecordsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostingRecordsVM>>(json);
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
        public (ExecutionState executionState, PostingRecordsVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PostingRecordsVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PostingRecordsVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecords));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PostingRecordsVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PostingRecordsVM>>(json);
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


        public (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) GetFilterData(PostingRecordsFilterVM model)
        {
            (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PostingRecordsGetFilterData));
                var json = new HttpHelper().Post(URL, respJson, "application/json");
                //var json = new HttpHelper().Get(URL);
                WebApiResponse<List<PostingRecordsListVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PostingRecordsListVM>>>(json);
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