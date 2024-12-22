using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IUserGroupService
    {
        (ExecutionState executionState, List<UserGroupVM> entity, string message) List();
        (ExecutionState executionState, UserGroupVM entity, string message) Create(UserGroupVM model);
        (ExecutionState executionState, UserGroupVM entity, string message) GetById(long? id);
        (ExecutionState executionState, UserGroupVM entity, string message) Update(UserGroupVM model);
        (ExecutionState executionState, UserGroupVM entity, string message) Delete(long? id);
    }
}
