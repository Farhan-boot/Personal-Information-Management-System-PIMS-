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
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Business.Businesses.Implementation;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;

namespace PTSL.DgFood.Service.Services
{
    public class OfficialInformationService : BaseService<OfficialInformationVM, OfficialInformation>, IOfficialInformationService
    {
        public readonly IOfficialInformationBusiness _OfficialInformationBusiness;
        public IMapper _mapper;
        public OfficialInformationService(IOfficialInformationBusiness OfficialInformationBusiness, IMapper mapper) : base(OfficialInformationBusiness)
        {
            _OfficialInformationBusiness = OfficialInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<OfficialInformationVM> entity, string message)> GetFilterData(QueryOptions<OfficialInformation> queryOptions, OfficialInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<OfficialInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) Getentity = await _OfficialInformationBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        public override OfficialInformation CastModelToEntity(OfficialInformationVM model)
        {
            try
            {
                return _mapper.Map<OfficialInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override OfficialInformationVM CastEntityToModel(OfficialInformation entity)
        {
            try
            {
                OfficialInformationVM model = _mapper.Map<OfficialInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<OfficialInformationVM> CastEntityToModel(IQueryable<OfficialInformation> entity)
        {
            try
            {
                //IQueryable<OfficialInformationVM> OfficialInformationList = _mapper.Map<IQueryable<OfficialInformationVM>>(entity).ToList();
                IList<OfficialInformationVM> OfficialInformationList = _mapper.Map<IList<OfficialInformationVM>>(entity).ToList();
                return OfficialInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
