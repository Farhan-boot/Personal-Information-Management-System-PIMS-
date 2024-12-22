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
    public class SpouseInformationService : BaseService<SpouseInformationVM, SpouseInformation>, ISpouseInformationService
    {
        public readonly ISpouseInformationBusiness _SpouseInformationBusiness;
        public IMapper _mapper;
        public SpouseInformationService(ISpouseInformationBusiness SpouseInformationBusiness, IMapper mapper) : base(SpouseInformationBusiness)
        {
            _SpouseInformationBusiness = SpouseInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<SpouseInformationListVM> entity, string message)> GetFilterData(QueryOptions<SpouseInformation> queryOptions, SpouseInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<SpouseInformationListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IList<SpouseInformationListVM> entity, string message) Getentity = await _SpouseInformationBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: Getentity.entity, message: Getentity.message);
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
        public override SpouseInformation CastModelToEntity(SpouseInformationVM model)
        {
            try
            {
                return _mapper.Map<SpouseInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override SpouseInformationVM CastEntityToModel(SpouseInformation entity)
        {
            try
            {
                SpouseInformationVM model = _mapper.Map<SpouseInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<SpouseInformationVM> CastEntityToModel(IQueryable<SpouseInformation> entity)
        {
            try
            {
                //IQueryable<SpouseInformationVM> SpouseInformationList = _mapper.Map<IQueryable<SpouseInformationVM>>(entity).ToList();
                IList<SpouseInformationVM> SpouseInformationList = _mapper.Map<IList<SpouseInformationVM>>(entity).ToList();
                return SpouseInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
