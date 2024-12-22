using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.BdArmy;
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
    public class RoutesDetailsService : BaseService<RoutesDetailsVM, RoutesDetails>, IRoutesDetailsService
    {
        public readonly IRoutesDetailsBusiness _RoutesDetailsBusiness;
        public IMapper _mapper;
        public RoutesDetailsService(IRoutesDetailsBusiness RoutesDetailsBusiness, IMapper mapper) : base(RoutesDetailsBusiness)
        {
            _RoutesDetailsBusiness = RoutesDetailsBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override RoutesDetails CastModelToEntity(RoutesDetailsVM model)
        {
            try
            {
                return _mapper.Map<RoutesDetails>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override RoutesDetailsVM CastEntityToModel(RoutesDetails entity)
        {
            try
            {
                RoutesDetailsVM model = _mapper.Map<RoutesDetailsVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<RoutesDetailsVM> CastEntityToModel(IQueryable<RoutesDetails> entity)
        {
            try
            {
                IList<RoutesDetailsVM> colorList = _mapper.Map<IList<RoutesDetailsVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
