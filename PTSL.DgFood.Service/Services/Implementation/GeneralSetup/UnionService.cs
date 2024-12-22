using AutoMapper;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Business.Businesses.Interface.GeneralSetup;

namespace PTSL.GENERIC.Service.Services.GeneralSetup
{
    public class UnionService : BaseService<UnionVM, Union>, IUnionService
    {
        public IMapper _mapper;

        public UnionService(IUnionBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Union CastModelToEntity(UnionVM model)
        {
            return _mapper.Map<Union>(model);
        }

        public override UnionVM CastEntityToModel(Union entity)
        {
            return _mapper.Map<UnionVM>(entity);
        }

        public override IList<UnionVM> CastEntityToModel(IQueryable<Union> entity)
        {
            return _mapper.Map<IList<UnionVM>>(entity).ToList();
        }
    }
}