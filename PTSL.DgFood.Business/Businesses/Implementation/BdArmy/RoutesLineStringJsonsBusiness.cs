using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class RoutesLineStringJsonsBusiness : BaseBusiness<RoutesLineStringJsons>, IRoutesLineStringJsonsBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public RoutesLineStringJsonsBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, IQueryable<RoutesLineStringJsons> entity, string message)> List(QueryOptions<RoutesLineStringJsons> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<RoutesLineStringJsons> entity, string message) returnResponse;

            queryOptions = new QueryOptions<RoutesLineStringJsons>();
            //queryOptions.IncludeExpression = x => x.Include(i => i.RoutesLineStringJsonsDetails);

            (ExecutionState executionState, IQueryable<RoutesLineStringJsons> entity, string message) entityObject = await _unitOfWork.List<RoutesLineStringJsons>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, RoutesLineStringJsons entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, RoutesLineStringJsons entity, string message) returnResponse;

            FilterOptions<RoutesLineStringJsons> filterOptions = new FilterOptions<RoutesLineStringJsons>();
            filterOptions.FilterExpression = x => x.Id == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.RoutesLineStringJsonsDetails);
            (ExecutionState executionState, RoutesLineStringJsons entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
