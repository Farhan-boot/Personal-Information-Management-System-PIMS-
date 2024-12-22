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
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.DgFood.Service.Services.Implementation
{
    public class ModuleService : BaseService<ModuleVM, Module>, IModuleService
    {
        public readonly IModuleBusiness _ModuleBusiness;
        public IMapper _mapper;
        public ModuleService(IModuleBusiness ModuleBusiness, IMapper mapper) : base(ModuleBusiness)
        {
            _ModuleBusiness = ModuleBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        
        public override Module CastModelToEntity(ModuleVM model)
        {
            try
            {
                return _mapper.Map<Module>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override ModuleVM CastEntityToModel(Module entity)
        {
            try
            {
                ModuleVM model = _mapper.Map<ModuleVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<ModuleVM> CastEntityToModel(IQueryable<Module> entity)
        {
            try
            {
                IList<ModuleVM> colorList = _mapper.Map<IList<ModuleVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
