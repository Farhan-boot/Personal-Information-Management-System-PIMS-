using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IDistrictService
    {
        (ExecutionState executionState, List<DistrictVM> entity, string message) List();
        (ExecutionState executionState, DistrictVM entity, string message) Create(DistrictVM model);
        (ExecutionState executionState, DistrictVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DistrictVM entity, string message) Update(DistrictVM model);
        (ExecutionState executionState, DistrictVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<DistrictVM> entity, string message) GetDistrictByDivisionId(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
