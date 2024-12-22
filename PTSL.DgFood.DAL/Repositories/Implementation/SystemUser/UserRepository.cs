using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> WriteOnlySet;
        private readonly DbSet<User> ReadOnlySet;
        private DgFoodWriteOnlyCtx _ecommarceWriteOnlyCtx { get; }
        private DgFoodReadOnlyCtx _ecommarceReadOnlyCtx { get; }

        public UserRepository(
            DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
            DgFoodReadOnlyCtx ecommarceReadOnlyCtx
            )
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx)
        {
            this._ecommarceWriteOnlyCtx = ecommarceWriteOnlyCtx;
            this._ecommarceReadOnlyCtx = ecommarceReadOnlyCtx;

            this.WriteOnlySet = this._ecommarceWriteOnlyCtx.Set<User>();
            this.ReadOnlySet = this._ecommarceReadOnlyCtx.Set<User>();
        }

        //public async Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model)
        //{
        //    (ExecutionState executionState, User entity, string message) getResponse;

        //    try
        //    {
        //        User user1 = ReadOnlySet.FirstOrDefault(x => x.UserEmail.Trim() == model.UserEmail.Trim() 
        //        && x.UserPassword == model.UserPassword);


        //        User user = _ecommarceReadOnlyCtx.Users.FirstOrDefault
        //            (
        //             x => x.UserEmail.Trim() == model.UserEmail.Trim() &&
        //            x.UserPassword == model.UserPassword);

        //        if (user != null)
        //        {
        //            getResponse = (executionState: ExecutionState.Retrieved, user, message: $"{typeof(User).Name} item found.");
        //        }
        //        else
        //        {
        //            getResponse = (executionState: ExecutionState.Failure, null, $"{typeof(User).Name} item not found.");
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
