using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public interface IOrganogramService : IBaseService<OrganogramVM, Organogram>
    {
        Task<(ExecutionState executionState, IList<OrganogramVM> entity, string message)> CustomDelete(long id);
        Task<(ExecutionState executionState, OrganogramVM entity, string message)> GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
        Task<(ExecutionState executionState, List<OrganogramDetailsVM> entity, string message)> ListDetails();
        Task<(ExecutionState executionState,IList<EmployeeInformationVM> organogramList, string message)> GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent);
    }
}
