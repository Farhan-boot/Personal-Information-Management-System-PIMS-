using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface ITrainingInformationManagementMasterService
    {
        (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) List();
        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Create(TrainingInformationManagementMasterVM model);
        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Update(TrainingInformationManagementMasterVM model);
        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<TrainingSmsVM> entity, string message) SendSMS(List<TrainingSmsVM> model);
		//(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetEmployeeInfoByEmployeIdAsync(long id);
		(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetByEmployeeId(TrainingInformationManagementMasterVM model);
        (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetFilterData(TrainingInformationManagementMasterVM model);
        (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetTrainingInformationByTrainingManagementTypeId(long? id);
        (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) BulkUploadTraining(List<TrainingInformationManagementMasterVM> data);
        (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) GetByIdWithTrainingManagementAndType(long? id);
        (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter);
    }
}