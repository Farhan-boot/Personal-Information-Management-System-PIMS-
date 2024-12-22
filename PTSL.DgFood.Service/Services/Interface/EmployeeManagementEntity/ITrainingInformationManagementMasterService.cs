using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public interface ITrainingInformationManagementMasterService : IBaseService<TrainingInformationManagementMasterVM, TrainingInformationManagementMaster>
    {
        Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagementMaster> queryOptions, TrainingInformationManagementMasterFilterVM entity);
        Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> List(QueryOptions<TrainingInformationManagementMaster> queryOptions);
        Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> GetTrainingInformationByTrainingManagementTypeId(long id);
        Task<(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message)> BulkUploadTraining(List<TrainingInformationManagementMasterVM> trainingInformationManagements);
        Task<(ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message)> GetByIdWithTrainingManagementAndType(long id);
        Task<(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message)> GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter);
    } 
}
