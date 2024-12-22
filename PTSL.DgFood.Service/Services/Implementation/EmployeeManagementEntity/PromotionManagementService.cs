using AutoMapper;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Implementation.EmployeeManagementEntity
{
    public class PromotionManagementService : BaseService<PromotionManagementVM, PromotionManagement>, IPromotionManagementService
    {
        public readonly IPromotionManagementBusiness _PromotionManagementBusiness;
        public IMapper _mapper;
        public PromotionManagementService(IPromotionManagementBusiness PromotionManagementBusiness, IMapper mapper) : base(PromotionManagementBusiness)
        {
            _PromotionManagementBusiness = PromotionManagementBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        //public virtual async Task<(ExecutionState executionState, List<PromotionManagementListVM> entity, string message)> GetFilterData(QueryOptions<PromotionManagement> queryOptions, PromotionManagementFilterVM entity)
        //{
        //    (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) returnResponse;
        //    try
        //    {
        //        (ExecutionState executionState, List<PromotionManagementListVM> entity, string message) Getentity = await _PromotionManagementBusiness.GetFilterData(queryOptions, entity);

        //        if (Getentity.executionState == ExecutionState.Retrieved)
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: Getentity.entity, message: Getentity.message);
        //        }
        //        else
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
        //    }

        //    return returnResponse;
        //}
        public virtual async Task<(ExecutionState executionState, IList<PromotionManagementListVM> entity, string message)> PromotionList(QueryOptions<PromotionManagement> queryOptions = null)
        {
            (ExecutionState executionState, IList<PromotionManagementListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<PromotionManagement> entity, string message) Getentity = await _PromotionManagementBusiness.PromotionList(queryOptions);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: CastPromoEntityToPromoList(Getentity.entity), message: Getentity.message);
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
        public override PromotionManagement CastModelToEntity(PromotionManagementVM model)
        {
            try
            {
                return _mapper.Map<PromotionManagement>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PromotionManagementVM CastEntityToModel(PromotionManagement entity)
        {
            try
            {
                PromotionManagementVM model = _mapper.Map<PromotionManagementVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PromotionManagementVM> CastEntityToModel(IQueryable<PromotionManagement> entity)
        {
            try
            {
                IList<PromotionManagementVM> PromotionManagementList = _mapper.Map<IList<PromotionManagementVM>>(entity).ToList();
                return PromotionManagementList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region ModelBinding
        public List<PromotionManagementListVM> CastPromoEntityToPromoList(IQueryable<PromotionManagement> entity)
        {
            List<PromotionManagementListVM> promotionlist = new List<PromotionManagementListVM>();
            foreach (var data in entity.ToList())
            {
                PromotionManagementListVM promotionManagementList = new PromotionManagementListVM();
                promotionManagementList.Id = data.Id;
                promotionManagementList.EmployeeInformationId = data.EmployeeInformationId;
                promotionManagementList.EmployeeName = data.EmployeeInformation.NameEnglish;
                promotionManagementList.Rank = data.Rank.RankName;
                promotionManagementList.Designation = data.Designation.DesignationName;
                promotionManagementList.PromotionDate = data.PromotionDate;
                promotionManagementList.GODate = data.GODate;
                promotionManagementList.NatureOfPromotion = data.PromtionNature.PromtionNatureName;
                promotionManagementList.PayScale = data.PayScale;
                promotionlist.Add(promotionManagementList);

            }
            return promotionlist;
        }
        #endregion
    }
}
