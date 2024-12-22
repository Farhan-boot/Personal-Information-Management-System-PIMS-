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
    public class GradationTypeService : BaseService<GradationTypeVM, GradationType>, IGradationTypeService
    {
        public readonly IGradationTypeBusiness _GradationTypeBusiness;
        public IMapper _mapper;
        public GradationTypeService(IGradationTypeBusiness GradationTypeBusiness, IMapper mapper) : base(GradationTypeBusiness)
        {
            _GradationTypeBusiness = GradationTypeBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override GradationType CastModelToEntity(GradationTypeVM model)
        {
            try
            {
                return _mapper.Map<GradationType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override GradationTypeVM CastEntityToModel(GradationType entity)
        {
            try
            {
                GradationTypeVM model = _mapper.Map<GradationTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<GradationTypeVM> CastEntityToModel(IQueryable<GradationType> entity)
        {
            try
            {
                IList<GradationTypeVM> colorList = _mapper.Map<IList<GradationTypeVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
