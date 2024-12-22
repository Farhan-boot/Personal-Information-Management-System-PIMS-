using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class TrainingInformationManagementMasterBusiness : BaseBusiness<TrainingInformationManagementMaster>, ITrainingInformationManagementMasterBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public TrainingInformationManagementMasterBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> List(QueryOptions<TrainingInformationManagementMaster> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) returnResponse;

            queryOptions = new QueryOptions<TrainingInformationManagementMaster>();
            queryOptions.IncludeExpression = x => x.Include(i => i.TrainingInformationManagements).ThenInclude(x=>x.EmployeeInformation).Include(x => x.TrainingManagementType);
            queryOptions.SortingExpression = x => x.OrderByDescending(y => y.Id);

            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagementMaster>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public virtual async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> GetTrainingInformationByTrainingManagementTypeId(long id)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) returnResponse;

            QueryOptions<TrainingInformationManagementMaster> queryOptions = queryOptions = new QueryOptions<TrainingInformationManagementMaster>();
            queryOptions.FilterExpression = x => x.TrainingManagementTypeId == id && x.Status == false;
            queryOptions.IncludeExpression = x => x.Include(i => i.TrainingInformationManagements).Include(x => x.TrainingManagementType);

            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagementMaster>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        // FIX: Timeout happens often in this method (For exception see BaseRepository/GetAsync line:108)
        public override async Task<(ExecutionState executionState, TrainingInformationManagementMaster entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, TrainingInformationManagementMaster entity, string message) returnResponse;

            FilterOptions<TrainingInformationManagementMaster> filterOptions = new FilterOptions<TrainingInformationManagementMaster>();
            filterOptions.FilterExpression = x => x.Id == id;

            filterOptions.IncludeExpression = x =>
                x.Include(x => x.TrainingManagementType)
                .Include(i => i.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.PromotionPartculars)
                    .ThenInclude(x => x.Rank)
                .Include(x => x.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.PromotionPartculars)
                    .ThenInclude(x => x.Designation)
                .Include(x => x.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.OfficialInformation)
                    .ThenInclude(x => x.Posting)
                .Include(x => x.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.OfficialInformation)
                    .ThenInclude(x => x.RecruitPromo)
                .Include(x => x.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.OfficialInformation)
                    .ThenInclude(x => x.PresentRank)
                .Include(x => x.TrainingInformationManagements)
                    .ThenInclude(x => x.EmployeeInformation)
                    .ThenInclude(x => x.OfficialInformation)
                    .ThenInclude(x => x.PresentDesignation);
            /*
            filterOptions.IncludeExpression = x =>
                x.Include(y => y.TrainingManagementType)
                    .Include(y => y.TrainingInformationManagements)
                        .ThenInclude(x => x.EmployeeInformation.OfficialInformation)
                        .ThenInclude(x => new { x.Posting, x.RecruitPromo, x.PresentRank, x.PresentDesignation })
                    .Include(x => x.TrainingInformationManagements)
                        .ThenInclude(x => x.EmployeeInformation);
            */
             
            (ExecutionState executionState, TrainingInformationManagementMaster entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, TrainingInformationManagementMaster entity, string message)> GetByIdWithTrainingManagementAndType(long id)
        {
            (ExecutionState executionState, TrainingInformationManagementMaster entity, string message) returnResponse;

            FilterOptions<TrainingInformationManagementMaster> filterOptions = new FilterOptions<TrainingInformationManagementMaster>();
            filterOptions.FilterExpression = x => x.Id == id;

            filterOptions.IncludeExpression = x =>
                x.Include(x => x.TrainingManagementType)
                .Include(i => i.TrainingInformationManagements);
             
            (ExecutionState executionState, TrainingInformationManagementMaster entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagementMaster> queryOptions, TrainingInformationManagementMasterFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) returnResponse;

            queryOptions = new QueryOptions<TrainingInformationManagementMaster>();
            queryOptions.FilterExpression = x => x.TrainingManagementTypeId == entity.TrainingManagementTypeId;

            (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) entityObject = await _unitOfWork.List<TrainingInformationManagementMaster>(queryOptions);

            returnResponse = entityObject;

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message)> BulkUploadTraining(List<TrainingInformationManagementMaster> trainings)
        {
            var emptyList = new List<TrainingInformationManagementMaster>();

            try
            {
                await using IDbContextTransaction transaction = UoW.Begin();

                foreach (var training in trainings)
                {
                    await UoW.CreateAsync(training);
                }

                await UoW.SaveAsync(transaction);

                return (ExecutionState.Success, emptyList, "Data saved successfully.");;
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, emptyList, "Failed to save records.");;
            }
        }

        public async Task<(ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message)> GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter)
        {
            var queryOption = new QueryOptions<TrainingInformationManagementMaster>
            {
                IncludeExpression = x => x.Include(x => x.TrainingInformationManagements).Include(x => x.TrainingManagementType),
                FilterExpression =
                    x => x.TrainingManagementType.FromDate >= filter.FromDate
                    && x.TrainingManagementType.ToDate <= filter.ToDate
                    && x.Status == true
            };

            var result = await base.List(queryOption);

            if (result.entity != null)
            {
                return (result.executionState, result.entity.ToList(), result.message);
            }
            return (result.executionState, null, result.message);
        }
    }
}
