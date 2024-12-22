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
    public class LeaveTypeInformationService : BaseService<LeaveTypeInformationVM, LeaveTypeInformation>, ILeaveTypeInformationService
    {
        public readonly ILeaveTypeInformationBusiness _LeaveTypeInformationBusiness;
        public IMapper _mapper;
        public LeaveTypeInformationService(ILeaveTypeInformationBusiness LeaveTypeInformationBusiness, IMapper mapper) : base(LeaveTypeInformationBusiness)
        {
            _LeaveTypeInformationBusiness = LeaveTypeInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override LeaveTypeInformation CastModelToEntity(LeaveTypeInformationVM model)
        {
            try
            {
                return _mapper.Map<LeaveTypeInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override LeaveTypeInformationVM CastEntityToModel(LeaveTypeInformation entity)
        {
            try
            {
                LeaveTypeInformationVM model = _mapper.Map<LeaveTypeInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<LeaveTypeInformationVM> CastEntityToModel(IQueryable<LeaveTypeInformation> entity)
        {
            try
            {
                IList<LeaveTypeInformationVM> colorList = _mapper.Map<IList<LeaveTypeInformationVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
