using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity
{
    public class PRLRepository : BaseRepository<PRL>, IPRLRepository
    {
        public PRLRepository(
            DgFoodWriteOnlyCtx ecommarceWriteOnlyCtx,
            DgFoodReadOnlyCtx ecommarceReadOnlyCtx)
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
    }
}