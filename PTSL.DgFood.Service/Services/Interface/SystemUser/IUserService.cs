using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Interface
{
    public interface IUserService : IBaseService<UserVM, User>
    {
		Task<(ExecutionState executionState, UserVM entity, string message)> GetByEmployeeInformationId(long employeeInformationid);
		Task<(ExecutionState executionState, long entity, string message)> CountByEmail(string userEmail);
		Task<(ExecutionState executionState, UserVM entity, string message)> UserLogin(LoginVM model);
		Task<(ExecutionState executionState, IList<UserVM> entity, string message)> EmployeeUserLists();
		//Task<(ExecutionState executionState, UserVM entity, string message)> UserLists();
	}
}
