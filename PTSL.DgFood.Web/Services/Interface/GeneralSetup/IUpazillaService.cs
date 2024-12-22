using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using System.Collections.Generic;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IUpazillaService
    {
        (ExecutionState executionState, List<UpazillaVM> entity, string message) List();
        (ExecutionState executionState, UpazillaVM entity, string message) Create(UpazillaVM model);
        (ExecutionState executionState, UpazillaVM entity, string message) GetById(long? id);
        (ExecutionState executionState, UpazillaVM entity, string message) Update(UpazillaVM model);
        (ExecutionState executionState, UpazillaVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
