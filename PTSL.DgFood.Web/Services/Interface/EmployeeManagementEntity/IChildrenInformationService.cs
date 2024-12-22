using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IChildrenInformationService
    {
        (ExecutionState executionState, List<ChildrenInformationVM> entity, string message) List();
        (ExecutionState executionState, ChildrenInformationVM entity, string message) Create(ChildrenInformationVM model);
        (ExecutionState executionState, ChildrenInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ChildrenInformationVM entity, string message) Update(ChildrenInformationVM model);
        (ExecutionState executionState, ChildrenInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) GetFilterData(ChildrenInformationFilterVM model);
    }
}