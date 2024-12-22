using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ISpouseInformationService
    {
        (ExecutionState executionState, List<SpouseInformationVM> entity, string message) List();
        (ExecutionState executionState, SpouseInformationVM entity, string message) Create(SpouseInformationVM model);
        (ExecutionState executionState, SpouseInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SpouseInformationVM entity, string message) Update(SpouseInformationVM model);
        (ExecutionState executionState, SpouseInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<SpouseInformationListVM> entity, string message) GetFilterData(SpouseInformationFilterVM model);
    }
}