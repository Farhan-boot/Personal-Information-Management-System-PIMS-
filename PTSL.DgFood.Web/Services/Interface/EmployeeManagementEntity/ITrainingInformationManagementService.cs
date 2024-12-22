using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ITrainingInformationManagementService
    {
        (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) List();
        (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Create(TrainingInformationManagementVM model);
        (ExecutionState executionState, TrainingInformationManagementVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Update(TrainingInformationManagementVM model);
        (ExecutionState executionState, TrainingInformationManagementVM entity, string message) Delete(long? id);
        //(ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetEmployeeInfoByEmployeIdAsync(long id);
        (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetByEmployeeId(TrainingInformationManagementVM model);
        (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetByTrainingInformationManagementMasterId(long? id);
        (ExecutionState executionState, List<TrainingInformationManagementVM> entity, string message) GetFilterData(TrainingInformationManagementVM model);
    }
}