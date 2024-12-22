using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface IEmployeeInformationBusiness : IBaseBusiness<EmployeeInformation>
    {
        Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetFilterData(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetEmployeeFullInfoById(long? id);
        Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetEmployeeBasicInfoByEmployeeCode(string EmployeeCode);
        Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeByEmail(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeByEmailWithAllIncluding(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeList(QueryOptions<EmployeeInformation> queryOptions=null);
        Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> EmployeeList(QueryOptions<EmployeeInformation> queryOptions=null);
		Task<DirectAndPromotionalEmployeeVM> GetDirectAndPromotionalRecruitmentEmployee();
		Task<TotalEmployeeOfficeWiseVM> GetTotalEmployeeOfficeWise();
		//Task<(ExecutionState executionState, string message)> UpdateExistingEmployeeData();
	}
}
