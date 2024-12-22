using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface ITrainingInformationManagementMasterBusiness : IBaseBusiness<TrainingInformationManagementMaster>
    {
        Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagementMaster> queryOptions, TrainingInformationManagementMasterFilterVM entity);
        Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> List(QueryOptions<TrainingInformationManagementMaster> queryOptions);
        Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> GetTrainingInformationByTrainingManagementTypeId(long id);
        Task<(ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message)> BulkUploadTraining(List<TrainingInformationManagementMaster> trainings);
        Task<(ExecutionState executionState, TrainingInformationManagementMaster entity, string message)> GetByIdWithTrainingManagementAndType(long id);
        Task<(ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message)> GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter);
    }
}
