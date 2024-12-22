using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
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
    
        public class RoutesDetailsRepository : BaseRepository<RoutesDetails>, IRoutesDetailsRepository
        {
            public RoutesDetailsRepository(
                DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
                DgFoodReadOnlyCtx ecommarceReadOnlyCtx)
                : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
        }
    
}
