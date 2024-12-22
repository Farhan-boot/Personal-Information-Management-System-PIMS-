using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.GENERIC.DAL.Repositories.Interface.EmployeeManagementEntity;

namespace PTSL.DgFood.DAL.Repositories.Implementation.EmployeeManagementEntity
{
    public class OtherTrainingMemberRepository : BaseRepository<OtherTrainingMember>, IOtherTrainingMemberRepository
    {
        public OtherTrainingMemberRepository(
            DgFoodWriteOnlyCtx writeOnlyCtx,
            DgFoodReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}