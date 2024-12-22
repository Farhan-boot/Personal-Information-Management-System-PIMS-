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
    public class PresentAddressBusiness : BaseBusiness<PresentAddress>, IPresentAddressBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PresentAddressBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

		public override Task<(ExecutionState executionState, IQueryable<PresentAddress> entity, string message)> List(QueryOptions<PresentAddress> queryOptions = null)
		{
			return base.List(new QueryOptions<PresentAddress>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
		}

		public override async Task<(ExecutionState executionState, PresentAddress entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PresentAddress entity, string message) returnResponse;

            FilterOptions<PresentAddress> filterOptions = new FilterOptions<PresentAddress>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District).Include(y => y.PoliceStation);
            (ExecutionState executionState, PresentAddress entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, List<PresentAddressListVM> entity, string message)> GetFilterData(QueryOptions<PresentAddress> queryOptions, PresentAddressFilterVM entity)
        {
            (ExecutionState executionState, List<PresentAddressListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<PresentAddress>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<PresentAddress> entity, string message) entityObject = await _unitOfWork.List<PresentAddress>(queryOptions);
            List<PresentAddressListVM> entityList = new List<PresentAddressListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    PresentAddressListVM tempData = new PresentAddressListVM();
                    tempData.AddressInBangla = data.VillageHouseNoAndRoadInBangla;
                    tempData.AddressInEnglish = data.VillageHouseNoAndRoadInEnglish;
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.PostOfficeInBangla = data.PostOfficeInBangla;
                    tempData.PostOfficeInEnglish = data.PostOfficeInEnglish;
                    entityList.Add(tempData);
                }
            }
            returnResponse.entity = entityList;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }
    }
}
