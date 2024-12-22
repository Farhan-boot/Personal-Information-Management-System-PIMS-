using Newtonsoft.Json;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using System;

namespace PTSL.DgFood.Web.Services.Implementation
{
	public class DashboardService : IDashboardService
	{
		public (ExecutionState executionState, DashboardVM entity, string message) GetData()
		{
			(ExecutionState executionState, DashboardVM entity, string message) returnResponse;

			try
			{
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DashboardGetData));
				var json = new HttpHelper().Get(URL);
				WebApiResponse<DashboardVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DashboardVM>>(json);
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

