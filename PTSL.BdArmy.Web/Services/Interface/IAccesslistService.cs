using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Services.Interface.GeneralSetup
{
    public interface IAccesslistService
    {
        (ExecutionState executionState, List<AccesslistVM> entity, string message) List();
        (ExecutionState executionState, AccesslistVM entity, string message) Create(AccesslistVM model);
        (ExecutionState executionState, AccesslistVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccesslistVM entity, string message) Update(AccesslistVM model);
        (ExecutionState executionState, AccesslistVM entity, string message) Delete(long? id);
    }
}
