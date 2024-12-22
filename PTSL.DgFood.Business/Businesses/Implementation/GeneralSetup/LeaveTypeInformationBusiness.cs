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
    public class LeaveTypeInformationBusiness : BaseBusiness<LeaveTypeInformation>, ILeaveTypeInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public LeaveTypeInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, LeaveTypeInformation entity, string message)> CreateAsync(LeaveTypeInformation entity)
        {
            (ExecutionState executionState, LeaveTypeInformation entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<LeaveTypeInformation> filterOptions = new FilterOptions<LeaveTypeInformation>();
                    filterOptions.FilterExpression = x => x.NameInBangla.Trim() == entity.NameInBangla.Trim() || x.NameInEnglish.Trim() == entity.NameInEnglish.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.NameInEnglish.Trim() == "" || entity.NameInBangla.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(LeaveTypeInformation).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, LeaveTypeInformation entity, string message) createdResponse = await UoW.CreateAsync<LeaveTypeInformation>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(LeaveTypeInformation).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, LeaveTypeInformation entity, string message)> UpdateAsync(LeaveTypeInformation entity)
        {
            (ExecutionState executionState, LeaveTypeInformation entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<LeaveTypeInformation> filterOptions = new FilterOptions<LeaveTypeInformation>();
                    filterOptions.FilterExpression = x => (x.NameInBangla.Trim() == entity.NameInBangla.Trim() || x.NameInEnglish.Trim() == entity.NameInEnglish.Trim()) && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(LeaveTypeInformation).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, LeaveTypeInformation entity, string message) updatedEntity = await UoW.UpdateAsync<LeaveTypeInformation>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(LeaveTypeInformation).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<LeaveTypeInformation> entity, string message)> List(QueryOptions<LeaveTypeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<LeaveTypeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<LeaveTypeInformation>();
            queryOptions.IncludeExpression = x => x.Include(i => i.CalculationMethod);
            queryOptions.SortingExpression = x => x.OrderByDescending(i => i.Id);

            (ExecutionState executionState, IQueryable<LeaveTypeInformation> entity, string message) entityObject = await _unitOfWork.List<LeaveTypeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, LeaveTypeInformation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, LeaveTypeInformation entity, string message) returnResponse;

            FilterOptions<LeaveTypeInformation> filterOptions = new FilterOptions<LeaveTypeInformation>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.CalculationMethod);
            (ExecutionState executionState, LeaveTypeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
        //public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        //{
        //    (ExecutionState executionState, string message) returnResponse;

        //    FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
        //    filterOptions.FilterExpression = x => x.LeaveTypeInformationId == id;
        //    //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        //    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
        //    returnResponse = entityObject;
        //    return returnResponse;
        //}

    }
}
