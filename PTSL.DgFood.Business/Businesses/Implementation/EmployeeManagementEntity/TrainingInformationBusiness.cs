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
    public class TrainingInformationBusiness : BaseBusiness<TrainingInformation>, ITrainingInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public TrainingInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(ExecutionState executionState, List<TrainingInfoListVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformation> queryOptions, TrainingInformationFilterVM entity)
        {
            (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<TrainingInformation>();

            if (entity.EmployeeInformationId != 0)
            {
                queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            }
            if (entity.TrainingFromDate != null)
            {
                queryOptions.FilterExpression = x => x.FromDate >= entity.TrainingFromDate;
            }
            if (entity.TrainingToDate != null)
            {
                queryOptions.FilterExpression = x => x.ToDate <= entity.TrainingToDate;
            }

            (ExecutionState executionState, IQueryable<TrainingInformation> entity, string message) entityObject = await _unitOfWork.List<TrainingInformation>(queryOptions);
            List<TrainingInfoListVM> entityData = new List<TrainingInfoListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    TrainingInfoListVM tempData = new TrainingInfoListVM();
                    tempData.CourseTitle = data.CourseTitle;
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.InstituteName = data.Institute;
                    tempData.PeriodFrom = data.FromDate;
                    tempData.PeriodTo = data.ToDate;
                    entityData.Add(tempData);

                }
            }
            returnResponse.entity = entityData;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }
    }
}
