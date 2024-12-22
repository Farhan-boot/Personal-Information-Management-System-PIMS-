using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IEducationalQualificationService
    {
        (ExecutionState executionState, List<EducationalQualificationVM> entity, string message) List();
        (ExecutionState executionState, EducationalQualificationVM entity, string message) Create(EducationalQualificationVM model);
        (ExecutionState executionState, EducationalQualificationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EducationalQualificationVM entity, string message) Update(EducationalQualificationVM model);
        (ExecutionState executionState, EducationalQualificationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) GetFilterData(EducationalQualificationFilterVM model);
    }
}