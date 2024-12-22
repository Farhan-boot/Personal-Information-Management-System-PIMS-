using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
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
    public class LeaveApplicationBusiness : BaseBusiness<LeaveApplication>, ILeaveApplicationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public LeaveApplicationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, IQueryable<LeaveApplication> entity, string message)> List(QueryOptions<LeaveApplication> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) returnResponse;

            queryOptions = new QueryOptions<LeaveApplication>();
            queryOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x=>x.EmployeeInformation);
            queryOptions.SortingExpression = x => x.OrderByDescending(x => x.Id);

            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) entityObject = await _unitOfWork.List<LeaveApplication>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IQueryable<LeaveApplication> entity, string message)> GetByEmployeeId(QueryOptions<LeaveApplication> queryOptions, long EmployeeInformationId)
        {
            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) returnResponse;

            queryOptions = new QueryOptions<LeaveApplication>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x => x.EmployeeInformation);

            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) entityObject = await _unitOfWork.List<LeaveApplication>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<LeaveApplication> entity, string message)> GetFilterData(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) returnResponse;

            queryOptions = new QueryOptions<LeaveApplication>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x => x.EmployeeInformation);
            queryOptions.SortingExpression = x => x.OrderByDescending(x => x.Id);

            (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) entityObject = await _unitOfWork.List<LeaveApplication>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        
        public override async Task<(ExecutionState executionState, LeaveApplication entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, LeaveApplication entity, string message) returnResponse;

            FilterOptions<LeaveApplication> filterOptions = new FilterOptions<LeaveApplication>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x => x.EmployeeInformation);
            (ExecutionState executionState, LeaveApplication entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
