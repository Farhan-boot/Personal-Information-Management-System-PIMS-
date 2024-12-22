using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public class DistrictBusiness : BaseBusiness<District>, IDistrictBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public DistrictBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> CreateAsync(District entity)
        {
            (ExecutionState executionState, District entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<District> filterOptions = new FilterOptions<District>();
                    filterOptions.FilterExpression = x => x.DistrictName.Trim() == entity.DistrictName.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity.DistrictName.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(District).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, District entity, string message) createdResponse = await UoW.CreateAsync<District>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(District).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> UpdateAsync(District entity)
        {
            (ExecutionState executionState, District entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<District> filterOptions = new FilterOptions<District>();
                    filterOptions.FilterExpression = x => x.DistrictName.Trim() == entity.DistrictName.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(District).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, District entity, string message) updatedEntity = await UoW.UpdateAsync<District>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(District).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<District> entity, string message)> List(QueryOptions<District> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<District> entity, string message) returnResponse;

            queryOptions = new QueryOptions<District>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x=>x.PoliceStations);            
            queryOptions.SortingExpression = x => x.OrderByDescending(x => x.Id);            

            (ExecutionState executionState, IQueryable<District> entity, string message) entityObject = await _unitOfWork.List<District>(queryOptions);
            returnResponse = entityObject;
            
            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, District entity, string message) returnResponse;

            FilterOptions<District> filterOptions = new FilterOptions<District>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations).Include(x => x.Upazillas);
            (ExecutionState executionState, District entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

            FilterOptions<PoliceStation> filterOptions = new FilterOptions<PoliceStation>();
            filterOptions.FilterExpression = x => x.DistrictId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<PermanentAddress> filterOptions_PermanentAddress = new FilterOptions<PermanentAddress>();
            filterOptions_PermanentAddress.FilterExpression = x => x.DistrictId == id ;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_PermanentAddress = await _unitOfWork.DoesExistAsync(filterOptions_PermanentAddress);
            returnResponse = entityObject_PermanentAddress;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<PresentAddress> filterOptions_PresentAddress = new FilterOptions<PresentAddress>();
            filterOptions_PresentAddress.FilterExpression = x => x.DistrictId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_PresentAddress = await _unitOfWork.DoesExistAsync(filterOptions_PresentAddress);
            returnResponse = entityObject_PresentAddress;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<SpouseInformation> filterOptions_SpouseInformation = new FilterOptions<SpouseInformation>();
            filterOptions_SpouseInformation.FilterExpression = x => x.DistrictId == id ;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_SpouseInformation = await _unitOfWork.DoesExistAsync(filterOptions_SpouseInformation);
            returnResponse = entityObject_SpouseInformation;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            FilterOptions<EmployeeInformation> filterOptions_EmployeeInformation = new FilterOptions<EmployeeInformation>();
            filterOptions_EmployeeInformation.FilterExpression = x => x.DistrictId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_EmployeeInformation = await _unitOfWork.DoesExistAsync(filterOptions_EmployeeInformation);
            returnResponse = entityObject_EmployeeInformation;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }

            FilterOptions<PostingRecords> filterOptions_PostingRecords = new FilterOptions<PostingRecords>();
            filterOptions_PostingRecords.FilterExpression = x => x.TransferFromDistrictId == id || x.TransferToDistrictId == id;
            //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
            (ExecutionState executionState, string message) entityObject_PostingRecords = await _unitOfWork.DoesExistAsync(filterOptions_PostingRecords);
            returnResponse = entityObject_PostingRecords;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }


            return returnResponse;
        }

    }
}
