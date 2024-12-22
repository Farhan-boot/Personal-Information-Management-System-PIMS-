using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.GENERIC.Business.Businesses.Interface.EmployeeManagementEntity;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation.EmployeeManagementEntity
{
    public class OtherTrainingMemberBusiness : BaseBusiness<OtherTrainingMember>, IOtherTrainingMemberBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public OtherTrainingMemberBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public override async Task<(ExecutionState executionState, OtherTrainingMember entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, OtherTrainingMember entity, string message) returnResponse;

            FilterOptions<OtherTrainingMember> filterOptions = new FilterOptions<OtherTrainingMember>();
            filterOptions.IncludeExpression = x => x.Include(i => i.TrainingManagementType);
            (ExecutionState executionState, OtherTrainingMember entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

            if (entityObject.entity != null)
            {
                returnResponse = entityObject;
            }
            else
            {
                returnResponse = entityObject;
            }


            return returnResponse;
        }


    }
}