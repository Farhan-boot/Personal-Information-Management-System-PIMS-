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
    public interface IAccessMapperRepository : IBaseRepository<AccessMapper>
    {
        //Task<(ExecutionState executionState, AccessMapper entity, string message)> AccessMapperLogin(LoginVM model);
    }
}
