using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface ITrainingManagementTypeService
    {
        (ExecutionState executionState, List<TrainingManagementTypeVM> entity, string message) List();
        (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Create(TrainingManagementTypeVM model);
        (ExecutionState executionState, TrainingManagementTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Update(TrainingManagementTypeVM model);
        (ExecutionState executionState, TrainingManagementTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
		(ExecutionState executionState, IList<TrainingManagementTypeVM> entity, string message) ListLatest(int take);
	}
}
