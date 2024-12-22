using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity
{
    public class PRLService : IPRLService
    {
        public async Task<(ExecutionState executionState, IList<OfficialInformationVM> entity, string message)> List()
        {
            (ExecutionState executionState, IList<OfficialInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRLList));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<IList<OfficialInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<IList<OfficialInformationVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = new List<OfficialInformationVM>();
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, IList<PRL_VM> entity, string message) Create(IList<PRL_VM> model)
        {
            (ExecutionState executionState, IList<PRL_VM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRLNotice));
                var json = new HttpHelper().Post(URL, respJson, "application/json");

                WebApiResponse<IList<PRL_VM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<IList<PRL_VM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = null;
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
        public (ExecutionState executionState, PRL_VM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PRL_VM entity, string message) returnResponse;
            try
            {
                PRL_VM model = new PRL_VM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRL + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PRL_VM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PRL_VM>>(json);
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
                PRL_VM model = new PRL_VM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRLDoesExist + "/" + id));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<PRL_VM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PRL_VM>>(json);
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
        public (ExecutionState executionState, string message) Update(IList<PRL_VM> model)
        {
            (ExecutionState executionState, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRL));
                var json = new HttpHelper().Put(URL, respJson, "application/json");
                WebApiResponse<PRL_VM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PRL_VM>>(json);
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
        public (ExecutionState executionState, PRL_VM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PRL_VM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PRL_VM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PRL));
                    var json = new HttpHelper().Put(URL, respJson, "application/json");
                    WebApiResponse<PRL_VM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PRL_VM>>(json);
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
        public (ExecutionState executionState, long prlCount, string message) GetPRLCount()
        {
            (ExecutionState executionState, long prlCount, string message) returnResponse;
            try
            {
                PRL_VM model = new PRL_VM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TotalPRl));
                var json = new HttpHelper().Get(URL);
                WebApiResponse<long> responseJson = JsonConvert.DeserializeObject<WebApiResponse<long>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.prlCount = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.prlCount = 0;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

    }
}
