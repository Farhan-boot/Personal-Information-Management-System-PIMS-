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
    public class PresentStatusService : BaseService<PresentStatusVM, PresentStatus>, IPresentStatusService
    {
        public readonly IPresentStatusBusiness _PresentStatusBusiness;
        public IMapper _mapper;
        public PresentStatusService(IPresentStatusBusiness PresentStatusBusiness, IMapper mapper) : base(PresentStatusBusiness)
        {
            _PresentStatusBusiness = PresentStatusBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PresentStatus CastModelToEntity(PresentStatusVM model)
        {
            try
            {
                return _mapper.Map<PresentStatus>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PresentStatusVM CastEntityToModel(PresentStatus entity)
        {
            try
            {
                PresentStatusVM model = _mapper.Map<PresentStatusVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PresentStatusVM> CastEntityToModel(IQueryable<PresentStatus> entity)
        {
            try
            {
                //IQueryable<PresentStatusVM> PresentStatusList = _mapper.Map<IQueryable<PresentStatusVM>>(entity).ToList();
                IList<PresentStatusVM> PresentStatusList = _mapper.Map<IList<PresentStatusVM>>(entity).ToList();
                return PresentStatusList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
