using AutoMapper;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.BaseServices;
using PTSL.GENERIC.Business.Businesses.Interface.EmployeeManagementEntity;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.EmployeeManagementEntity
{
    public class UniversityInformationService : BaseService<UniversityInformationVM, UniversityInformation>, IUniversityInformationService
    {
        public IMapper _mapper;

        public UniversityInformationService(IUniversityInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override UniversityInformation CastModelToEntity(UniversityInformationVM model)
        {
            return _mapper.Map<UniversityInformation>(model);
        }

        public override UniversityInformationVM CastEntityToModel(UniversityInformation entity)
        {
            return _mapper.Map<UniversityInformationVM>(entity);
        }

        public override IList<UniversityInformationVM> CastEntityToModel(IQueryable<UniversityInformation> entity)
        {
            return _mapper.Map<IList<UniversityInformationVM>>(entity).ToList();
        }
    }
}