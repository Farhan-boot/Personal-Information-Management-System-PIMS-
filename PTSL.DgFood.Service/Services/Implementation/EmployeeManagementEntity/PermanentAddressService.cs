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
    public class PermanentAddressService : BaseService<PermanentAddressVM, PermanentAddress>, IPermanentAddressService
    {
        public readonly IPermanentAddressBusiness _PermanentAddressBusiness;
        public IMapper _mapper;
        public PermanentAddressService(IPermanentAddressBusiness PermanentAddressBusiness, IMapper mapper) : base(PermanentAddressBusiness)
        {
            _PermanentAddressBusiness = PermanentAddressBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<PermanentAddressListVM> entity, string message)> GetFilterData(QueryOptions<PermanentAddress> queryOptions, PermanentAddressFilterVM entity)
        {
            (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<PermanentAddressListVM> entity, string message) Getentity = await _PermanentAddressBusiness.GetFilterData(queryOptions, entity);

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
        public override PermanentAddress CastModelToEntity(PermanentAddressVM model)
        {
            try
            {
                return _mapper.Map<PermanentAddress>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PermanentAddressVM CastEntityToModel(PermanentAddress entity)
        {
            try
            {
                PermanentAddressVM model = _mapper.Map<PermanentAddressVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PermanentAddressVM> CastEntityToModel(IQueryable<PermanentAddress> entity)
        {
            try
            {
                //IQueryable<PermanentAddressVM> PermanentAddressList = _mapper.Map<IQueryable<PermanentAddressVM>>(entity).ToList();
                IList<PermanentAddressVM> PermanentAddressList = _mapper.Map<IList<PermanentAddressVM>>(entity).ToList();
                return PermanentAddressList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
