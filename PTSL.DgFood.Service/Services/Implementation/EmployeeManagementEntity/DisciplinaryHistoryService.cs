using AutoMapper;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSL.DgFood.Service.Services.Implementation.EmployeeManagementEntity
{
    public class DisciplinaryHistoryService : BaseService<DisciplinaryHistoryVM, DisciplinaryHistory>, IDisciplinaryHistoryService
    {
        public readonly IDisciplinaryHistoryBusiness _disciplinaryHistoryBusiness;
        public IMapper _mapper;
        public DisciplinaryHistoryService(IDisciplinaryHistoryBusiness disciplinaryHistoryBusiness, IMapper mapper) 
            : base(disciplinaryHistoryBusiness)
        {
            _disciplinaryHistoryBusiness = disciplinaryHistoryBusiness;
            _mapper = mapper;
        }

        public override DisciplinaryHistory CastModelToEntity(DisciplinaryHistoryVM model)
        {
            try
            {
                return _mapper.Map<DisciplinaryHistory>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DisciplinaryHistoryVM CastEntityToModel(DisciplinaryHistory entity)
        {
            try
            {
                DisciplinaryHistoryVM model = _mapper.Map<DisciplinaryHistoryVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DisciplinaryHistoryVM> CastEntityToModel(IQueryable<DisciplinaryHistory> entity)
        {
            try
            {
                IList<DisciplinaryHistoryVM> DisciplinaryHistoryList = _mapper.Map<IList<DisciplinaryHistoryVM>>(entity).ToList();
                return DisciplinaryHistoryList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
