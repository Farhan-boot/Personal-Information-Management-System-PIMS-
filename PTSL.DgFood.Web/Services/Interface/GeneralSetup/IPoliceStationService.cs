using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IPoliceStationService
    {
        (ExecutionState executionState, List<PoliceStationVM> entity, string message) List();
        (ExecutionState executionState, PoliceStationVM entity, string message) Create(PoliceStationVM model);
        (ExecutionState executionState, PoliceStationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PoliceStationVM entity, string message) Update(PoliceStationVM model);
        (ExecutionState executionState, PoliceStationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
