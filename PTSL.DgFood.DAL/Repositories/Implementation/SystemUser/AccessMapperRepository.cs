using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.DAL.Repositories.Implementation
{
    public class AccessMapperRepository : BaseRepository<AccessMapper>, IAccessMapperRepository
    {
        private readonly DbSet<AccessMapper> WriteOnlySet;
        private readonly DbSet<AccessMapper> ReadOnlySet;
        private DgFoodWriteOnlyCtx _ecommarceWriteOnlyCtx { get; }
        private DgFoodReadOnlyCtx _ecommarceReadOnlyCtx { get; }

        public AccessMapperRepository(
            DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
            DgFoodReadOnlyCtx ecommarceReadOnlyCtx
            )
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx)
        {
            this._ecommarceWriteOnlyCtx = ecommarceWriteOnlyCtx;
            this._ecommarceReadOnlyCtx = ecommarceReadOnlyCtx;

            this.WriteOnlySet = this._ecommarceWriteOnlyCtx.Set<AccessMapper>();
            this.ReadOnlySet = this._ecommarceReadOnlyCtx.Set<AccessMapper>();
        }

        //public async Task<(ExecutionState executionState, AccessMapper entity, string message)> AccessMapperLogin(LoginVM model)
        //{
        //    (ExecutionState executionState, AccessMapper entity, string message) getResponse;

        //    try
        //    {
        //        AccessMapper AccessMapper1 = ReadOnlySet.FirstOrDefault(x => x.AccessMapperEmail.Trim() == model.AccessMapperEmail.Trim() 
        //        && x.AccessMapperPassword == model.AccessMapperPassword);


        //        AccessMapper AccessMapper = _ecommarceReadOnlyCtx.AccessMappers.FirstOrDefault
        //            (
        //             x => x.AccessMapperEmail.Trim() == model.AccessMapperEmail.Trim() &&
        //            x.AccessMapperPassword == model.AccessMapperPassword);

        //        if (AccessMapper != null)
        //        {
        //            getResponse = (executionState: ExecutionState.Retrieved, AccessMapper, message: $"{typeof(AccessMapper).Name} item found.");
        //        }
        //        else
        //        {
        //            getResponse = (executionState: ExecutionState.Failure, null, $"{typeof(AccessMapper).Name} item not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        getResponse = (executionState: ExecutionState.Failure, null, message: ex.Message.ToString());
        //    }

        //    return getResponse;
        //}

    }
}
