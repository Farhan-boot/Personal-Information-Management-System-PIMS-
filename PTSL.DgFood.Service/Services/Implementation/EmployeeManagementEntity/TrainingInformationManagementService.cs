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
    public class TrainingInformationManagementService : BaseService<TrainingInformationManagementVM, TrainingInformationManagement>, ITrainingInformationManagementService
    {
        public readonly ITrainingInformationManagementBusiness _TrainingInformationManagementBusiness;
        public IMapper _mapper;
        public TrainingInformationManagementService(ITrainingInformationManagementBusiness TrainingInformationManagementBusiness, IMapper mapper) : base(TrainingInformationManagementBusiness)
        {
            _TrainingInformationManagementBusiness = TrainingInformationManagementBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public virtual async Task<(ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagement> queryOptions, TrainingInformationManagementFilterVM entity)
        {
            (ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) Getentity = await _TrainingInformationManagementBusiness.GetFilterData(queryOptions, entity);

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
        public virtual async Task<(ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message)> GetByTrainingInformationManagementMasterId(long? id)
        {
            (ExecutionState executionState, IList<TrainingInformationManagementVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<TrainingInformationManagement> entity, string message) Getentity = await _TrainingInformationManagementBusiness.GetByTrainingInformationManagementMasterId(id);

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
        

        public override TrainingInformationManagement CastModelToEntity(TrainingInformationManagementVM model)
        {
            try
            {
                return _mapper.Map<TrainingInformationManagement>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override TrainingInformationManagementVM CastEntityToModel(TrainingInformationManagement entity)
        {
            try
            {
                TrainingInformationManagementVM model = _mapper.Map<TrainingInformationManagementVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<TrainingInformationManagementVM> CastEntityToModel(IQueryable<TrainingInformationManagement> entity)
        {
            try
            {
                //IQueryable<TrainingInformationManagementVM> TrainingInformationManagementList = _mapper.Map<IQueryable<TrainingInformationManagementVM>>(entity).ToList();
                IList<TrainingInformationManagementVM> TrainingInformationManagementList = _mapper.Map<IList<TrainingInformationManagementVM>>(entity).ToList();
                return TrainingInformationManagementList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
