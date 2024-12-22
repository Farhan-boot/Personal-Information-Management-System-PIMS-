using PTSL.BdArmy.Common.Entity.BdArmy;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Services.Interface.GeneralSetup
{
    public interface IRoutesService
    {
        (ExecutionState executionState, List<RoutesVM> entity, string message) List();
        (ExecutionState executionState, RoutesVM entity, string message) Create(RoutesVM model);
        (ExecutionState executionState, RoutesVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RoutesVM entity, string message) Update(RoutesVM model);
        (ExecutionState executionState, RoutesVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<RoutesVM> entity, string message) GetFilterData(RoutesVM model);
    }
}
