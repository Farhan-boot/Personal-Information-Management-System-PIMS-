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
    public class WeeklyHolydaySetupBusiness : BaseBusiness<WeeklyHolydaySetup>, IWeeklyHolydaySetupBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public WeeklyHolydaySetupBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, WeeklyHolydaySetup entity, string message)> CreateAsync(WeeklyHolydaySetup entity)
        {
            (ExecutionState executionState, WeeklyHolydaySetup entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<WeeklyHolydaySetup> filterOptions = new FilterOptions<WeeklyHolydaySetup>();
                    filterOptions.FilterExpression = x => x.Day == entity.Day && x.YearsId == entity.YearsId && x.HolidayDate == entity.HolidayDate;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(WeeklyHolydaySetup).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, WeeklyHolydaySetup entity, string message) createdResponse = await UoW.CreateAsync<WeeklyHolydaySetup>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(WeeklyHolydaySetup).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, WeeklyHolydaySetup entity, string message)> UpdateAsync(WeeklyHolydaySetup entity)
        {
            (ExecutionState executionState, WeeklyHolydaySetup entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<WeeklyHolydaySetup> filterOptions = new FilterOptions<WeeklyHolydaySetup>();
                    filterOptions.FilterExpression = x => (x.Day == entity.Day && x.YearsId == entity.YearsId && x.HolidayDate == entity.HolidayDate) && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(WeeklyHolydaySetup).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, WeeklyHolydaySetup entity, string message) updatedEntity = await UoW.UpdateAsync<WeeklyHolydaySetup>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(WeeklyHolydaySetup).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<WeeklyHolydaySetup> entity, string message)> List(QueryOptions<WeeklyHolydaySetup> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<WeeklyHolydaySetup> entity, string message) returnResponse;

            queryOptions = new QueryOptions<WeeklyHolydaySetup>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Years);
            queryOptions.SortingExpression = x => x.OrderByDescending(i => i.Id);

            (ExecutionState executionState, IQueryable<WeeklyHolydaySetup> entity, string message) entityObject = await _unitOfWork.List<WeeklyHolydaySetup>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }


        public override async Task<(ExecutionState executionState, WeeklyHolydaySetup entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, WeeklyHolydaySetup entity, string message) returnResponse;

            FilterOptions<WeeklyHolydaySetup> filterOptions = new FilterOptions<WeeklyHolydaySetup>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Years) ;
            (ExecutionState executionState, WeeklyHolydaySetup entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
        //    filterOptions.FilterExpression = x => x.WeeklyHolydaySetupId == id;
        //    //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        //    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
        //    returnResponse = entityObject;
        //    return returnResponse;
        //}

    }
}
