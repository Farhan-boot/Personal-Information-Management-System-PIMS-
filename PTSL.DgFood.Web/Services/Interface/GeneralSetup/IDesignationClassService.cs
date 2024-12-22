using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IDesignationClassService
    {
        (ExecutionState executionState, List<DesignationClassVM> entity, string message) List();
        (ExecutionState executionState, DesignationClassVM entity, string message) Create(DesignationClassVM model);
        (ExecutionState executionState, DesignationClassVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DesignationClassVM entity, string message) Update(DesignationClassVM model);
        (ExecutionState executionState, DesignationClassVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
