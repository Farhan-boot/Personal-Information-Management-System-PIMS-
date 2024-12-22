using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface IGradationTypeService
    {
        (ExecutionState executionState, List<GradationTypeVM> entity, string message) List();
        (ExecutionState executionState, GradationTypeVM entity, string message) Create(GradationTypeVM model);
        (ExecutionState executionState, GradationTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, GradationTypeVM entity, string message) Update(GradationTypeVM model);
        (ExecutionState executionState, GradationTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
