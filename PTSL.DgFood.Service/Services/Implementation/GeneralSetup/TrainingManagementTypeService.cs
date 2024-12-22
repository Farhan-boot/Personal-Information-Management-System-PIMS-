using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class TrainingManagementTypeService : BaseService<TrainingManagementTypeVM, TrainingManagementType>, ITrainingManagementTypeService
    {
        public readonly ITrainingManagementTypeBusiness _TrainingManagementTypeBusiness;
        public IMapper _mapper;
        public TrainingManagementTypeService(ITrainingManagementTypeBusiness TrainingManagementTypeBusiness, IMapper mapper) : base(TrainingManagementTypeBusiness)
        {
            _TrainingManagementTypeBusiness = TrainingManagementTypeBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override TrainingManagementType CastModelToEntity(TrainingManagementTypeVM model)
        {
            try
            {
                return _mapper.Map<TrainingManagementType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override TrainingManagementTypeVM CastEntityToModel(TrainingManagementType entity)
        {
            try
            {
                TrainingManagementTypeVM model = _mapper.Map<TrainingManagementTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<TrainingManagementTypeVM> CastEntityToModel(IQueryable<TrainingManagementType> entity)
        {
            try
            {
                IList<TrainingManagementTypeVM> colorList = _mapper.Map<IList<TrainingManagementTypeVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<TrainingManagementTypeVM> entity, string message)> ListLatest(int take)
        {
            try
            {
                var data = await _TrainingManagementTypeBusiness.ListLatest(take);

				return (data.executionState, _mapper.Map<List<TrainingManagementTypeVM>>(data.entity), data.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
