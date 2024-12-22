using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPresentStatusService
    {
        (ExecutionState executionState, List<PresentStatusVM> entity, string message) List();
        (ExecutionState executionState, PresentStatusVM entity, string message) Create(PresentStatusVM model);
        (ExecutionState executionState, PresentStatusVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PresentStatusVM entity, string message) Update(PresentStatusVM model);
        (ExecutionState executionState, PresentStatusVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
