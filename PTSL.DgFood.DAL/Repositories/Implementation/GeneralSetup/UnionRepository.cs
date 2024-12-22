using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.DAL.Repositories;
using PTSL.GENERIC.DAL.Repositories.Interface.GeneralSetup;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.GeneralSetup
{
    public class UnionRepository : BaseRepository<Union>, IUnionRepository
    {
        public UnionRepository(
            DgFoodWriteOnlyCtx writeOnlyCtx,
            DgFoodReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}