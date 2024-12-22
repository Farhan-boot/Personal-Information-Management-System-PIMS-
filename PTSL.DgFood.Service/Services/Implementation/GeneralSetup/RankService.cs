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
    public class RankService : BaseService<RankVM, Rank>, IRankService
    {
        public readonly IRankBusiness _RankBusiness;
        public IMapper _mapper;
        public RankService(IRankBusiness RankBusiness, IMapper mapper) : base(RankBusiness)
        {
            _RankBusiness = RankBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Rank CastModelToEntity(RankVM model)
        {
            try
            {
                return _mapper.Map<Rank>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override RankVM CastEntityToModel(Rank entity)
        {
            try
            {
                RankVM model = _mapper.Map<RankVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<RankVM> CastEntityToModel(IQueryable<Rank> entity)
        {
            try
            {
                //IQueryable<RankVM> RankList = _mapper.Map<IQueryable<RankVM>>(entity).ToList();
                IList<RankVM> RankList = _mapper.Map<IList<RankVM>>(entity).ToList();
                return RankList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
