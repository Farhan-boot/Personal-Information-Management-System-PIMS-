using AutoMapper;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.BaseServices;
using PTSL.GENERIC.Business.Businesses.Interface.EmployeeManagementEntity;


using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.EmployeeManagementEntity
{
    public class TrainingPlanService : BaseService<TrainingPlanVM, TrainingPlan>, ITrainingPlanService
    {
        public IMapper _mapper;

        public TrainingPlanService(ITrainingPlanBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TrainingPlan CastModelToEntity(TrainingPlanVM model)
        {
            return _mapper.Map<TrainingPlan>(model);
        }

        public override TrainingPlanVM CastEntityToModel(TrainingPlan entity)
        {
            return _mapper.Map<TrainingPlanVM>(entity);
        }

        public override IList<TrainingPlanVM> CastEntityToModel(IQueryable<TrainingPlan> entity)
        {
            return _mapper.Map<IList<TrainingPlanVM>>(entity).ToList();
        }
    }
}