using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IEmployeeTypeService
    {
        (ExecutionState executionState, List<EmployeeTypeVM> entity, string message) List();
        (ExecutionState executionState, EmployeeTypeVM entity, string message) Create(EmployeeTypeVM model);
        (ExecutionState executionState, EmployeeTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EmployeeTypeVM entity, string message) Update(EmployeeTypeVM model);
        (ExecutionState executionState, EmployeeTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
