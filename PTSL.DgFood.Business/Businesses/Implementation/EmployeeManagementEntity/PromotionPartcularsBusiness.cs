using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class PromotionPartcularsBusiness : BaseBusiness<PromotionPartculars>, IPromotionPartcularsBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PromotionPartcularsBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, PromotionPartculars entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PromotionPartculars entity, string message) returnResponse;

            FilterOptions<PromotionPartculars> filterOptions = new FilterOptions<PromotionPartculars>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(x=>x.Designation).Include(x=>x.PromtionNature).Include(x => x.PayScaleYearInfo);
            (ExecutionState executionState, PromotionPartculars entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

            if (entityObject.entity != null)
            {
                returnResponse = entityObject;
            }
            else
            {
                returnResponse = entityObject;
            }


            return returnResponse;
        }

        public async Task<(ExecutionState executionState, List<PromotionParticularsListVM> entity, string message)> GetFilterData(QueryOptions<PromotionPartculars> queryOptions, PromotionPartcularsFilterVM entity)
        {
            (ExecutionState executionState, List<PromotionParticularsListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<PromotionPartculars>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.Designation).Include(x => x.Rank).Include(x => x.PromtionNature);
            (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) entityObject = await _unitOfWork.List<PromotionPartculars>(queryOptions);

            List<PromotionParticularsListVM> entityData = new List<PromotionParticularsListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    PromotionParticularsListVM tempData = new PromotionParticularsListVM();
                    tempData.Designation = data.Designation != null ? data.Designation.DesignationName : "";
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.NatureOfPromotion = data.PromtionNature != null ? data.PromtionNature.PromtionNatureName.ToString() : "";
                    tempData.PromotionDate = data.PromotionDate;
                    tempData.Rank = data.Rank != null ? data.Rank.RankName : "";
                    tempData.GODate = data.GODate;
                    tempData.GONumber = data.GONumber;
                    tempData.PayScale = data.PayScale;
                    tempData.PromotionStatus = data.PromotionStatus;
                    entityData.Add(tempData);
                }
            }

            returnResponse.entity = entityData;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }
    }
}
