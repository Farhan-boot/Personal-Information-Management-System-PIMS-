using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity
{
    public interface IDisciplinaryHistoryService
    {
        (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) Create(DisciplinaryHistoryVM model);
        (ExecutionState executionState, DisciplinaryHistoryVM entity, string message) Update(DisciplinaryHistoryVM model);

    }
}
