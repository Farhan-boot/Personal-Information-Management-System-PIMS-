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

namespace PTSL.DgFood.Service.Services
{
    public class PromtionNatureService : BaseService<PromtionNatureVM, PromtionNature>, IPromtionNatureService
    {
        public readonly IPromtionNatureBusiness _PromtionNatureBusiness;
        public IMapper _mapper;
        public PromtionNatureService(IPromtionNatureBusiness PromtionNatureBusiness, IMapper mapper) : base(PromtionNatureBusiness)
        {
            _PromtionNatureBusiness = PromtionNatureBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PromtionNature CastModelToEntity(PromtionNatureVM model)
        {
            try
            {
                return _mapper.Map<PromtionNature>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PromtionNatureVM CastEntityToModel(PromtionNature entity)
        {
            try
            {
                PromtionNatureVM model = _mapper.Map<PromtionNatureVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PromtionNatureVM> CastEntityToModel(IQueryable<PromtionNature> entity)
        {
            try
            {
                //IQueryable<PromtionNatureVM> PromtionNatureList = _mapper.Map<IQueryable<PromtionNatureVM>>(entity).ToList();
                IList<PromtionNatureVM> PromtionNatureList = _mapper.Map<IList<PromtionNatureVM>>(entity).ToList();
                return PromtionNatureList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
