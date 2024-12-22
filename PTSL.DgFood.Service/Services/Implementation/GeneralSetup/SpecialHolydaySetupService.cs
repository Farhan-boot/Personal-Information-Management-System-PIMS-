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
    public class SpecialHolydaySetupService : BaseService<SpecialHolydaySetupVM, SpecialHolydaySetup>, ISpecialHolydaySetupService
    {
        public readonly ISpecialHolydaySetupBusiness _SpecialHolydaySetupBusiness;
        public IMapper _mapper;
        public SpecialHolydaySetupService(ISpecialHolydaySetupBusiness SpecialHolydaySetupBusiness, IMapper mapper) : base(SpecialHolydaySetupBusiness)
        {
            _SpecialHolydaySetupBusiness = SpecialHolydaySetupBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override SpecialHolydaySetup CastModelToEntity(SpecialHolydaySetupVM model)
        {
            try
            {
                return _mapper.Map<SpecialHolydaySetup>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override SpecialHolydaySetupVM CastEntityToModel(SpecialHolydaySetup entity)
        {
            try
            {
                SpecialHolydaySetupVM model = _mapper.Map<SpecialHolydaySetupVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<SpecialHolydaySetupVM> CastEntityToModel(IQueryable<SpecialHolydaySetup> entity)
        {
            try
            {
                IList<SpecialHolydaySetupVM> colorList = _mapper.Map<IList<SpecialHolydaySetupVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
