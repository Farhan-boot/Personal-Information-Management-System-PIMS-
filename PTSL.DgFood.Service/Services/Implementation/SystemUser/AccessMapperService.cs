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
    public class AccessMapperService : BaseService<AccessMapperVM, AccessMapper>, IAccessMapperService
    {
        public readonly IAccessMapperBusiness _AccessMapperBusiness;
        public IMapper _mapper;
        public AccessMapperService(IAccessMapperBusiness AccessMapperBusiness, IMapper mapper) : base(AccessMapperBusiness)
        {
            _AccessMapperBusiness = AccessMapperBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

       
        public override AccessMapper CastModelToEntity(AccessMapperVM model)
        {
            try
            {
                return _mapper.Map<AccessMapper>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override AccessMapperVM CastEntityToModel(AccessMapper entity)
        {
            try
            {
                AccessMapperVM model = _mapper.Map<AccessMapperVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<AccessMapperVM> CastEntityToModel(IQueryable<AccessMapper> entity)
        {
            try
            {
                IList<AccessMapperVM> colorList = _mapper.Map<IList<AccessMapperVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
