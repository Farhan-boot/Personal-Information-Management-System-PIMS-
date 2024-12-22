using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.DAL.Repositories.Interface;

namespace PTSL.DgFood.DAL.Repositories.Implementation
{
    public class UpazillaRepository : BaseRepository<Upazilla>, IUpazillaRepository
        {
            public UpazillaRepository(
                DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
                DgFoodReadOnlyCtx ecommarceReadOnlyCtx)
                : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
        }
}
