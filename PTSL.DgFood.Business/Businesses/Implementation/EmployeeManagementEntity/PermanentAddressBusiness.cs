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
    public class PermanentAddressBusiness : BaseBusiness<PermanentAddress>, IPermanentAddressBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PermanentAddressBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, PermanentAddress entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PermanentAddress entity, string message) returnResponse;

            FilterOptions<PermanentAddress> filterOptions = new FilterOptions<PermanentAddress>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District).Include(y=>y.PoliceStation);
            (ExecutionState executionState, PermanentAddress entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, List<PermanentAddressListVM> entity, string message)> GetFilterData(QueryOptions<PermanentAddress> queryOptions, PermanentAddressFilterVM entity)
        {
            (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<PermanentAddress>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<PermanentAddress> entity, string message) entityObject = await _unitOfWork.List<PermanentAddress>(queryOptions);

            List<PermanentAddressListVM> entityData = new List<PermanentAddressListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    PermanentAddressListVM tempData = new PermanentAddressListVM();
                    tempData.AddressInBangla = data.VillageHouseNoAndRoadInBangla;
                    tempData.AddressInEnglish = data.VillageHouseNoAndRoadInEnglish;
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.PostOfficeInBangla = data.PostOfficeInBangla;
                    tempData.PostOfficeInEnglish = data.PostOfficeInEnglish;
                    entityData.Add(tempData);
                }
            }
            returnResponse.entity = entityData;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }

		public override Task<(ExecutionState executionState, IQueryable<PermanentAddress> entity, string message)> List(QueryOptions<PermanentAddress> queryOptions = null)
		{
			return base.List(new QueryOptions<PermanentAddress>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
		}
	}
}
