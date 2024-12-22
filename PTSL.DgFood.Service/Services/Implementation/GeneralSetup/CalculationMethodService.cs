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
    public class CalculationMethodService : BaseService<CalculationMethodVM, CalculationMethod>, ICalculationMethodService
    {
        public readonly ICalculationMethodBusiness _CalculationMethodBusiness;
        public IMapper _mapper;
        public CalculationMethodService(ICalculationMethodBusiness CalculationMethodBusiness, IMapper mapper) : base(CalculationMethodBusiness)
        {
            _CalculationMethodBusiness = CalculationMethodBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override CalculationMethod CastModelToEntity(CalculationMethodVM model)
        {
            try
            {
                return _mapper.Map<CalculationMethod>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override CalculationMethodVM CastEntityToModel(CalculationMethod entity)
        {
            try
            {
                CalculationMethodVM model = _mapper.Map<CalculationMethodVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<CalculationMethodVM> CastEntityToModel(IQueryable<CalculationMethod> entity)
        {
            try
            {
                IList<CalculationMethodVM> colorList = _mapper.Map<IList<CalculationMethodVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
