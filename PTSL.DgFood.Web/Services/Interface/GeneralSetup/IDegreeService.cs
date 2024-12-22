using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IDegreeService
    {
        (ExecutionState executionState, List<DegreeVM> entity, string message) List();
        (ExecutionState executionState, DegreeVM entity, string message) Create(DegreeVM model);
        (ExecutionState executionState, DegreeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DegreeVM entity, string message) Update(DegreeVM model);
        (ExecutionState executionState, DegreeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
