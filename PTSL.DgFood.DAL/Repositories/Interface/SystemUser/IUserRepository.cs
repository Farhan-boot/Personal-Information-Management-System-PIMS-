using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.DAL.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model);
    }
}
