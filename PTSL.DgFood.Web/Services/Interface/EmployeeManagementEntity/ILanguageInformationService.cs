using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ILanguageInformationService
    {
        (ExecutionState executionState, List<LanguageInformationVM> entity, string message) List();
        (ExecutionState executionState, LanguageInformationVM entity, string message) Create(LanguageInformationVM model);
        (ExecutionState executionState, LanguageInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LanguageInformationVM entity, string message) Update(LanguageInformationVM model);
        (ExecutionState executionState, LanguageInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) GetFilterData(LanguageInformationFilterVM model);
    }
}