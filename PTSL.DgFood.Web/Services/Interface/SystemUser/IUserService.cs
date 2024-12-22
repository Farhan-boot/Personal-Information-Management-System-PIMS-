using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Services.Interface.GeneralSetup
{
    public interface IUserService
    {
        (ExecutionState executionState, List<UserVM> entity, string message) List();
        (ExecutionState executionState, UserVM entity, string message) Create(UserVM model);
        (ExecutionState executionState, UserVM entity, string message) GetById(long? id);
		(ExecutionState executionState, UserVM entity, string message) GetByEmployeeInformationId(long? employeeInformationId);
		(ExecutionState executionState, long entity, string message) CountByEmail(string userEmail);
		(ExecutionState executionState, UserVM entity, string message) Update(UserVM model);
        (ExecutionState executionState, UserVM entity, string message) Delete(long? id);
        (ExecutionState executionState, LoginResultVM entity, string message) UserLogin(LoginVM model);
		(ExecutionState executionState, List<UserVM> entity, string message) EmployeeUserLists();
	}
}
