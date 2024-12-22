using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IDivisionService
    {
        (ExecutionState executionState, List<DivisionVM> entity, string message) List();
        (ExecutionState executionState, DivisionVM entity, string message) Create(DivisionVM model);
        (ExecutionState executionState, DivisionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DivisionVM entity, string message) Update(DivisionVM model);
        (ExecutionState executionState, DivisionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
