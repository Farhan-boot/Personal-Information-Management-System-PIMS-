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
    public class DesignationClassService : BaseService<DesignationClassVM, DesignationClass>, IDesignationClassService
    {
        public readonly IDesignationClassBusiness _DesignationClassBusiness;
        public IMapper _mapper;
        public DesignationClassService(IDesignationClassBusiness DesignationClassBusiness, IMapper mapper) : base(DesignationClassBusiness)
        {
            _DesignationClassBusiness = DesignationClassBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override DesignationClass CastModelToEntity(DesignationClassVM model)
        {
            try
            {
                return _mapper.Map<DesignationClass>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DesignationClassVM CastEntityToModel(DesignationClass entity)
        {
            try
            {
                DesignationClassVM model = _mapper.Map<DesignationClassVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DesignationClassVM> CastEntityToModel(IQueryable<DesignationClass> entity)
        {
            try
            {
                //IQueryable<DesignationClassVM> DesignationClassList = _mapper.Map<IQueryable<DesignationClassVM>>(entity).ToList();
                IList<DesignationClassVM> DesignationClassList = _mapper.Map<IList<DesignationClassVM>>(entity).ToList();
                return DesignationClassList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
