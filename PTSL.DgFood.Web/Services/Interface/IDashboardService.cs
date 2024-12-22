using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
	public interface IDashboardService
    {
        (ExecutionState executionState, DashboardVM entity, string message) GetData();
    }
}

