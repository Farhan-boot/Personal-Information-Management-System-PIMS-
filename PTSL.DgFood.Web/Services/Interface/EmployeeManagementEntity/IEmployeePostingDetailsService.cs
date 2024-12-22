using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity
{
    public interface IEmployeePostingDetailsService
    {
        (ExecutionState executionState, List<EmployeePostingDetailsVM> entity, string message) List();
        (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Create(EmployeePostingDetailsVM model);
        (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Update(EmployeePostingDetailsVM model);
        (ExecutionState executionState, EmployeePostingDetailsVM entity, string message) Delete(long? id);
    }
}