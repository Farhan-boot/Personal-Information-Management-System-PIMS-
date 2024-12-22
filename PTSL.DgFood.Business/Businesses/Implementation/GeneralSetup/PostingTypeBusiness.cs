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
    public class PostingTypeBusiness : BaseBusiness<PostingType>, IPostingTypeBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PostingTypeBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, PostingType entity, string message)> CreateAsync(PostingType entity)
        {
            (ExecutionState executionState, PostingType entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<PostingType> filterOptions = new FilterOptions<PostingType>();
                    filterOptions.FilterExpression = x => x.PostingTypeName.Trim() == entity.PostingTypeName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.PostingTypeName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(PostingType).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, PostingType entity, string message) createdResponse = await UoW.CreateAsync<PostingType>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(PostingType).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, PostingType entity, string message)> UpdateAsync(PostingType entity)
        {
            (ExecutionState executionState, PostingType entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<PostingType> filterOptions = new FilterOptions<PostingType>();
                    filterOptions.FilterExpression = x => x.PostingTypeName.Trim() == entity.PostingTypeName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(PostingType).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, PostingType entity, string message) updatedEntity = await UoW.UpdateAsync<PostingType>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(PostingType).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, PostingType entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PostingType entity, string message) returnResponse;

            FilterOptions<PostingType> filterOptions = new FilterOptions<PostingType>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Postings);
            (ExecutionState executionState, PostingType entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

            (ExecutionState executionState, string message) returnResponse;

            FilterOptions<Posting> filterOptions = new FilterOptions<Posting>();
            filterOptions.FilterExpression = x => x.PostingTypeId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<EmployeeTransfer> filterOptions_EmployeeTransfer = new FilterOptions<EmployeeTransfer>();
            filterOptions_EmployeeTransfer.FilterExpression = x => x.MainPostingTypeId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_EmployeeTransfer = await _unitOfWork.DoesExistAsync(filterOptions_EmployeeTransfer);
            returnResponse = entityObject_EmployeeTransfer;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<OfficialInformation> filterOptions_OfficialInformation = new FilterOptions<OfficialInformation>();
            filterOptions_OfficialInformation.FilterExpression = x => x.PostingTypeId == id || x.DeppostingTypeId == id || x.JoinPostingTypeId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_OfficialInformation = await _unitOfWork.DoesExistAsync(filterOptions_OfficialInformation);
            returnResponse = entityObject_OfficialInformation;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<PostingRecords> filterOptions_PostingRecords = new FilterOptions<PostingRecords>();
            filterOptions_PostingRecords.FilterExpression = x => x.MainPostingTypeId == id || x.DeppostingTypeId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_PostingRecords = await _unitOfWork.DoesExistAsync(filterOptions_PostingRecords);
            returnResponse = entityObject_PostingRecords;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            return returnResponse;
        }


        /*
		public override Task<(ExecutionState executionState, IQueryable<PostingType> entity, string message)> List(QueryOptions<PostingType> queryOptions = null)
		{
			return base.List(new QueryOptions<PostingType>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
		}
        */
	}
}
