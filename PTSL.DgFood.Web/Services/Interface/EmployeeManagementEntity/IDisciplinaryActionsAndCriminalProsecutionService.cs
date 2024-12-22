using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IDisciplinaryActionsAndCriminalProsecutionService
    {
        (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionVM> entity, string message) List();
        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Create(DisciplinaryActionsAndCriminalProsecutionVM model);
        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Update(DisciplinaryActionsAndCriminalProsecutionVM model);
        (ExecutionState executionState, DisciplinaryActionsAndCriminalProsecutionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) GetFilterData(DisciplinaryActionsAndCriminalProsecutionFilterVM model);
        (ExecutionState executionState, List<EmployeeInformationByDisciplinaryVM> entity, string message) GetEmployeeByDisciplinaryActionsFilter(DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM model);
    }
}