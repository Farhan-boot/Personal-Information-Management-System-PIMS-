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
    public class PromotionPartcularsService : BaseService<PromotionPartcularsVM, PromotionPartculars>, IPromotionPartcularsService
    {
        public readonly IPromotionPartcularsBusiness _PromotionPartcularsBusiness;
        public IMapper _mapper;
        public PromotionPartcularsService(IPromotionPartcularsBusiness PromotionPartcularsBusiness, IMapper mapper) : base(PromotionPartcularsBusiness)
        {
            _PromotionPartcularsBusiness = PromotionPartcularsBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<PromotionParticularsListVM> entity, string message)> GetFilterData(QueryOptions<PromotionPartculars> queryOptions, PromotionPartcularsFilterVM entity)
        {
            (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) Getentity = await _PromotionPartcularsBusiness.GetFilterData(queryOptions, entity);

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
        public override PromotionPartculars CastModelToEntity(PromotionPartcularsVM model)
        {
            try
            {
                return _mapper.Map<PromotionPartculars>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PromotionPartcularsVM CastEntityToModel(PromotionPartculars entity)
        {
            try
            {
                PromotionPartcularsVM model = _mapper.Map<PromotionPartcularsVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PromotionPartcularsVM> CastEntityToModel(IQueryable<PromotionPartculars> entity)
        {
            try
            {
                //IQueryable<PromotionPartcularsVM> PromotionPartcularsList = _mapper.Map<IQueryable<PromotionPartcularsVM>>(entity).ToList();
                IList<PromotionPartcularsVM> PromotionPartcularsList = _mapper.Map<IList<PromotionPartcularsVM>>(entity).ToList();
                return PromotionPartcularsList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
