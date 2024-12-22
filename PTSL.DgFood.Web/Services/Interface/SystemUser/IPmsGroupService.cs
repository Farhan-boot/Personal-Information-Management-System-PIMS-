using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPmsGroupService
    {
        (ExecutionState executionState, List<PmsGroupVM> entity, string message) List();
        (ExecutionState executionState, PmsGroupVM entity, string message) Create(PmsGroupVM model);
        (ExecutionState executionState, PmsGroupVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PmsGroupVM entity, string message) Update(PmsGroupVM model);
        (ExecutionState executionState, PmsGroupVM entity, string message) Delete(long? id);
    }
}
