using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface ISpecialHolydaySetupService
    {
        (ExecutionState executionState, List<SpecialHolydaySetupVM> entity, string message) List();
        (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Create(SpecialHolydaySetupVM model);
        (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Update(SpecialHolydaySetupVM model);
        (ExecutionState executionState, SpecialHolydaySetupVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
