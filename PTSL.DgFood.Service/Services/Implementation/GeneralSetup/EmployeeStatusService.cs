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
using PTSL.DgFood.Business.Businesses.Implementation;

namespace PTSL.DgFood.Service.Services
{
    public class EmployeeStatusService : BaseService<EmployeeStatusVM, EmployeeStatus>, IEmployeeStatusService
    {
        public readonly IEmployeeStatusBusiness _EmployeeStatusBusiness;
        public IMapper _mapper;
        public EmployeeStatusService(IEmployeeStatusBusiness EmployeeStatusBusiness, IMapper mapper) : base(EmployeeStatusBusiness)
        {
            _EmployeeStatusBusiness = EmployeeStatusBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override EmployeeStatus CastModelToEntity(EmployeeStatusVM model)
        {
            try
            {
                return _mapper.Map<EmployeeStatus>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override EmployeeStatusVM CastEntityToModel(EmployeeStatus entity)
        {
            try
            {
                EmployeeStatusVM model = _mapper.Map<EmployeeStatusVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<EmployeeStatusVM> CastEntityToModel(IQueryable<EmployeeStatus> entity)
        {
            try
            {
                //IQueryable<EmployeeStatusVM> EmployeeStatusList = _mapper.Map<IQueryable<EmployeeStatusVM>>(entity).ToList();
                IList<EmployeeStatusVM> EmployeeStatusList = _mapper.Map<IList<EmployeeStatusVM>>(entity).ToList();
                return EmployeeStatusList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
