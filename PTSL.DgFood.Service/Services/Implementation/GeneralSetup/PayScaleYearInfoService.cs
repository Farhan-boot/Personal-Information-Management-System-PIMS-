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
    public class PayScaleYearInfoService : BaseService<PayScaleYearInfoVM, PayScaleYearInfo>, IPayScaleYearInfoService
    {
        public readonly IPayScaleYearInfoBusiness _PayScaleYearInfoBusiness;
        public IMapper _mapper;
        public PayScaleYearInfoService(IPayScaleYearInfoBusiness PayScaleYearInfoBusiness, IMapper mapper) : base(PayScaleYearInfoBusiness)
        {
            _PayScaleYearInfoBusiness = PayScaleYearInfoBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PayScaleYearInfo CastModelToEntity(PayScaleYearInfoVM model)
        {
            try
            {
                return _mapper.Map<PayScaleYearInfo>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override PayScaleYearInfoVM CastEntityToModel(PayScaleYearInfo entity)
        {
            try
            {
                PayScaleYearInfoVM model = _mapper.Map<PayScaleYearInfoVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<PayScaleYearInfoVM> CastEntityToModel(IQueryable<PayScaleYearInfo> entity)
        {
            try
            {
                IList<PayScaleYearInfoVM> colorList = _mapper.Map<IList<PayScaleYearInfoVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
