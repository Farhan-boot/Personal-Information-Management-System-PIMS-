using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.DAL.Repositories;
using PTSL.GENERIC.DAL.Repositories.Interface.EmployeeManagementEntity;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.EmployeeManagementEntity
{
    public class TrainingPlanRepository : BaseRepository<TrainingPlan>, ITrainingPlanRepository
    {
        public TrainingPlanRepository(
            DgFoodWriteOnlyCtx writeOnlyCtx,
            DgFoodReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}