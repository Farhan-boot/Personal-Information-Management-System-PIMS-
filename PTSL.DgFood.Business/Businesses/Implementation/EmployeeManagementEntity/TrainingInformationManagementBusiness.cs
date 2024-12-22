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
    public class TrainingInformationManagementBusiness : BaseBusiness<TrainingInformationManagement>, ITrainingInformationManagementBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public TrainingInformationManagementBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagement> queryOptions, TrainingInformationManagementFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) returnResponse;

            queryOptions = new QueryOptions<TrainingInformationManagement>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagement>(queryOptions);
            
            returnResponse = entityObject; 

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message)> GetByTrainingInformationManagementMasterId(long? id)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) returnResponse;

            QueryOptions<TrainingInformationManagement> queryOptions = new QueryOptions<TrainingInformationManagement>();
            queryOptions.FilterExpression = x => x.TrainingInformationManagementMasterId == id;
            queryOptions.IncludeExpression = x => x.Include(i => i.TrainingInformationManagementMaster).ThenInclude(x=>x.TrainingManagementType);

            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagement>(queryOptions);

            returnResponse = entityObject;

            return returnResponse;
        }


        //New add
        public override async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message)> List(QueryOptions<TrainingInformationManagement> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) returnResponse;

            queryOptions = new QueryOptions<TrainingInformationManagement>();
            queryOptions.IncludeExpression = x => x.Include(i => i.EmployeeInformation);

            (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagement>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }



    }
}
