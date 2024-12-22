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
    public class OfficialInformationBusiness : BaseBusiness<OfficialInformation>, IOfficialInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public OfficialInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(ExecutionState executionState, IQueryable<OfficialInformation> entity, string message)> GetFilterData(QueryOptions<OfficialInformation> queryOptions, OfficialInformationFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<OfficialInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) entityObject = await _unitOfWork.List<OfficialInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

	}
}
