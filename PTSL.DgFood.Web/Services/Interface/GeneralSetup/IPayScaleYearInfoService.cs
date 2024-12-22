using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IPayScaleYearInfoService
    {
        (ExecutionState executionState, List<PayScaleYearInfoVM> entity, string message) List();
        (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Create(PayScaleYearInfoVM model);
        (ExecutionState executionState, PayScaleYearInfoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Update(PayScaleYearInfoVM model);
        (ExecutionState executionState, PayScaleYearInfoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
