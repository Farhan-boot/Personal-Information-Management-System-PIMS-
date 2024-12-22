using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
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
    public class RankBusiness : BaseBusiness<Rank>, IRankBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public RankBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, Rank entity, string message)> CreateAsync(Rank entity)
        {
            (ExecutionState executionState, Rank entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Rank> filterOptions = new FilterOptions<Rank>();
                    filterOptions.FilterExpression = x => x.RankName.Trim() == entity.RankName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.RankName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Rank).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, Rank entity, string message) createdResponse = await UoW.CreateAsync<Rank>(entity);

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

                            createResponse = success ?
                                        createdResponse :
                                        (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Rank).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, Rank entity, string message)> UpdateAsync(Rank entity)
        {
            (ExecutionState executionState, Rank entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Rank> filterOptions = new FilterOptions<Rank>();
                    filterOptions.FilterExpression = x => x.RankName.Trim() == entity.RankName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Rank).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, Rank entity, string message) updatedEntity = await UoW.UpdateAsync<Rank>(entity);

                    (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

                    bool success = saveResponse.executionState == ExecutionState.Success;

                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

                        updateResponse = success ? updatedEntity : (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

                    }
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entity: null, message: "Transaction not found.");
                    }
                }
                catch
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Rank).Name} update.");
                }
            }

            return updateResponse;
        }

        public override async Task<(ExecutionState executionState, Rank entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Rank entity, string message) returnResponse;

            FilterOptions<Rank> filterOptions = new FilterOptions<Rank>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Designations);
            (ExecutionState executionState, Rank entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        {
        
        //check from designation
        (ExecutionState executionState, string message) returnResponse;
        FilterOptions<Designation> filterOptions = new FilterOptions<Designation>();
        filterOptions.FilterExpression = x => x.RankId == id;
        //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);            
        returnResponse = entityObject;
        if(returnResponse.executionState.ToString() == "Success")
        {
            return returnResponse;
        }
        //check from PromotionPartculars
        //(ExecutionState executionState, string message) returnResponsePromotion;
        FilterOptions<PromotionPartculars> filterOptions_promotions = new FilterOptions<PromotionPartculars>();
        filterOptions_promotions.FilterExpression = x => x.RankId == id;
        //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        (ExecutionState executionState, string message) entityObjectPromotion = await _unitOfWork.DoesExistAsync(filterOptions_promotions);
        returnResponse = entityObjectPromotion;
        if (returnResponse.executionState.ToString() == "Success")
        {
            return returnResponse;
        }
        //check from PostingRecords
        //(ExecutionState executionState, string message) returnResponsePostingRecords;
        FilterOptions<PostingRecords> filterOptions_PostingRecords = new FilterOptions<PostingRecords>();
        filterOptions_PostingRecords.FilterExpression = x => x.RankId == id;
        //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        (ExecutionState executionState, string message) entityObjectPostingRecords = await _unitOfWork.DoesExistAsync(filterOptions_PostingRecords);
        returnResponse = entityObjectPostingRecords;
        if (returnResponse.executionState.ToString() == "Success")
        {
            return returnResponse;
        }
        //check from OfficialInformation
        //(ExecutionState executionState, string message) returnResponseOfficialInformation;
        FilterOptions<OfficialInformation> filterOptions_OfficialInformation = new FilterOptions<OfficialInformation>();
        filterOptions_OfficialInformation.FilterExpression = x => x.JoiningRankId == id || x.PresentRankId == id;
        //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        (ExecutionState executionState, string message) entityObjectOfficialInformation = await _unitOfWork.DoesExistAsync(filterOptions_OfficialInformation);
        returnResponse = entityObjectOfficialInformation;
        if (returnResponse.executionState.ToString() == "Success")
        {
            return returnResponse;
        }
            return returnResponse;
        }

        /*
		public override Task<(ExecutionState executionState, IQueryable<Rank> entity, string message)> List(QueryOptions<Rank> queryOptions = null)
		{
			return base.List(new QueryOptions<Rank>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
		}
        */
	}
}
