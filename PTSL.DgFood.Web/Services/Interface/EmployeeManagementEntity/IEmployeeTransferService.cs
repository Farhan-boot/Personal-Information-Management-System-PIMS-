using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IEmployeeTransferService
    {
        (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) List();
        (ExecutionState executionState, EmployeeTransferVM entity, string message) Create(EmployeeTransferVM model);
        (ExecutionState executionState, EmployeeTransferVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeeTransferVM entity, string message) Update(EmployeeTransferVM model);
        (ExecutionState executionState, EmployeeTransferVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<EmployeeTransferVM> entity, string message) GetFilterData(EmployeeTransferFilterVM model);
    }
}