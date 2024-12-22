using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IAccessMapperService
    {
        (ExecutionState executionState, List<AccessMapperVM> entity, string message) List();
        (ExecutionState executionState, AccessMapperVM entity, string message) Create(AccessMapperVM model);
        (ExecutionState executionState, AccessMapperVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccessMapperVM entity, string message) Update(AccessMapperVM model);
        (ExecutionState executionState, AccessMapperVM entity, string message) Delete(long? id);
    }
}
