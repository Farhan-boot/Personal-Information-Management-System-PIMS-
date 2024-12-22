using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class EmployeeInformationCountService : BaseService<EmployeeInformationCountVM, EmployeeInformationCount>, IEmployeeInformationCountService
    {
        public readonly IEmployeeInformationCountBusiness _EmployeeInformationCountBusiness;
        public IMapper _mapper;
        public EmployeeInformationCountService(IEmployeeInformationCountBusiness EmployeeInformationCountBusiness, IMapper mapper) : base(EmployeeInformationCountBusiness)
        {
            _EmployeeInformationCountBusiness = EmployeeInformationCountBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override EmployeeInformationCount CastModelToEntity(EmployeeInformationCountVM model)
        {
            try
            {
                return _mapper.Map<EmployeeInformationCount>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override EmployeeInformationCountVM CastEntityToModel(EmployeeInformationCount entity)
        {
            try
            {
                EmployeeInformationCountVM model = _mapper.Map<EmployeeInformationCountVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<EmployeeInformationCountVM> CastEntityToModel(IQueryable<EmployeeInformationCount> entity)
        {
            try
            {
                IList<EmployeeInformationCountVM> colorList = _mapper.Map<IList<EmployeeInformationCountVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
