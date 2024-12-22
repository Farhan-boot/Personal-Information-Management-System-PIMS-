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
    public class RoutesBusiness : BaseBusiness<Routes>, IRoutesBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public RoutesBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(ExecutionState executionState, Routes entity, string message)> RoutesByUserId(Routes model)
        {
            (ExecutionState executionState, Routes entity, string message) returnResponse;

            //(ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.UserLogin(model);

            FilterOptions<Routes> filterOptions = new FilterOptions<Routes>();
            if(model.CreatedAt.Date > Convert.ToDateTime("01-01-2021"))
            {
                filterOptions.FilterExpression = x => x.UserId == model.UserId && Convert.ToDateTime(x.CreatedAt.Date) == Convert.ToDateTime(model.CreatedAt.Date) && x.IsArrived == false;
            }
            else
            {
                filterOptions.FilterExpression = x => x.UserId == model.UserId && x.IsArrived == false;
            }
            filterOptions.IncludeExpression = x => x.Include(i => i.RoutesDetails);
            //(ExecutionState executionState, RoutesVM entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);
            (ExecutionState executionState, Routes entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);
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


        public override async Task<(ExecutionState executionState, IQueryable<Routes> entity, string message)> List(QueryOptions<Routes> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Routes> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Routes>();
            queryOptions.IncludeExpression = x => x.Include(i => i.RoutesDetails);

            (ExecutionState executionState, IQueryable<Routes> entity, string message) entityObject = await _unitOfWork.List<Routes>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Routes entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Routes entity, string message) returnResponse;

            FilterOptions<Routes> filterOptions = new FilterOptions<Routes>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.RoutesDetails);
            (ExecutionState executionState, Routes entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, IQueryable<Routes> entity, string message)> GetFilterData(QueryOptions<Routes> queryOptions, RoutesVM entity)
        {
            (ExecutionState executionState, IQueryable<Routes> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Routes>();
            if (entity.CreatedAt.Date > Convert.ToDateTime("01-01-2021"))
            {
                queryOptions.FilterExpression = x => x.UserId == entity.UserId && Convert.ToDateTime(x.CreatedAt.Date) == Convert.ToDateTime(entity.CreatedAt.Date);// && x.IsArrived == false;
            }
            else
            {
                queryOptions.FilterExpression = x => x.UserId == entity.UserId;// && x.IsArrived == false;
            }
            queryOptions.IncludeExpression = x => x.Include(i => i.RoutesDetails);

            (ExecutionState executionState, IQueryable<Routes> entity, string message) entityObject = await _unitOfWork.List<Routes>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

    }
}
