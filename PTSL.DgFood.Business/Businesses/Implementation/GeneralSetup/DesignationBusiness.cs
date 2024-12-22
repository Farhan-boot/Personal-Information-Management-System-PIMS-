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
    public class DesignationBusiness : BaseBusiness<Designation>, IDesignationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public DesignationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, Designation entity, string message)> CreateAsync(Designation entity)
        {
            (ExecutionState executionState, Designation entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Designation> filterOptions = new FilterOptions<Designation>();
                    filterOptions.FilterExpression = x => x.DesignationName.Trim() == entity.DesignationName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.DesignationName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Designation).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, Designation entity, string message) createdResponse = await UoW.CreateAsync<Designation>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Designation).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, Designation entity, string message)> UpdateAsync(Designation entity)
        {
            (ExecutionState executionState, Designation entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Designation> filterOptions = new FilterOptions<Designation>();
                    filterOptions.FilterExpression = x => x.DesignationName.Trim() == entity.DesignationName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Designation).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, Designation entity, string message) updatedEntity = await UoW.UpdateAsync<Designation>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Designation).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<Designation> entity, string message)> List(QueryOptions<Designation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Designation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Designation>();
            queryOptions.IncludeExpression = x => x.Include(i => i.DesignationClasses);
            //queryOptions.SortingExpression = x => x.OrderByDescending(i => i.Id);

            (ExecutionState executionState, IQueryable<Designation> entity, string message) entityObject = await _unitOfWork.List<Designation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Designation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Designation entity, string message) returnResponse; 

            FilterOptions<Designation> filterOptions = new FilterOptions<Designation>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.DesignationClasses);
            (ExecutionState executionState, Designation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

            FilterOptions<PromotionPartculars> filterOptions = new FilterOptions<PromotionPartculars>();
            filterOptions.FilterExpression = x => x.DesignationId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<PostingRecords> filterOptions_PostingRecords = new FilterOptions<PostingRecords>();
            filterOptions_PostingRecords.FilterExpression = x => x.DesignationId == id || x.CrntDesgId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_PostingRecords = await _unitOfWork.DoesExistAsync(filterOptions_PostingRecords);
            returnResponse = entityObject_PostingRecords;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<OfficialInformation> filterOptions_OfficialInformation = new FilterOptions<OfficialInformation>();
            filterOptions_OfficialInformation.FilterExpression = x => x.PresentDesignationId == id || x.CrntDesgId == id || x.JoiningDesgId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_OfficialInformation = await _unitOfWork.DoesExistAsync(filterOptions_OfficialInformation);
            returnResponse = entityObject_OfficialInformation;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }


            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IQueryable<Designation> entity, string message)> GetByRankAndDesignationClass(long? rankId, long? designationClassId)
        {
            var filterOptions = new QueryOptions<Designation>();

            // By default return nothing
            filterOptions.FilterExpression = x => x.Id < 0;

            if (rankId != null && rankId > 0 && designationClassId != null && designationClassId > 0)
            {
                filterOptions.FilterExpression = x => x.RankId == rankId && x.DesignationClassId == designationClassId;
            }
            else if (rankId != null && rankId > 0)
            {
                filterOptions.FilterExpression = x => x.RankId == rankId;
            }
            else if (designationClassId != null && designationClassId > 0)
            {
                filterOptions.FilterExpression = x => x.DesignationClassId == designationClassId;
            }

            return await base.List(filterOptions);
        }
    }
}
