using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IServiceHistoryService
    {
        (ExecutionState executionState, List<ServiceHistoryVM> entity, string message) List();
        (ExecutionState executionState, ServiceHistoryVM entity, string message) Create(ServiceHistoryVM model);
        (ExecutionState executionState, ServiceHistoryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ServiceHistoryVM entity, string message) Update(ServiceHistoryVM model);
        (ExecutionState executionState, ServiceHistoryVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) GetFilterData(ServiceHistoryFilterVM model);
    }
}