using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IDesignationService
    {
        (ExecutionState executionState, List<DesignationVM> entity, string message) List();
        (ExecutionState executionState, DesignationVM entity, string message) Create(DesignationVM model);
        (ExecutionState executionState, DesignationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DesignationVM entity, string message) Update(DesignationVM model);
        (ExecutionState executionState, DesignationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<DesignationVM> entity, string message) GetByRankAndDesignationClassId(long? rankId, long? designationClassId);
    }
}
