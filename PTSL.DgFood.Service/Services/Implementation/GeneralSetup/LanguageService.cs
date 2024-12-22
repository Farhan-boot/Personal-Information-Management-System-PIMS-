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
    public class LanguageService : BaseService<LanguageVM, Language>, ILanguageService
    {
        public readonly ILanguageBusiness _LanguageBusiness;
        public IMapper _mapper;
        public LanguageService(ILanguageBusiness LanguageBusiness, IMapper mapper) : base(LanguageBusiness)
        {
            _LanguageBusiness = LanguageBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Language CastModelToEntity(LanguageVM model)
        {
            try
            {
                return _mapper.Map<Language>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override LanguageVM CastEntityToModel(Language entity)
        {
            try
            {
                LanguageVM model = _mapper.Map<LanguageVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<LanguageVM> CastEntityToModel(IQueryable<Language> entity)
        {
            try
            {
                IList<LanguageVM> colorList = _mapper.Map<IList<LanguageVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
