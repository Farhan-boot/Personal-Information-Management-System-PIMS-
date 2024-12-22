
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System.Collections.Generic;

namespace PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity
{
    public interface ITrainingPlanService
    {
        (ExecutionState executionState, List<TrainingPlanVM> entity, string message) List();
        (ExecutionState executionState, TrainingPlanVM entity, string message) Create(TrainingPlanVM model);
        (ExecutionState executionState, TrainingPlanVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingPlanVM entity, string message) Update(TrainingPlanVM model);
        (ExecutionState executionState, TrainingPlanVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}