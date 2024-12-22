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
    public class WeeklyHolydaySetupService : BaseService<WeeklyHolydaySetupVM, WeeklyHolydaySetup>, IWeeklyHolydaySetupService
    {
        public readonly IWeeklyHolydaySetupBusiness _WeeklyHolydaySetupBusiness;
        public IMapper _mapper;
        public WeeklyHolydaySetupService(IWeeklyHolydaySetupBusiness WeeklyHolydaySetupBusiness, IMapper mapper) : base(WeeklyHolydaySetupBusiness)
        {
            _WeeklyHolydaySetupBusiness = WeeklyHolydaySetupBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override WeeklyHolydaySetup CastModelToEntity(WeeklyHolydaySetupVM model)
        {
            try
            {
                return _mapper.Map<WeeklyHolydaySetup>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override WeeklyHolydaySetupVM CastEntityToModel(WeeklyHolydaySetup entity)
        {
            try
            {
                WeeklyHolydaySetupVM model = _mapper.Map<WeeklyHolydaySetupVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<WeeklyHolydaySetupVM> CastEntityToModel(IQueryable<WeeklyHolydaySetup> entity)
        {
            try
            {
                IList<WeeklyHolydaySetupVM> colorList = _mapper.Map<IList<WeeklyHolydaySetupVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
