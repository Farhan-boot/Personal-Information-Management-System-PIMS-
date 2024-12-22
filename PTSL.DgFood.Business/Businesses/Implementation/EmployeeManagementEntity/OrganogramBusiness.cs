using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.UnitOfWork;
using Serialize.Linq.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class OrganogramBusiness : BaseBusiness<Organogram>, IOrganogramBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
		private readonly DgFoodReadOnlyCtx readOnlyCtx;

		public OrganogramBusiness(DgFoodUnitOfWork unitOfWork, DgFoodReadOnlyCtx readOnlyCtx) : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
			this.readOnlyCtx = readOnlyCtx;
		}

        public override async Task<(ExecutionState executionState, IQueryable<Organogram> entity, string message)> List(QueryOptions<Organogram> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Organogram> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Organogram>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Designation)
                                                   .Include(r => r.PostingType)
                                                   .Include(r => r.ParentPosting)
                                                   .Include(d=> d.Posting);

            (ExecutionState executionState, IQueryable<Organogram> entity, string message) entityObject = await _unitOfWork.List<Organogram>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, Organogram entity, string message)> CreateAsync(Organogram entity)
        {
            (ExecutionState executionState, Organogram entity, string message) createResponse;
            
            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    //FilterOptions<Organogram> filterOptions = new FilterOptions<Organogram>();
                    //filterOptions.FilterExpression = x => x.DesignationID == entity.DesignationID;
                    //(ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    //if(entityObject.executionState.ToString() == "Success")
                    //{
                    //    createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Organogram).Name} name already exists.");
                    //    return createResponse;
                    //}
                    
                    (ExecutionState executionState, Organogram entity, string message) createdResponse = await UoW.CreateAsync<Organogram>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Category).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }
        public override async Task<(ExecutionState executionState, Organogram entity, string message)> UpdateAsync(Organogram entity)
        {
            (ExecutionState executionState, Organogram entity, string message) updateResponse;
             
            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    //FilterOptions<Organogram> filterOptions = new FilterOptions<Organogram>();
                    //filterOptions.FilterExpression = x => x.DesignationID == entity.DesignationID && x.Id != entity.Id;
                    //(ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    //if (entityObject.executionState.ToString() == "Success")
                    //{
                    //    updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Organogram).Name} name already exists.");
                    //    return updateResponse;
                    //}

                    (ExecutionState executionState, Organogram entity, string message) updatedEntity = await UoW.UpdateAsync<Organogram>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Category).Name} update.");
                }
            }
            
            return updateResponse;
        }
        public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        {
            (ExecutionState executionState, string message) returnResponse;

            FilterOptions<Organogram> filterOptions = new FilterOptions<Organogram>();
            filterOptions.FilterExpression = x => x.Id == id;
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            return returnResponse;
        }

        public async Task<(ExecutionState executionState, long entity, string message)> CountEmployeeByPostDesignation(OrganogramOfficeType officeType, long? postingId, long? designationId, bool? isPermanent = null)
        {
            (ExecutionState executionState, long entity, string message) errorResult = (ExecutionState.Failure, 0, "Designation is invalid");
            if (designationId == null) return errorResult;

            var countOptions = new CountOptions<OfficialInformation>
            {
                FilterExpression = x =>
                    (x.JoiningDesgId == designationId
                    && x.JoinPostingId == postingId
                    && x.JoinOrganogramOfficeType == officeType
                    && x.IsFirstJoiningPostPermanent == isPermanent)
                    ||
                    (x.PresentOrganogramOfficeType == officeType
                    && x.PresentDesignationId == designationId
                    && x.PostingId == postingId
                    && x.IsPresentPostingPermanent == isPermanent)
            };
            var joinAndPresentCount = await _unitOfWork.OfficialInformation.CountAsync(countOptions);

            var attachCount = await _unitOfWork.OfficialInformation.CountAsync(new CountOptions<OfficialInformation>
            {
                FilterExpression = x =>
                    (x.CrntDesgId == designationId
                    && x.DepPostingId == postingId
                    && x.CrntOrganogramOfficeType == officeType
                    && x.IsCrntPostPermanent == isPermanent)
            });

            return (executionState: ExecutionState.Success, joinAndPresentCount.entityCount + attachCount.entityCount, "Counted");
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> IsOrganogramPostAvailable(OrganogramOfficeType officeType, long? postingId, long? designationId, bool? IsPermanent = null)
        {
            (ExecutionState executionState, bool entity, string message) errorResult = (ExecutionState.Failure, false, "Not available");
            if (designationId == null) return errorResult;

            var organogram = await GetOrganogramByPostDesignation(officeType, postingId, designationId, IsPermanent);
            if (organogram.entity == null) return errorResult;

            var totalEmployee = await CountEmployeeByPostDesignation(officeType, postingId, designationId, IsPermanent);
            var isAvailable = (organogram.entity.TotalPost - totalEmployee.entity) > 0;

            if (isAvailable) return (ExecutionState.Retrieved, isAvailable, "Available");
            return (ExecutionState.Failure, isAvailable, "Not available");
        }

        public async Task<(ExecutionState executionState, IList<OrganogramVM> entity, string message)> CustomDelete(long id)
        {
            var toRemoveIds = new List<long>() { id };
            var toRemoveLists = new List<Organogram>();

            // Also remove all childs
            for(var i = 0; i < toRemoveIds.Count; i++)
            {
                var organogramId = toRemoveIds[i];
                var queryOptions = new QueryOptions<Organogram>
                {
                    FilterExpression = x => x.ParentId == organogramId
                };

                var organogram = await base.List(queryOptions);
                if (organogram.entity != null)
                {
                    foreach (var item in organogram.entity)
                    {
                        item.IsDeleted = true;
                        item.IsActive = false;

                        toRemoveIds.Add(item.Id);
                        toRemoveLists.Add(item);
                    }
                }
            }

            // Remove the base
            var org = await base.GetAsync(id);
            if (org.entity != null)
            {
                org.entity.IsDeleted = true;
                org.entity.IsActive = false;

                toRemoveLists.Add(org.entity);
            }

            await using (IDbContextTransaction transaction = _unitOfWork.Begin())
            {
                foreach (var item in toRemoveLists)
                {
                    await _unitOfWork.UpdateAsync<Organogram>(item);
                }

                var saveResponse = await _unitOfWork.SaveAsync(transaction);
                if (saveResponse.executionState == ExecutionState.Success)
                {
                    transaction.Commit();
                    return (ExecutionState.Success, null, "Sucessfully deleted.");
                }
            }

            return (ExecutionState.Failure, null, "Failed to delete.");
        }

        public async Task<(ExecutionState executionState, Organogram entity, string message)> GetOrganogramByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? isPermanent)
        {
            var currentDate = DateTime.Now;

            var entity = await readOnlyCtx.Set<Organogram>()
                //.Where(x => x.DesignationID == designationId)
                //.Where(x => x.PostingId == postingId)
                .Where(x => x.OrganogramOfficeType == officeType)
                //.Where(x => x.IsPermanent == isPermanent)
                .FirstOrDefaultAsync()
                ;

            if (entity is null || (entity?.NonPermanentDeadLine is DateTime && ((DateTime)entity.NonPermanentDeadLine) < currentDate))
            {
                return (ExecutionState.Retrieved, null, "No organogram found");
            }

            return (ExecutionState.Retrieved, entity, "Found");

            /*
            isPermanent = isPermanent is null ? true : false;

            (ExecutionState executionState, Organogram entity, string message) errorResult = (ExecutionState.Failure, null, "No organogram found");
            if (designationId == null || designationId == 0) return errorResult;

            var filterOptions = new FilterOptions<Organogram>
            {
                FilterExpression =
					x => x.DesignationID == designationId
                    && x.PostingId == postingId
                    && x.OrganogramOfficeType == officeType
                    && x.IsPermanent == isPermanent
            };
            return await base.GetAsync(filterOptions);
            */
        }

        public async Task<(ExecutionState executionState,  IList<EmployeeInformation> empList, string message)> GetEmployeeByPostDesignation(OrganogramOfficeType? officeType, long? postingId, long? designationId, bool? IsPermanent = null)
        {
            (ExecutionState executionState, IList<EmployeeInformation> empList, string message) errorResult = (ExecutionState.Failure, null, "No employee found");
            if (designationId == null || designationId == 0) return errorResult;
            (ExecutionState executionState, IList<EmployeeInformation> empList, string message) returnResponse;

            var officialQueryOptions = new QueryOptions<OfficialInformation>();
            officialQueryOptions.FilterExpression = x =>
                (x.JoiningDesgId == designationId
                && x.JoinPostingId == postingId
                && x.JoinOrganogramOfficeType == officeType
                && x.IsFirstJoiningPostPermanent == IsPermanent)
                ||
                (x.PresentOrganogramOfficeType == officeType
                && x.PresentDesignationId == designationId
                && x.PostingId == postingId
				&& x.IsPresentPostingPermanent == IsPermanent)
                ||
                (x.CrntOrganogramOfficeType == officeType
                && x.CrntDesgId == designationId
                && x.DepPostingId == postingId
				&& x.IsCrntPostPermanent == IsPermanent);

            officialQueryOptions.IncludeExpression = e =>
                e.Include(x => x.PresentDesignation)
                .Include(x => x.JoiningDesg)
                .Include(x => x.CrntDesg)
                .Include(x => x.EmployeeInformation);

            var officaiOrganogramlList = await _unitOfWork.List<OfficialInformation>(officialQueryOptions);

            if (officaiOrganogramlList.executionState == ExecutionState.Retrieved)
            {
                /*
                var empIds = officaiOrganogramlList.entity.Select(x => x.EmployeeInformationId).ToList();

                var empQueryOptions = new QueryOptions<EmployeeInformation>();
                empQueryOptions.FilterExpression = e => empIds.Contains(e.Id);
                empQueryOptions.IncludeExpression = e =>
					e.Include(x => x.OfficialInformation)
                    .ThenInclude(x => x.PresentDesignation);

                var organogramList = await _unitOfWork.List<EmployeeInformation>(empQueryOptions);

                if(organogramList.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: ExecutionState.Retrieved, empList: organogramList.entity.ToList(), message: "Organogram list retrived successfully");
                    return returnResponse;
                }
                */
                var employees = officaiOrganogramlList.entity.Select(x => x.EmployeeInformation).ToList();
                returnResponse = (executionState: ExecutionState.Retrieved, empList: employees, message: "Organogram list not found.");

                return returnResponse;
            }
            else
            {
                returnResponse = (executionState: ExecutionState.Failure, empList: null, message: "Organogram list not found.");
                return returnResponse;
            }
        }

    }
}
