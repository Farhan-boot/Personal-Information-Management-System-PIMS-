using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IWeeklyHolydaySetupService
    {
        (ExecutionState executionState, List<WeeklyHolydaySetupVM> entity, string message) List();
        (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) Create(WeeklyHolydaySetupVM model);
        (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) GetById(long? id);
        (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) Update(WeeklyHolydaySetupVM model);
        (ExecutionState executionState, WeeklyHolydaySetupVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
