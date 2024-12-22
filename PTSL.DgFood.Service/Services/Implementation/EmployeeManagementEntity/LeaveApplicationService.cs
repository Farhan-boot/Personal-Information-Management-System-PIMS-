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
    public class LeaveApplicationService : BaseService<LeaveApplicationVM, LeaveApplication>, ILeaveApplicationService
    {
        public readonly ILeaveApplicationBusiness _LeaveApplicationBusiness;
        public IMapper _mapper;
        public LeaveApplicationService(ILeaveApplicationBusiness LeaveApplicationBusiness, IMapper mapper) : base(LeaveApplicationBusiness)
        {
            _LeaveApplicationBusiness = LeaveApplicationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<LeaveApplicationVM> entity, string message)> GetFilterData(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationFilterVM entity)
        {
            (ExecutionState executionState, IList<LeaveApplicationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) Getentity = await _LeaveApplicationBusiness.GetFilterData(queryOptions, entity);

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

        public virtual async Task<(ExecutionState executionState, IList<LeaveApplicationVM> entity, string message)> GetByEmployeeId(QueryOptions<LeaveApplication> queryOptions, LeaveApplicationVM entity)
        {
            (ExecutionState executionState, IList<LeaveApplicationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<LeaveApplication> entity, string message) Getentity = await _LeaveApplicationBusiness.GetByEmployeeId(queryOptions, entity.EmployeeInformationId);

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
        public override LeaveApplication CastModelToEntity(LeaveApplicationVM model)
        {
            try
            {
                return _mapper.Map<LeaveApplication>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override LeaveApplicationVM CastEntityToModel(LeaveApplication entity)
        {
            try
            {
                LeaveApplicationVM model = _mapper.Map<LeaveApplicationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<LeaveApplicationVM> CastEntityToModel(IQueryable<LeaveApplication> entity)
        {
            try
            {
                //IQueryable<LeaveApplicationVM> LeaveApplicationList = _mapper.Map<IQueryable<LeaveApplicationVM>>(entity).ToList();
                IList<LeaveApplicationVM> LeaveApplicationList = _mapper.Map<IList<LeaveApplicationVM>>(entity).ToList();
                return LeaveApplicationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
