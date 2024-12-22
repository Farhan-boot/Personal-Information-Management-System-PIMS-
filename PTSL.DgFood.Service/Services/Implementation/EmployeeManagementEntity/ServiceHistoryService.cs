using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Business;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Business.Businesses.Implementation;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;

namespace PTSL.DgFood.Service.Services
{
    public class ServiceHistoryService : BaseService<ServiceHistoryVM, ServiceHistory>, IServiceHistoryService
    {
        public readonly IServiceHistoryBusiness _ServiceHistoryBusiness;
        public IMapper _mapper;
        public ServiceHistoryService(IServiceHistoryBusiness ServiceHistoryBusiness, IMapper mapper) : base(ServiceHistoryBusiness)
        {
            _ServiceHistoryBusiness = ServiceHistoryBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<ServiceHistoryListVM> entity, string message)> GetFilterData(QueryOptions<ServiceHistory> queryOptions, ServiceHistoryFilterVM entity)
        {
            (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<ServiceHistoryListVM> entity, string message) Getentity = await _ServiceHistoryBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: Getentity.entity, message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        public override ServiceHistory CastModelToEntity(ServiceHistoryVM model)
        {
            try
            {
                return _mapper.Map<ServiceHistory>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override ServiceHistoryVM CastEntityToModel(ServiceHistory entity)
        {
            try
            {
                ServiceHistoryVM model = _mapper.Map<ServiceHistoryVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<ServiceHistoryVM> CastEntityToModel(IQueryable<ServiceHistory> entity)
        {
            try
            {
                //IQueryable<ServiceHistoryVM> ServiceHistoryList = _mapper.Map<IQueryable<ServiceHistoryVM>>(entity).ToList();
                IList<ServiceHistoryVM> ServiceHistoryList = _mapper.Map<IList<ServiceHistoryVM>>(entity).ToList();
                return ServiceHistoryList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
