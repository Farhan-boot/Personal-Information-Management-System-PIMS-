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
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class SpecialHolydaySetupBusiness : BaseBusiness<SpecialHolydaySetup>, ISpecialHolydaySetupBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public SpecialHolydaySetupBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, SpecialHolydaySetup entity, string message)> CreateAsync(SpecialHolydaySetup entity)
        {
            (ExecutionState executionState, SpecialHolydaySetup entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<SpecialHolydaySetup> filterOptions = new FilterOptions<SpecialHolydaySetup>();
                    filterOptions.FilterExpression = x => x.SpecialHolydaySetupName.Trim() == entity.SpecialHolydaySetupName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.SpecialHolydaySetupName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(SpecialHolydaySetup).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, SpecialHolydaySetup entity, string message) createdResponse = await UoW.CreateAsync<SpecialHolydaySetup>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(SpecialHolydaySetup).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, SpecialHolydaySetup entity, string message)> UpdateAsync(SpecialHolydaySetup entity)
        {
            (ExecutionState executionState, SpecialHolydaySetup entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<SpecialHolydaySetup> filterOptions = new FilterOptions<SpecialHolydaySetup>();
                    filterOptions.FilterExpression = x => x.SpecialHolydaySetupName.Trim() == entity.SpecialHolydaySetupName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(SpecialHolydaySetup).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, SpecialHolydaySetup entity, string message) updatedEntity = await UoW.UpdateAsync<SpecialHolydaySetup>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(SpecialHolydaySetup).Name} update.");
                }
            }

            return updateResponse;
        }


        //public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        //{
        //    (ExecutionState executionState, string message) returnResponse;

        //    FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
        //    filterOptions.FilterExpression = x => x.SpecialHolydaySetupId == id;
        //    //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        //    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
        //    returnResponse = entityObject;
        //    return returnResponse;
        //}

    }
}
