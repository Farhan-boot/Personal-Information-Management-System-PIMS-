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
    public class OtherTrainingMemberService : BaseService<OtherTrainingMemberVM, OtherTrainingMember>, IOtherTrainingMemberService
    {
        public IMapper _mapper;

        public OtherTrainingMemberService(IOtherTrainingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override OtherTrainingMember CastModelToEntity(OtherTrainingMemberVM model)
        {
            return _mapper.Map<OtherTrainingMember>(model);
        }

        public override OtherTrainingMemberVM CastEntityToModel(OtherTrainingMember entity)
        {
            return _mapper.Map<OtherTrainingMemberVM>(entity);
        }

        public override IList<OtherTrainingMemberVM> CastEntityToModel(IQueryable<OtherTrainingMember> entity)
        {
            return _mapper.Map<IList<OtherTrainingMemberVM>>(entity).ToList();
        }
    }
}