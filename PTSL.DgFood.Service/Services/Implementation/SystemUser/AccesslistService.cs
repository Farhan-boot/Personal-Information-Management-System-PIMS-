using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.DgFood.Service.Services.Implementation
{
    public class AccesslistService : BaseService<AccesslistVM, Accesslist>, IAccesslistService
    {
        public readonly IAccesslistBusiness _AccesslistBusiness;
        public IMapper _mapper;
        public AccesslistService(IAccesslistBusiness AccesslistBusiness, IMapper mapper) : base(AccesslistBusiness)
        {
            _AccesslistBusiness = AccesslistBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        
        public override Accesslist CastModelToEntity(AccesslistVM model)
        {
            try
            {
                return _mapper.Map<Accesslist>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override AccesslistVM CastEntityToModel(Accesslist entity)
        {
            try
            {
                AccesslistVM model = _mapper.Map<AccesslistVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<AccesslistVM> CastEntityToModel(IQueryable<Accesslist> entity)
        {
            try
            {
                IList<AccesslistVM> colorList = _mapper.Map<IList<AccesslistVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
