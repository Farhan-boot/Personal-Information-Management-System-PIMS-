using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface ICalculationMethodService
    {
        (ExecutionState executionState, List<CalculationMethodVM> entity, string message) List();
        (ExecutionState executionState, CalculationMethodVM entity, string message) Create(CalculationMethodVM model);
        (ExecutionState executionState, CalculationMethodVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CalculationMethodVM entity, string message) Update(CalculationMethodVM model);
        (ExecutionState executionState, CalculationMethodVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
