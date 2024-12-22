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
    public interface ILeaveApplicationService : IBaseService<LeaveApplicationVM, LeaveApplication>
    {
        Task<(ExecutionState executionState, IList<LeaveApplicationVM> entity, string message)> GetByEmployeeId(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationVM entity);
        Task<(ExecutionState executionState, IList<LeaveApplicationVM> entity, string message)> GetFilterData(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationFilterVM entity);
        //Task<(ExecutionState executionState, IList<LeaveApplicationVM> entity, string message)> GetByEmployeeId(QueryOptions<LeaveApplicationVM> queryOptions, LeaveApplicationVM entity)
    } 
}
