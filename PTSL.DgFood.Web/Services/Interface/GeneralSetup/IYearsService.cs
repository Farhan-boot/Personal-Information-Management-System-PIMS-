using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IYearsService
    {
        (ExecutionState executionState, List<YearsVM> entity, string message) List();
        (ExecutionState executionState, YearsVM entity, string message) Create(YearsVM model);
        (ExecutionState executionState, YearsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, YearsVM entity, string message) Update(YearsVM model);
        (ExecutionState executionState, YearsVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
