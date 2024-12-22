using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IModuleService
    {
        (ExecutionState executionState, List<ModuleVM> entity, string message) List();
        (ExecutionState executionState, ModuleVM entity, string message) Create(ModuleVM model);
        (ExecutionState executionState, ModuleVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ModuleVM entity, string message) Update(ModuleVM model);
        (ExecutionState executionState, ModuleVM entity, string message) Delete(long? id);
    }
}
