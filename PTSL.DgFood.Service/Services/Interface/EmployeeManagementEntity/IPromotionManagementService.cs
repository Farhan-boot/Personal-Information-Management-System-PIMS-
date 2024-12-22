using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity
{
    public interface IPromotionManagementService : IBaseService<PromotionManagementVM, PromotionManagement>
    {
        //Task<(ExecutionState executionState, List<PromotionManagementListVM> entity, string message)> GetFilterData(QueryOptions<PromotionManagement> queryOptions, PromotionManagementFilterVM entity);
        Task<(ExecutionState executionState, IList<PromotionManagementListVM> entity, string message)> PromotionList(QueryOptions<PromotionManagement> queryOptions = null);
    }
}
