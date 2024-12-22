using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ITrainingInformationService
    {
        (ExecutionState executionState, List<TrainingInformationVM> entity, string message) List();
        (ExecutionState executionState, TrainingInformationVM entity, string message) Create(TrainingInformationVM model);
        (ExecutionState executionState, TrainingInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingInformationVM entity, string message) Update(TrainingInformationVM model);
        (ExecutionState executionState, TrainingInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) GetFilterData(TrainingInformationFilterVM model);
    }
}