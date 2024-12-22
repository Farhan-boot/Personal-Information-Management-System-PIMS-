using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
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
    public class UserBusiness : BaseBusiness<User>, IUserBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public UserBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        //Implement System Busniess Logic here
        public async Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model)
        {
            (ExecutionState executionState, User entity, string message) returnResponse;

            //(ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.UserLogin(model);

            FilterOptions<User> filterOptions = new FilterOptions<User>();
            filterOptions.FilterExpression = x => x.UserEmail.ToLower() == model.UserEmail.ToLower() && x.UserPassword == model.UserPassword;

            (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.GetAsync(filterOptions, RetrievalPurpose.Consumption);

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

        //public async Task<(ExecutionState executionState, User entity, string message)> UserLists()
        //{
        //    (ExecutionState executionState, User entity, string message) returnResponse;

        //    //(ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.UserLogin(model);

        //    FilterOptions<User> filterOptions = new FilterOptions<User>();
        //    filterOptions.FilterExpression = x => x.IsActive == true && x.IsDeleted == false;

        //    (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.GetAsync(filterOptions, RetrievalPurpose.Consumption);

        //    if (entityObject.entity != null)
        //    {
        //        returnResponse = entityObject;
        //    }
        //    else
        //    {
        //        returnResponse = entityObject;
        //    }

        //    return returnResponse;
        //}
        public override async Task<(ExecutionState executionState, IQueryable<User> entity, string message)> List(QueryOptions<User> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<User> entity, string message) returnResponse;

            queryOptions = new QueryOptions<User>();
            queryOptions.IncludeExpression = x => x.Include(i => i.PmsGroup);
            queryOptions.SortingExpression = x => x.OrderByDescending(i => i.Id);

            (ExecutionState executionState, IQueryable<User> entity, string message) entityObject = await _unitOfWork.List<User>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, User entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, User entity, string message) returnResponse;

            FilterOptions<User> filterOptions = new FilterOptions<User>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.PmsGroup);
            (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public Task<(ExecutionState executionState, IQueryable<User> entity, string message)> EmployeeUserLists()
        {
            return base.List(new QueryOptions<User>
            {
                FilterExpression = e => e.EmployeeInformationId != null,
                IncludeExpression = e => e.Include(i => i.PmsGroup),
            });
        }

		public override Task<(ExecutionState executionState, User entity, string message)> CreateAsync(User entity)
		{
            if (entity.EmployeeInformationId == 0) entity.EmployeeInformationId = null;

			var result = base.CreateAsync(entity);

            return result;
		}
	}
}
