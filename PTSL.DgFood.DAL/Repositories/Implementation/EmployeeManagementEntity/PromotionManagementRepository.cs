using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity
{
    public class PromotionManagementRepository : BaseRepository<PromotionManagement>, IPromotionManagementRepository
    {
        public PromotionManagementRepository(
        DgFoodWriteOnlyCtx dgFoodWriteOnlyCtx,
        DgFoodReadOnlyCtx dgFoodReadOnlyCtx)
        : base(dgFoodWriteOnlyCtx, dgFoodReadOnlyCtx) { }
    }
}
