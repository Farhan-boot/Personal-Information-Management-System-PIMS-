using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IOfficialInformationService
    {
        (ExecutionState executionState, List<OfficialInformationVM> entity, string message) List();
        (ExecutionState executionState, OfficialInformationVM entity, string message) Create(OfficialInformationVM model);
        (ExecutionState executionState, OfficialInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, OfficialInformationVM entity, string message) Update(OfficialInformationVM model);
        (ExecutionState executionState, OfficialInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<OfficialInformationVM> entity, string message) GetFilterData(OfficialInformationFilterVM model);
    }
}