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
    public interface ILeaveApplicationBusiness : IBaseBusiness<LeaveApplication>
    {
        Task<(ExecutionState executionState, IQueryable<LeaveApplication> entity, string message)> GetByEmployeeId(QueryOptions<LeaveApplication> queryOptions, long EmployeeInformationId);
        Task<(ExecutionState executionState, IQueryable<LeaveApplication> entity, string message)> GetFilterData(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationFilterVM entity);

    }
}
