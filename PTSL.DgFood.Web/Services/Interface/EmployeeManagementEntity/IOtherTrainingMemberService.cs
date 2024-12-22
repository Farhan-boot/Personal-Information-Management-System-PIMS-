using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity
{
    public interface IOtherTrainingMemberService
    {
        (ExecutionState executionState, List<OtherTrainingMemberVM> entity, string message) List();
        (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Create(OtherTrainingMemberVM model);
        (ExecutionState executionState, OtherTrainingMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Update(OtherTrainingMemberVM model);
        (ExecutionState executionState, OtherTrainingMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}