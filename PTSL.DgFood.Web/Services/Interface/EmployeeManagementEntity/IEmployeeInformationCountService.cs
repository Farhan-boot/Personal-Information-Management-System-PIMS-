using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface
{
    public interface IEmployeeInformationCountService
    {
        (ExecutionState executionState, List<EmployeeInformationCountVM> entity, string message) List();
        (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Create(EmployeeInformationCountVM model);
        (ExecutionState executionState, EmployeeInformationCountVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Update(EmployeeInformationCountVM model);
        (ExecutionState executionState, EmployeeInformationCountVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}