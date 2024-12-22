using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity
{
    public interface IPromotionManagementBusiness : IBaseBusiness<PromotionManagement>
    {
        //Task<(ExecutionState executionState, List<PromotionManagement> entity, string message)> GetFilterData(QueryOptions<PromotionManagement> queryOptions, PromotionManagementFilterVM entity);
        Task<(ExecutionState executionState, IQueryable<PromotionManagement> entity, string message)> PromotionList(QueryOptions<PromotionManagement> queryOptions = null);
    }
}
