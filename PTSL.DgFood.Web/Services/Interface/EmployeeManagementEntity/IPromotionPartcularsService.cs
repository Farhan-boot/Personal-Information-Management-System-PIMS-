using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPromotionPartcularsService
    {
        (ExecutionState executionState, List<PromotionPartcularsVM> entity, string message) List();
        (ExecutionState executionState, PromotionPartcularsVM entity, string message) Create(PromotionPartcularsVM model);
        (ExecutionState executionState, PromotionPartcularsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PromotionPartcularsVM entity, string message) Update(PromotionPartcularsVM model);
        (ExecutionState executionState, PromotionPartcularsVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) GetFilterData(PromotionPartcularsFilterVM model);
    }
}