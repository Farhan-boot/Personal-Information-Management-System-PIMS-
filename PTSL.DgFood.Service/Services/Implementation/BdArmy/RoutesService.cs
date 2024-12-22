using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class RoutesService : BaseService<RoutesVM, Routes>, IRoutesService
    {
        public readonly IRoutesBusiness _RoutesBusiness;
        public IMapper _mapper;
        public RoutesService(IRoutesBusiness RoutesBusiness, IMapper mapper) : base(RoutesBusiness)
        {
            _RoutesBusiness = RoutesBusiness;
            _mapper = mapper;
        }

        public async Task<(ExecutionState executionState, RoutesVM entity, string message)> RoutesByUserId(Routes model)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, Routes entity, string message) recieveEntity = await _RoutesBusiness.RoutesByUserId(model);

                if (recieveEntity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: CastEntityToModel(recieveEntity.entity), message: recieveEntity.message);
                }
                else
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: null, message: recieveEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<RoutesVM> entity, string message)> GetFilterData(QueryOptions<Routes> queryOptions, RoutesVM entity)
        {
            (ExecutionState executionState, IList<RoutesVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<Routes> entity, string message) Getentity = await _RoutesBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
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


        public override Routes CastModelToEntity(RoutesVM model)
        {
            try
            {
                return _mapper.Map<Routes>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override RoutesVM CastEntityToModel(Routes entity)
        {
            try
            {
                RoutesVM model = _mapper.Map<RoutesVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<RoutesVM> CastEntityToModel(IQueryable<Routes> entity)
        {
            try
            {
                IList<RoutesVM> colorList = _mapper.Map<IList<RoutesVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
