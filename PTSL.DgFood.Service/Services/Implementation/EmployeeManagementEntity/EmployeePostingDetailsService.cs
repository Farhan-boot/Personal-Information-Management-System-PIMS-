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
    public class EmployeePostingDetailsService : BaseService<EmployeePostingDetailsVM, EmployeePostingDetails>, IEmployeePostingDetailsService
    {
        public IMapper _mapper;

        public EmployeePostingDetailsService(IEmployeePostingDetailsBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override EmployeePostingDetails CastModelToEntity(EmployeePostingDetailsVM model)
        {
            return _mapper.Map<EmployeePostingDetails>(model);
        }

        public override EmployeePostingDetailsVM CastEntityToModel(EmployeePostingDetails entity)
        {
            return _mapper.Map<EmployeePostingDetailsVM>(entity);
        }

        public override IList<EmployeePostingDetailsVM> CastEntityToModel(IQueryable<EmployeePostingDetails> entity)
        {
            return _mapper.Map<IList<EmployeePostingDetailsVM>>(entity).ToList();
        }
    }
}