using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IEmployeeStatusService
    {
        (ExecutionState executionState, List<EmployeeStatusVM> entity, string message) List();
        (ExecutionState executionState, EmployeeStatusVM entity, string message) Create(EmployeeStatusVM model);
        (ExecutionState executionState, EmployeeStatusVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeeStatusVM entity, string message) Update(EmployeeStatusVM model);
        (ExecutionState executionState, EmployeeStatusVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
