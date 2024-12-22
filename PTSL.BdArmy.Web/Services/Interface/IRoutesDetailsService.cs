using PTSL.BdArmy.Common.Entity.BdArmy;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Services.Interface
{
    public interface IRoutesDetailsService
    {
        (ExecutionState executionState, List<RoutesDetailsVM> entity, string message) List();
        (ExecutionState executionState, RoutesDetailsVM entity, string message) Create(RoutesDetailsVM model);
        (ExecutionState executionState, RoutesDetailsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RoutesDetailsVM entity, string message) Update(RoutesDetailsVM model);
        (ExecutionState executionState, RoutesDetailsVM entity, string message) Delete(long? id);
    }
}
