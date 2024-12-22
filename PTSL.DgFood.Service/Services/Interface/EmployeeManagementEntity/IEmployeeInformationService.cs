using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public interface IEmployeeInformationService : IBaseService<EmployeeInformationVM, EmployeeInformation>
    {
        Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetFilterData(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeByEmail(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> EmployeeListBySP(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity,string ConnectionString);
        Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeByEmailWithAllIncluding(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity);
        Task<(ExecutionState executionState, IList<EmployeeInformationVM> entity, string message)> GetEmployeeList(QueryOptions<EmployeeInformation> queryOptions=null);
        Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> EmployeeList(QueryOptions<EmployeeInformation> queryOptions=null);
        Task<(ExecutionState executionState, EmployeeInformationVM entity, string message)> GetEmployeeFullInfoById(long? id);
        Task<(ExecutionState executionState, EmployeeInformationListVM entity, string message)> GetEmployeeBasicInfoByEmployeeCode(string EmployeeCode);
        // (ExecutionState executionState,  string message) UpdateExistingEmployeeData();
        //Task<(ExecutionState executionState, IList<EmployeeInformationListVM> entity, string message)> List(QueryOptions<EmployeeInformation> queryOptions = null);
    }
}
