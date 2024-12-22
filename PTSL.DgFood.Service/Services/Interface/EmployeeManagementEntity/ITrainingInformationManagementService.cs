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
    public interface ITrainingInformationManagementService : IBaseService<TrainingInformationManagementVM, TrainingInformationManagement>
    {
        Task<(ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagement> queryOptions, TrainingInformationManagementFilterVM entity);
        Task<(ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message)> GetByTrainingInformationManagementMasterId(long? id);
    } 
}
