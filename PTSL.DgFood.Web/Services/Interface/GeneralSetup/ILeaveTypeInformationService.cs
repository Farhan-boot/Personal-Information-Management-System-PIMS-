using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.eCommerce.Web.Services.Interface.GeneralSetup
{
    public interface ILeaveTypeInformationService
    {
        (ExecutionState executionState, List<LeaveTypeInformationVM> entity, string message) List();
        (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Create(LeaveTypeInformationVM model);
        (ExecutionState executionState, LeaveTypeInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Update(LeaveTypeInformationVM model);
        (ExecutionState executionState, LeaveTypeInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
