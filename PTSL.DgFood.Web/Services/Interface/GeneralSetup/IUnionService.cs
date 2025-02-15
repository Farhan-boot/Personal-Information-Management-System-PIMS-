using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using System.Collections.Generic;

namespace PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup
{
    public interface IUnionService
    {
        (ExecutionState executionState, List<UnionVM> entity, string message) List();
        (ExecutionState executionState, UnionVM entity, string message) Create(UnionVM model);
        (ExecutionState executionState, UnionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, UnionVM entity, string message) Update(UnionVM model);
        (ExecutionState executionState, UnionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}