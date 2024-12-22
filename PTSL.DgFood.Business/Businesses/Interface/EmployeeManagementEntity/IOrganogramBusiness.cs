using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface IOrganogramBusiness : IBaseBusiness<Organogram>
    {
        Task<(ExecutionState executionState, long entity, string message)> CountEmployeeByPostDesignation(
            OrganogramOfficeType officeType,
            long? postingId,
            long? designationId, bool? IsPermanent = null);
        Task<(ExecutionState executionState, IList<OrganogramVM> entity, string message)> CustomDelete(long id);
        Task<(ExecutionState executionState, Organogram entity, string message)> GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
        Task<(ExecutionState executionState, IList<EmployeeInformation> empList, string message)> GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? IsPermanent = null);
		Task<(ExecutionState executionState, bool entity, string message)> IsOrganogramPostAvailable(OrganogramOfficeType officeType, long? postingId, long? designationId, bool? IsPermanent = null);
	}
}
