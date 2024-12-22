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
    public class EmployeeTransferService : BaseService<EmployeeTransferVM, EmployeeTransfer>, IEmployeeTransferService
    {
        public readonly IEmployeeTransferBusiness _EmployeeTransferBusiness;
        public IMapper _mapper;
        public EmployeeTransferService(IEmployeeTransferBusiness EmployeeTransferBusiness, IMapper mapper) : base(EmployeeTransferBusiness)
        {
            _EmployeeTransferBusiness = EmployeeTransferBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<EmployeeTransferVM> entity, string message)> GetFilterData(QueryOptions<EmployeeTransfer> queryOptions, EmployeeTransferFilterVM entity)
        {
            (ExecutionState executionState, IList<EmployeeTransferVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<EmployeeTransfer> entity, string message) Getentity = await _EmployeeTransferBusiness.GetFilterData(queryOptions, entity);

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
        public override EmployeeTransfer CastModelToEntity(EmployeeTransferVM model)
        {
            try
            {
                return _mapper.Map<EmployeeTransfer>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override EmployeeTransferVM CastEntityToModel(EmployeeTransfer entity)
        {
            try
            {
                EmployeeTransferVM model = _mapper.Map<EmployeeTransferVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<EmployeeTransferVM> CastEntityToModel(IQueryable<EmployeeTransfer> entity)
        {
            try
            {
                //IQueryable<EmployeeTransferVM> EmployeeTransferList = _mapper.Map<IQueryable<EmployeeTransferVM>>(entity).ToList();
                IList<EmployeeTransferVM> EmployeeTransferList = _mapper.Map<IList<EmployeeTransferVM>>(entity).ToList();
                return EmployeeTransferList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
