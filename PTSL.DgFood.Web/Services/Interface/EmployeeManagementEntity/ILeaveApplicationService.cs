using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ILeaveApplicationService
    {
        (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) List();
        (ExecutionState executionState, LeaveApplicationVM entity, string message) Create(LeaveApplicationVM model);
        (ExecutionState executionState, LeaveApplicationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LeaveApplicationVM entity, string message) Update(LeaveApplicationVM model);
        (ExecutionState executionState, LeaveApplicationVM entity, string message) Delete(long? id);
        //(ExecutionState executionState, List<LeaveApplicationVM> entity, string message) GetEmployeeInfoByEmployeIdAsync(long id);
        (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) GetByEmployeeId(LeaveApplicationVM model);
        (ExecutionState executionState, List<LeaveApplicationVM> entity, string message) GetFilterData(LeaveApplicationVM model);
    }
}