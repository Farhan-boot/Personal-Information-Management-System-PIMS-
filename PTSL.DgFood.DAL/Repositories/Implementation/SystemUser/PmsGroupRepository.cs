using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.DAL.Repositories.Implementation
{
    public class PmsGroupRepository : BaseRepository<PmsGroup>, IPmsGroupRepository
    {
        public PmsGroupRepository(
        DgFoodWriteOnlyCtx dgFoodWriteOnlyCtx,
        DgFoodReadOnlyCtx dgFoodReadOnlyCtx)
        : base(dgFoodWriteOnlyCtx, dgFoodReadOnlyCtx) { }
    }
}
