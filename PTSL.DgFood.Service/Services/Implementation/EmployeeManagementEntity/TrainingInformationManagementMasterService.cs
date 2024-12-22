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
using Microsoft.EntityFrameworkCore;

namespace PTSL.DgFood.Service.Services
{
    public class TrainingInformationManagementMasterService : BaseService<TrainingInformationManagementMasterVM, TrainingInformationManagementMaster>, ITrainingInformationManagementMasterService
    {
        public readonly ITrainingInformationManagementMasterBusiness _TrainingInformationManagementMasterBusiness;
        public IMapper _mapper;
        public TrainingInformationManagementMasterService(ITrainingInformationManagementMasterBusiness TrainingInformationManagementMasterBusiness, IMapper mapper) : base(TrainingInformationManagementMasterBusiness)
        {
            _TrainingInformationManagementMasterBusiness = TrainingInformationManagementMasterBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> List(QueryOptions<TrainingInformationManagementMaster> queryOptions)
        {
            (ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) Getentity = await _TrainingInformationManagementMasterBusiness.List(queryOptions);

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


        public virtual async Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformationManagementMaster> queryOptions, TrainingInformationManagementMasterFilterVM entity)
        {
            (ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) Getentity = await _TrainingInformationManagementMasterBusiness.GetFilterData(queryOptions, entity);

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

        public virtual async Task<(ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message)> GetTrainingInformationByTrainingManagementTypeId(long id)
        {
            (ExecutionState executionState, IList<TrainingInformationManagementMasterVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<TrainingInformationManagementMaster> entity, string message) Getentity = await _TrainingInformationManagementMasterBusiness.GetTrainingInformationByTrainingManagementTypeId(id);

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


        public override TrainingInformationManagementMaster CastModelToEntity(TrainingInformationManagementMasterVM model)
        {
            try
            {
                return _mapper.Map<TrainingInformationManagementMaster>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override TrainingInformationManagementMasterVM CastEntityToModel(TrainingInformationManagementMaster entity)
        {
            try
            {
                TrainingInformationManagementMasterVM model = _mapper.Map<TrainingInformationManagementMasterVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<TrainingInformationManagementMasterVM> CastEntityToModel(IQueryable<TrainingInformationManagementMaster> entity)
        {
            try
            {
                //IQueryable<TrainingInformationManagementMasterVM> TrainingInformationManagementMasterList = _mapper.Map<IQueryable<TrainingInformationManagementMasterVM>>(entity).ToList();
                IList<TrainingInformationManagementMasterVM> TrainingInformationManagementMasterList = _mapper.Map<IList<TrainingInformationManagementMasterVM>>(entity).ToList();
                return TrainingInformationManagementMasterList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TrainingInformationManagementMaster> CastModelsToEntities(List<TrainingInformationManagementMasterVM> model)
        {
            try
            {
                return _mapper.Map<List<TrainingInformationManagementMaster>>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TrainingInformationManagementMasterVM> CastEntitiesToModels(List<TrainingInformationManagementMaster> model)
        {
            try
            {
                return _mapper.Map<List<TrainingInformationManagementMasterVM>>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message)> BulkUploadTraining(List<TrainingInformationManagementMasterVM> trainingInformationManagements)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;

            try
            {
                var trainings = CastModelsToEntities(trainingInformationManagements);

                (ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message) response = await _TrainingInformationManagementMasterBusiness.BulkUploadTraining(trainings);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: response.executionState, entity: CastEntitiesToModels(response.entity), message: response.message);
                }
                else
                {
                    returnResponse = (executionState: response.executionState, entity: null, message: response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message)> GetByIdWithTrainingManagementAndType(long id)
        {
            (ExecutionState executionState, TrainingInformationManagementMasterVM entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, TrainingInformationManagementMaster entity, string message) response = await _TrainingInformationManagementMasterBusiness.GetByIdWithTrainingManagementAndType(id);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: response.executionState, entity: CastEntityToModel(response.entity), response.message);
                }
                else
                {
                    returnResponse = (executionState: response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message)> GetCompletedByFromToDate(GetTrainingFilterDataByDateVM filter)
        {
            (ExecutionState executionState, List<TrainingInformationManagementMasterVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, List<TrainingInformationManagementMaster> entity, string message) response = await _TrainingInformationManagementMasterBusiness.GetCompletedByFromToDate(filter);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: response.executionState, entity: CastEntitiesToModels(response.entity), response.message);
                }
                else
                {
                    returnResponse = (executionState: response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
    }
}
