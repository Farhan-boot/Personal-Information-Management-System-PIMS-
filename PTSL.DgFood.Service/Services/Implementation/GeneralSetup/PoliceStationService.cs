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
    public class PoliceStationService : BaseService<PoliceStationVM, PoliceStation>, IPoliceStationService
    {
        public readonly IPoliceStationBusiness _PoliceStationBusiness;
        public IMapper _mapper;
        public PoliceStationService(IPoliceStationBusiness PoliceStationBusiness, IMapper mapper) : base(PoliceStationBusiness)
        {
            _PoliceStationBusiness = PoliceStationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PoliceStation CastModelToEntity(PoliceStationVM model)
        {
            try
            {
                return _mapper.Map<PoliceStation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PoliceStationVM CastEntityToModel(PoliceStation entity)
        {
            try
            {
                PoliceStationVM model = _mapper.Map<PoliceStationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PoliceStationVM> CastEntityToModel(IQueryable<PoliceStation> entity)
        {
            try
            {
                //IQueryable<PoliceStationVM> PoliceStationList = _mapper.Map<IQueryable<PoliceStationVM>>(entity).ToList();
                IList<PoliceStationVM> PoliceStationList = _mapper.Map<IList<PoliceStationVM>>(entity).ToList();
                return PoliceStationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
