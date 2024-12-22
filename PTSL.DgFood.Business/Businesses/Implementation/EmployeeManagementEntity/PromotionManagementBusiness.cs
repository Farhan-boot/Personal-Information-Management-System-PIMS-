using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation.EmployeeManagementEntity
{
    public class PromotionManagementBusiness : BaseBusiness<PromotionManagement>, IPromotionManagementBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PromotionManagementBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, PromotionManagement entity, string message)> CreateAsync(PromotionManagement entity)
        {
            (ExecutionState executionState, PromotionManagement entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<PromotionManagement> filterOptions = new FilterOptions<PromotionManagement>();
                    FilterOptions<PromotionPartculars> filterOptionsPromotionPartcular = new FilterOptions<PromotionPartculars>();
                    filterOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId && x.RunningStatus == true;
                    (ExecutionState executionState, PromotionManagement entity, string message) returnResponse = await _unitOfWork.GetAsync(filterOptions);
                    if (returnResponse.entity != null)
                    {
                        filterOptionsPromotionPartcular.FilterExpression = x => x.PromotionManagementId == returnResponse.entity.Id;
                        (ExecutionState executionState, PromotionPartculars entity, string message) returnPromotionParticularResponse = await _unitOfWork.GetAsync(filterOptionsPromotionPartcular);
                        returnPromotionParticularResponse.entity.PromotionStatus = false;
                        returnResponse.entity.RunningStatus = false;
                        returnResponse.entity.PromotionPartculars = returnPromotionParticularResponse.entity;
                        (ExecutionState executionState, PromotionManagement entity, string message) returnUpdateResponse = await UoW.UpdateAsync<PromotionManagement>(returnResponse.entity);
                    }


                    PromotionPartculars promotionPartculars = new PromotionPartculars();
                    promotionPartculars.PromotionStatus = true;
                    promotionPartculars.PresentPosting = entity.PresentPosting;
                    promotionPartculars.RankId = entity.RankId;
                    promotionPartculars.DesignationId = entity.DesignationId;
                    promotionPartculars.PromotionDate = entity.PromotionDate;
                    promotionPartculars.GONumber = entity.GONumber;
                    promotionPartculars.GODate = entity.GODate;
                    promotionPartculars.PayScale = entity.PayScale;
                    promotionPartculars.EmployeeInformationId = entity.EmployeeInformationId;
                    promotionPartculars.PromtionNatureId = entity.PromtionNatureId;
                    promotionPartculars.PayScaleYearInfoId = entity.PayScaleYearInfoId;
                    promotionPartculars.CreatedAt = DateTime.Now;
                    entity.PromotionPartculars = promotionPartculars;

                    (ExecutionState executionState, PromotionManagement entity, string message) createdResponse = await UoW.CreateAsync<PromotionManagement>(entity);

                    if (createdResponse.executionState == ExecutionState.Failure)
                    {
                        if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid validTransactionGuid))
                        {
                            UoW.Complete(transaction, CompletionState.Failure);
                        }

                        createResponse = createdResponse;
                    }
                    else
                    {
                        (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

                        bool success = (saveResponse.executionState == ExecutionState.Success);

                        #region Post validation
                        if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                        {
                            UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

                            createResponse = success ? createdResponse : (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

                        }
                        else
                        {
                            createResponse = (executionState: ExecutionState.Failure, entity: null, message: "Transaction not found.");
                        }
                        #endregion
                    }
                }
                catch
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(PromotionManagement).ToString()} creation.");
                }
            }

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, PromotionManagement entity, string message)> UpdateAsync(PromotionManagement entity)
        {
            (ExecutionState executionState, PromotionManagement entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<PromotionPartculars> filterOptionsPromotionPartcular = new FilterOptions<PromotionPartculars>();
                    filterOptionsPromotionPartcular.FilterExpression = x => x.PromotionManagementId == entity.Id;
                    (ExecutionState executionState, PromotionPartculars entity, string message) returnPromotionParticularResponse = await _unitOfWork.GetAsync(filterOptionsPromotionPartcular);

                    PromotionPartculars promotionPartculars = new PromotionPartculars();
                    promotionPartculars = returnPromotionParticularResponse.entity;
                    promotionPartculars.PromotionStatus = true;
                    promotionPartculars.PresentPosting = entity.PresentPosting;
                    promotionPartculars.RankId = entity.RankId;
                    promotionPartculars.DesignationId = entity.DesignationId;
                    promotionPartculars.PromotionDate = entity.PromotionDate;
                    promotionPartculars.GONumber = entity.GONumber;
                    promotionPartculars.GODate = entity.GODate;
                    promotionPartculars.PayScale = entity.PayScale;
                    promotionPartculars.EmployeeInformationId = entity.EmployeeInformationId;
                    promotionPartculars.PromtionNatureId = entity.PromtionNatureId;
                    promotionPartculars.PayScaleYearInfoId = entity.PayScaleYearInfoId;
                    promotionPartculars.UpdatedAt = DateTime.Now;
                    entity.PromotionPartculars = promotionPartculars;
                    entity.UpdatedAt = DateTime.Now;

                    (ExecutionState executionState, PromotionManagement entity, string message) updatedEntity = await UoW.UpdateAsync<PromotionManagement>(entity);

                    (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

                    bool success = saveResponse.executionState == ExecutionState.Success;

                    #region Post validation
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

                        updateResponse = success ? updatedEntity : (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

                    }
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entity: null, message: "Transaction not found.");
                    }
                    #endregion
                }
                catch
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(PromotionManagement).Name} update.");
                }
            }

            return updateResponse;
        }

        public virtual async Task<(ExecutionState executionState, IQueryable<PromotionManagement> entity, string message)> PromotionList(QueryOptions<PromotionManagement> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<PromotionManagement> entity, string message) returnResponse;

            queryOptions = new QueryOptions<PromotionManagement>();
            queryOptions.FilterExpression = x => x.RunningStatus == true;
            queryOptions.IncludeExpression = x => x.Include(y => y.Rank)
            .Include(y => y.Designation)
            .Include(y => y.EmployeeInformation)
            .Include(y => y.PromtionNature);

            (ExecutionState executionState, IQueryable<PromotionManagement> entity, string message) entityObject = await _unitOfWork.List<PromotionManagement>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, PromotionManagement entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PromotionManagement entity, string message) returnResponse;

            FilterOptions<PromotionManagement> filterOptions = new FilterOptions<PromotionManagement>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(x => x.Designation).Include(x => x.PromtionNature).Include(x => x.PayScaleYearInfo);
            (ExecutionState executionState, PromotionManagement entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

		public override Task<(ExecutionState executionState, IQueryable<PromotionManagement> entity, string message)> List(QueryOptions<PromotionManagement> queryOptions = null)
		{
			return base.List(new QueryOptions<PromotionManagement>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id),
            });
		}
	}
}
