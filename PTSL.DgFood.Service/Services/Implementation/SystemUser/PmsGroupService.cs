using AutoMapper;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSL.DgFood.Service.Services.Implementation
{
    public class PmsGroupService : BaseService<PmsGroupVM, PmsGroup>, IPmsGroupService
    {
        public readonly IPmsGroupBusiness _PmsGroupBusiness;
        public IMapper _mapper;
        public PmsGroupService(IPmsGroupBusiness PmsGroupBusiness, IMapper mapper) : base(PmsGroupBusiness)
        {
            _PmsGroupBusiness = PmsGroupBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PmsGroup CastModelToEntity(PmsGroupVM model)
        {
            try
            {
                return _mapper.Map<PmsGroup>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override PmsGroupVM CastEntityToModel(PmsGroup entity)
        {
            try
            {
                PmsGroupVM model = _mapper.Map<PmsGroupVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<PmsGroupVM> CastEntityToModel(IQueryable<PmsGroup> entity)
        {
            try
            {
                IList<PmsGroupVM> PmsGroupList = _mapper.Map<IList<PmsGroupVM>>(entity).ToList();
                return PmsGroupList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
