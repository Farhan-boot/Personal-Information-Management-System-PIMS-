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
    public class DistrictService : BaseService<DistrictVM, District>, IDistrictService
    {
        public readonly IDistrictBusiness _DistrictBusiness;
        public IMapper _mapper;
        public DistrictService(IDistrictBusiness DistrictBusiness, IMapper mapper) : base(DistrictBusiness)
        {
            _DistrictBusiness = DistrictBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override District CastModelToEntity(DistrictVM model)
        {
            try
            {
                return _mapper.Map<District>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DistrictVM CastEntityToModel(District entity)
        {
            try
            {
                DistrictVM model = _mapper.Map<DistrictVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DistrictVM> CastEntityToModel(IQueryable<District> entity)
        {
            try
            {
                //IQueryable<DistrictVM> DistrictList = _mapper.Map<IQueryable<DistrictVM>>(entity).ToList();
                IList<DistrictVM> DistrictList = _mapper.Map<IList<DistrictVM>>(entity).ToList();
                return DistrictList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
