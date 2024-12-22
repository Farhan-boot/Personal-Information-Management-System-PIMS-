using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface IUserBusiness : IBaseBusiness<User>
    {
		Task<(ExecutionState executionState, IQueryable<User> entity, string message)> EmployeeUserLists();
		Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model);
        //Task<(ExecutionState executionState, List<User> entity, string message)> UserLists();
    }
}
