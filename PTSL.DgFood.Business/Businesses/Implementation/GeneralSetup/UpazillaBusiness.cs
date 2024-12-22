using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class UpazillaBusiness : BaseBusiness<Upazilla>, IUpazillaBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public UpazillaBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, Upazilla entity, string message)> CreateAsync(Upazilla entity)
        {
            (ExecutionState executionState, Upazilla entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Upazilla> filterOptions = new FilterOptions<Upazilla>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.Name.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Upazilla).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, Upazilla entity, string message) createdResponse = await UoW.CreateAsync<Upazilla>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Upazilla).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, Upazilla entity, string message)> UpdateAsync(Upazilla entity)
        {
            (ExecutionState executionState, Upazilla entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Upazilla> filterOptions = new FilterOptions<Upazilla>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Upazilla).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, Upazilla entity, string message) updatedEntity = await UoW.UpdateAsync<Upazilla>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Upazilla).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<Upazilla> entity, string message)> List(QueryOptions<Upazilla> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Upazilla> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Upazilla>();
            queryOptions.IncludeExpression = x => x.Include(i => i.District);
            queryOptions.SortingExpression = x => x.OrderByDescending(x => x.Id);

            (ExecutionState executionState, IQueryable<Upazilla> entity, string message) entityObject = await _unitOfWork.List<Upazilla>(queryOptions);
            returnResponse = entityObject;
            
            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Upazilla entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Upazilla entity, string message) returnResponse;

            FilterOptions<Upazilla> filterOptions = new FilterOptions<Upazilla>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.District).Include(x=>x.Unions);
            (ExecutionState executionState, Upazilla entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
    }
}
