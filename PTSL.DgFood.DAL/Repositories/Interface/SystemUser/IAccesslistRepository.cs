using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.DAL.Repositories.Interface
{
    public interface IAccesslistRepository : IBaseRepository<Accesslist>
    {
        //Task<(ExecutionState executionState, Accesslist entity, string message)> AccesslistLogin(LoginVM model);
    }
}
