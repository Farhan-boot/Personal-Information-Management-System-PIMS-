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
    public class PostingBusiness : BaseBusiness<Posting>, IPostingBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PostingBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, Posting entity, string message)> CreateAsync(Posting entity)
        {
            (ExecutionState executionState, Posting entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Posting> filterOptions = new FilterOptions<Posting>();
                    filterOptions.FilterExpression = x => x.PostingName.Trim() == entity.PostingName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.PostingName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Posting).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, Posting entity, string message) createdResponse = await UoW.CreateAsync<Posting>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Posting).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, Posting entity, string message)> UpdateAsync(Posting entity)
        {
            (ExecutionState executionState, Posting entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Posting> filterOptions = new FilterOptions<Posting>();
                    filterOptions.FilterExpression = x => x.PostingName.Trim() == entity.PostingName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Posting).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, Posting entity, string message) updatedEntity = await UoW.UpdateAsync<Posting>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Posting).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<Posting> entity, string message)> List(QueryOptions<Posting> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Posting> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Posting>();
            queryOptions.IncludeExpression = x => x.Include(i => i.PostingType);
            //queryOptions.SortingExpression = x => x.OrderByDescending(i => i.Id);

            (ExecutionState executionState, IQueryable<Posting> entity, string message) entityObject = await _unitOfWork.List<Posting>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Posting entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Posting entity, string message) returnResponse;

            FilterOptions<Posting> filterOptions = new FilterOptions<Posting>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.PostingType);
            (ExecutionState executionState, Posting entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

            FilterOptions<PostingRecords> filterOptions = new FilterOptions<PostingRecords>();
            filterOptions.FilterExpression = x => x.PostingId == id || x.DepPostingId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<EmployeeTransfer> filterOptions_EmployeeTransfer = new FilterOptions<EmployeeTransfer>();
            filterOptions_EmployeeTransfer.FilterExpression = x => x.PostingId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_EmployeeTransfer = await _unitOfWork.DoesExistAsync(filterOptions_EmployeeTransfer);
            returnResponse = entityObject_EmployeeTransfer;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<OfficialInformation> filterOptions_OfficialInformation = new FilterOptions<OfficialInformation>();
            filterOptions_OfficialInformation.FilterExpression = x => x.PostingId == id || x.DepPostingId == id || x.JoinPostingId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_OfficialInformation = await _unitOfWork.DoesExistAsync(filterOptions_OfficialInformation);
            returnResponse = entityObject_OfficialInformation;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            return returnResponse;
        }

    }
}
