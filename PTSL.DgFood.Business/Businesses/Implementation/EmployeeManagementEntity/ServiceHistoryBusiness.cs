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
    public class ServiceHistoryBusiness : BaseBusiness<ServiceHistory>, IServiceHistoryBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public ServiceHistoryBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(ExecutionState executionState, List<ServiceHistoryListVM> entity, string message)> GetFilterData(QueryOptions<ServiceHistory> queryOptions, ServiceHistoryFilterVM entity)
        {
            (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<ServiceHistory>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<ServiceHistory> entity, string message) entityObject = await _unitOfWork.List<ServiceHistory>(queryOptions);
            List<ServiceHistoryListVM> entityData = new List<ServiceHistoryListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    ServiceHistoryListVM tempData = new ServiceHistoryListVM();
                    tempData.DateOfGazatted = data.DateOfGazetted;
                    tempData.DateOfGovtService = data.DateOfGovtService;
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.EncadrementDate = data.EncadrementDate;
                    tempData.EncadrementNumber = data.EncadrementNumber;
                    tempData.Id = data.Id;
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
