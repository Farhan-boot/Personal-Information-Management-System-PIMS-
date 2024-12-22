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
    public class TrainingInformationService : BaseService<TrainingInformationVM, TrainingInformation>, ITrainingInformationService
    {
        public readonly ITrainingInformationBusiness _TrainingInformationBusiness;
        public IMapper _mapper;
        public TrainingInformationService(ITrainingInformationBusiness TrainingInformationBusiness, IMapper mapper) : base(TrainingInformationBusiness)
        {
            _TrainingInformationBusiness = TrainingInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<TrainingInfoListVM> entity, string message)> GetFilterData(QueryOptions<TrainingInformation> queryOptions, TrainingInformationFilterVM entity)
        {
            (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<TrainingInfoListVM> entity, string message) Getentity = await _TrainingInformationBusiness.GetFilterData(queryOptions, entity);

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
        public override TrainingInformation CastModelToEntity(TrainingInformationVM model)
        {
            try
            {
                return _mapper.Map<TrainingInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override TrainingInformationVM CastEntityToModel(TrainingInformation entity)
        {
            try
            {
                TrainingInformationVM model = _mapper.Map<TrainingInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<TrainingInformationVM> CastEntityToModel(IQueryable<TrainingInformation> entity)
        {
            try
            {
                //IQueryable<TrainingInformationVM> TrainingInformationList = _mapper.Map<IQueryable<TrainingInformationVM>>(entity).ToList();
                IList<TrainingInformationVM> TrainingInformationList = _mapper.Map<IList<TrainingInformationVM>>(entity).ToList();
                return TrainingInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
