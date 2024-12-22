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
    public class YearsService : BaseService<YearsVM, Years>, IYearsService
    {
        public readonly IYearsBusiness _YearsBusiness;
        public IMapper _mapper;
        public YearsService(IYearsBusiness YearsBusiness, IMapper mapper) : base(YearsBusiness)
        {
            _YearsBusiness = YearsBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Years CastModelToEntity(YearsVM model)
        {
            try
            {
                return _mapper.Map<Years>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override YearsVM CastEntityToModel(Years entity)
        {
            try
            {
                YearsVM model = _mapper.Map<YearsVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<YearsVM> CastEntityToModel(IQueryable<Years> entity)
        {
            try
            {
                IList<YearsVM> colorList = _mapper.Map<IList<YearsVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
