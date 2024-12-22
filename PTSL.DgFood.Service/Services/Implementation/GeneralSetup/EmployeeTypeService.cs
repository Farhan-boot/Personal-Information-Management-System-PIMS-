using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class EmployeeTypeService : BaseService<EmployeeTypeVM, EmployeeType>, IEmployeeTypeService
    {
        public readonly IEmployeeTypeBusiness _EmployeeTypeBusiness;
        public IMapper _mapper;
        public EmployeeTypeService(IEmployeeTypeBusiness EmployeeTypeBusiness, IMapper mapper) : base(EmployeeTypeBusiness)
        {
            _EmployeeTypeBusiness = EmployeeTypeBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override EmployeeType CastModelToEntity(EmployeeTypeVM model)
        {
            try
            {
                return _mapper.Map<EmployeeType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override EmployeeTypeVM CastEntityToModel(EmployeeType entity)
        {
            try
            {
                EmployeeTypeVM model = _mapper.Map<EmployeeTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<EmployeeTypeVM> CastEntityToModel(IQueryable<EmployeeType> entity)
        {
            try
            {
                IList<EmployeeTypeVM> colorList = _mapper.Map<IList<EmployeeTypeVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
