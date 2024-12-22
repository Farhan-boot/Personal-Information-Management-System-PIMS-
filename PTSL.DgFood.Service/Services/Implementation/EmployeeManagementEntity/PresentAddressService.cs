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
    public class PresentAddressService : BaseService<PresentAddressVM, PresentAddress>, IPresentAddressService
    {
        public readonly IPresentAddressBusiness _PresentAddressBusiness;
        public IMapper _mapper;
        public PresentAddressService(IPresentAddressBusiness PresentAddressBusiness, IMapper mapper) : base(PresentAddressBusiness)
        {
            _PresentAddressBusiness = PresentAddressBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<PresentAddressListVM> entity, string message)> GetFilterData(QueryOptions<PresentAddress> queryOptions, PresentAddressFilterVM entity)
        {
            (ExecutionState executionState, List<PresentAddressListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<PresentAddressListVM> entity, string message) Getentity = await _PresentAddressBusiness.GetFilterData(queryOptions, entity);

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
        public override PresentAddress CastModelToEntity(PresentAddressVM model)
        {
            try
            {
                return _mapper.Map<PresentAddress>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PresentAddressVM CastEntityToModel(PresentAddress entity)
        {
            try
            {
                PresentAddressVM model = _mapper.Map<PresentAddressVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PresentAddressVM> CastEntityToModel(IQueryable<PresentAddress> entity)
        {
            try
            {
                //IQueryable<PresentAddressVM> PresentAddressList = _mapper.Map<IQueryable<PresentAddressVM>>(entity).ToList();
                IList<PresentAddressVM> PresentAddressList = _mapper.Map<IList<PresentAddressVM>>(entity).ToList();
                return PresentAddressList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
