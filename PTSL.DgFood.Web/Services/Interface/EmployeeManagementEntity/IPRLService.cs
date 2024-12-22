using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IPRLService
    {
        Task<(ExecutionState executionState, IList<OfficialInformationVM> entity, string message)> List();
        (ExecutionState executionState, IList<PRL_VM> entity, string message) Create(IList<PRL_VM> model);
        (ExecutionState executionState, PRL_VM entity, string message) GetById(long? id);
        (ExecutionState executionState, string message) Update(IList<PRL_VM> model);
        (ExecutionState executionState, PRL_VM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}