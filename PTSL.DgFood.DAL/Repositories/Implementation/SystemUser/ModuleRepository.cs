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
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        private readonly DbSet<Module> WriteOnlySet;
        private readonly DbSet<Module> ReadOnlySet;
        private DgFoodWriteOnlyCtx _ecommarceWriteOnlyCtx { get; }
        private DgFoodReadOnlyCtx _ecommarceReadOnlyCtx { get; }

        public ModuleRepository(
            DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
            DgFoodReadOnlyCtx ecommarceReadOnlyCtx
            )
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx)
        {
            this._ecommarceWriteOnlyCtx = ecommarceWriteOnlyCtx;
            this._ecommarceReadOnlyCtx = ecommarceReadOnlyCtx;

            this.WriteOnlySet = this._ecommarceWriteOnlyCtx.Set<Module>();
            this.ReadOnlySet = this._ecommarceReadOnlyCtx.Set<Module>();
        }

        //public async Task<(ExecutionState executionState, Module entity, string message)> ModuleLogin(LoginVM model)
        //{
        //    (ExecutionState executionState, Module entity, string message) getResponse;

        //    try
        //    {
        //        Module Module1 = ReadOnlySet.FirstOrDefault(x => x.ModuleEmail.Trim() == model.ModuleEmail.Trim() 
        //        && x.ModulePassword == model.ModulePassword);


        //        Module Module = _ecommarceReadOnlyCtx.Modules.FirstOrDefault
        //            (
        //             x => x.ModuleEmail.Trim() == model.ModuleEmail.Trim() &&
        //            x.ModulePassword == model.ModulePassword);

        //        if (Module != null)
        //        {
        //            getResponse = (executionState: ExecutionState.Retrieved, Module, message: $"{typeof(Module).Name} item found.");
        //        }
        //        else
        //        {
        //            getResponse = (executionState: ExecutionState.Failure, null, $"{typeof(Module).Name} item not found.");
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
