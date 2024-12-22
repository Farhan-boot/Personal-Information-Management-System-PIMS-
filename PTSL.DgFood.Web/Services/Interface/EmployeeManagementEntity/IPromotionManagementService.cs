using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPromotionManagementService
    {
        (ExecutionState executionState, List<PromotionManagementVM> entity, string message) List();
        (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) PromotionList();
        (ExecutionState executionState, PromotionManagementVM entity, string message) Create(PromotionManagementVM model);
        (ExecutionState executionState, PromotionManagementVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PromotionManagementVM entity, string message) Update(PromotionManagementVM model);
        (ExecutionState executionState, PromotionManagementVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) GetFilterData(PromotionManagentFilterVM model);
    }
}
