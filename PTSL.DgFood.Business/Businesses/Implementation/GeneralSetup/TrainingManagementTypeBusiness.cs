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
    public class TrainingManagementTypeBusiness : BaseBusiness<TrainingManagementType>, ITrainingManagementTypeBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
		private readonly DgFoodReadOnlyCtx _readOnlyCtx;

		public TrainingManagementTypeBusiness(DgFoodUnitOfWork unitOfWork, DgFoodReadOnlyCtx readOnlyCtx)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
			_readOnlyCtx = readOnlyCtx;
		}

        public override async Task<(ExecutionState executionState, TrainingManagementType entity, string message)> CreateAsync(TrainingManagementType entity)
        {
            (ExecutionState executionState, TrainingManagementType entity, string message) createResponse;
            
            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<TrainingManagementType> filterOptions = new FilterOptions<TrainingManagementType>();
                    filterOptions.FilterExpression = x => x.TrainingTitle.Trim() == entity.TrainingTitle.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if(entityObject.executionState.ToString() == "Success" || entity.TrainingTitle.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(TrainingManagementType).Name} name already exists.");
                        return createResponse;
                    }
                    
                    (ExecutionState executionState, TrainingManagementType entity, string message) createdResponse = await UoW.CreateAsync<TrainingManagementType>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(TrainingManagementType).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, TrainingManagementType entity, string message)> UpdateAsync(TrainingManagementType entity)
        {
            (ExecutionState executionState, TrainingManagementType entity, string message) updateResponse;
             
            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<TrainingManagementType> filterOptions = new FilterOptions<TrainingManagementType>();
                    filterOptions.FilterExpression = x => x.TrainingTitle.Trim() == entity.TrainingTitle.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(TrainingManagementType).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, TrainingManagementType entity, string message) updatedEntity = await UoW.UpdateAsync<TrainingManagementType>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(TrainingManagementType).Name} update.");
                }
            }
            
            return updateResponse;
        }

        public override Task<(ExecutionState executionState, TrainingManagementType entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<TrainingManagementType>
            {
                FilterExpression = f => f.Id == id,
                IncludeExpression = i => i.Include(x => x.CountryTrainingManagementTypeMaps)
            };

            return base.GetAsync(filterOptions);
        }


		//public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
		//{
		//    (ExecutionState executionState, string message) returnResponse;

		//    FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
		//    filterOptions.FilterExpression = x => x.TrainingManagementTypeId == id;
		//    //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
		//    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
		//    returnResponse = entityObject;
		//    return returnResponse;
		//}

		public async Task<(ExecutionState executionState, IList<TrainingManagementType> entity, string message)> ListLatest(int take)
		{
            var types = await _readOnlyCtx.Set<TrainingManagementType>()
                .Include(x => x.Division)
                .Include(x => x.District)
                .Include(x => x.Upazilla)
                .OrderByDescending(x => x.Id)
                .Take(take)
                .ToListAsync();

            return (ExecutionState.Retrieved, types, "Retrieved successfully");
		}

		public override Task<(ExecutionState executionState, IQueryable<TrainingManagementType> entity, string message)> List(QueryOptions<TrainingManagementType> queryOptions = null)
		{
			return base.List(new QueryOptions<TrainingManagementType>
            {
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
		}
	}
}
