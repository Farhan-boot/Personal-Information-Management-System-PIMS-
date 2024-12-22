using AutoMapper;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.DgFood.Service.Services
{
    public class UpazillaService : BaseService<UpazillaVM, Upazilla>, IUpazillaService
    {
        public readonly IUpazillaBusiness _UpazillaBusiness;
        public IMapper _mapper;
        public UpazillaService(IUpazillaBusiness UpazillaBusiness, IMapper mapper) : base(UpazillaBusiness)
        {
            _UpazillaBusiness = UpazillaBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Upazilla CastModelToEntity(UpazillaVM model)
        {
            try
            {
                return _mapper.Map<Upazilla>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override UpazillaVM CastEntityToModel(Upazilla entity)
        {
            try
            {
                UpazillaVM model = _mapper.Map<UpazillaVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<UpazillaVM> CastEntityToModel(IQueryable<Upazilla> entity)
        {
            try
            {
                IList<UpazillaVM> DistrictList = _mapper.Map<IList<UpazillaVM>>(entity).ToList();
                return DistrictList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
