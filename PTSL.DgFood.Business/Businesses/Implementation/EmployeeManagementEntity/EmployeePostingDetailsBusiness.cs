using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.GENERIC.Business.Businesses.Interface.EmployeeManagementEntity;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.EmployeeManagementEntity
{
    public class EmployeePostingDetailsBusiness : BaseBusiness<EmployeePostingDetails>, IEmployeePostingDetailsBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public EmployeePostingDetailsBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public override async Task<(ExecutionState executionState, IQueryable<EmployeePostingDetails> entity, string message)> List(QueryOptions<EmployeePostingDetails> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<EmployeePostingDetails> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeePostingDetails>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Posting).Include(x=>x.DesignationClass).Include(x=>x.EmployeeType);
            (ExecutionState executionState, IQueryable<EmployeePostingDetails> entity, string message) entityObject = await _unitOfWork.List<EmployeePostingDetails>(queryOptions);
            returnResponse = entityObject;
            return returnResponse;
        }




    }
}