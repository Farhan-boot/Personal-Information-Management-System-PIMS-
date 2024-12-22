using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.GENERIC.Business.Businesses.Interface.GeneralSetup;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PTSL.GENERIC.Business.Businesses.Implementation.GeneralSetup
{
    public class UnionBusiness : BaseBusiness<Union>, IUnionBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public UnionBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> List(QueryOptions<Union> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Union> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Union>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Upazilla);
            queryOptions.SortingExpression = x => x.OrderByDescending(x => x.Id);

            (ExecutionState executionState, IQueryable<Union> entity, string message) entityObject = await _unitOfWork.List<Union>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Union entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Union entity, string message) returnResponse;

            FilterOptions<Union> filterOptions = new FilterOptions<Union>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Upazilla);
            (ExecutionState executionState, Union entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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