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
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.DAL.Repositories.Interface;
using PTSL.DgFood.DAL.UnitOfWork;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class EmployeeInformationBusiness : BaseBusiness<EmployeeInformation>, IEmployeeInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
		private readonly DgFoodReadOnlyCtx readOnlyCtx;

		public EmployeeInformationBusiness(DgFoodUnitOfWork unitOfWork, DgFoodReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
			this.readOnlyCtx = readOnlyCtx;
		}

        public async Task<DirectAndPromotionalEmployeeVM> GetDirectAndPromotionalRecruitmentEmployee()
        {
            var result = new DirectAndPromotionalEmployeeVM();
            //var postingType = await readOnlyCtx.Set<Posting>()
            //    .Select(x => new { x.PostingName, x.Id })
            //    .ToListAsync();

            // By recruit
            var byRecruitCount = await readOnlyCtx.Set<OfficialInformation>()
                .CountAsync(x => x.RecruitPromoId == (long)RecruitPromoEnum.ByRecruitment);
			result.DirectEmployee = byRecruitCount;

            //var currentOfficeWiseByRecruitCount = readOnlyCtx.Set<OfficialInformation>()
            //    .Where(x => x.RecruitPromoId == (long)RecruitPromoEnum.ByRecruitment)
            //    .GroupBy(x => x.PostingId)
            //    .Select(x => new PostingTypeCount { PostingId = x.Key, Count = x.Count() })
            //    .ToList();

            // By promotion
            var byPromotionCount = await readOnlyCtx.Set<OfficialInformation>()
                .CountAsync(x => x.RecruitPromoId == (long)RecruitPromoEnum.ByPromotion);
			result.PromotionalEmployee = byPromotionCount;

            //var currentOfficeWiseByPromotionCount = readOnlyCtx.Set<OfficialInformation>()
            //    .Where(x => x.RecruitPromoId == (long)RecruitPromoEnum.ByPromotion)
            //    .GroupBy(x => x.PostingId)
            //    .Select(x => new PostingTypeCount { PostingId = x.Key, Count = x.Count() })
            //    .ToList();


			return result;

            // ------------------------------------------
            /*
            var result = new TotalEmployeeOfficeWiseVM();
            var totalEmployee = await readOnlyCtx.Set<EmployeeInformation>()
                .CountAsync();
            result.TotalEmployee = totalEmployee;

            // Current posting id
            var currentOfficeWise = readOnlyCtx.Set<OfficialInformation>()
                .GroupBy(x => x.PostingId)
                .Select(x => new PostingTypeCount { PostingId = x.Key, Count = x.Count() })
                .ToList();

            var postingType = await readOnlyCtx.Set<Posting>()
                .Select(x => new { x.PostingName, x.Id })
                .ToListAsync();

			result.OfficeWiseEmployees = currentOfficeWise
				.Join(postingType,
					  result => result.PostingId,
					  type => type.Id,
					  (result, type) => new OfficeWiseEmployee
					  {
						  PostingId = result.PostingId,
						  PostingName = type.PostingName,
						  EmployeeCount = result.Count
					  })
				.ToList();
            */
        }

        public async Task<TotalEmployeeOfficeWiseVM> GetTotalEmployeeOfficeWise()
        {
            var result = new TotalEmployeeOfficeWiseVM();
            var totalEmployee = await readOnlyCtx.Set<EmployeeInformation>()
                .CountAsync();
            result.TotalEmployee = totalEmployee;

            // Current posting id
            var currentOfficeWise = readOnlyCtx.Set<OfficialInformation>()
                .GroupBy(x => x.PostingId)
                .Select(x => new PostingTypeCount { PostingId = x.Key, Count = x.Count() })
                .ToList();
            /*
            var attachOfficeWise = readOnlyCtx.Set<OfficialInformation>()
                .GroupBy(x => x.DepPostingId)
                .Select(x => new PostingTypeCount { PostingId = x.Key ?? 0, Count = x.Count() })
                .Where(x => x.PostingId != 0)
                .ToList();
            var combinedResults = currentOfficeWise
                .Concat(attachOfficeWise)
                .GroupBy(x => x.PostingId)
                .Select(x => new { PostingId = x.Key, Count = x.Sum(y => y.Count) });
            */

            var postingType = await readOnlyCtx.Set<Posting>()
                .Select(x => new { x.PostingName, x.Id })
                .ToListAsync();

			result.OfficeWiseEmployees = currentOfficeWise
				.Join(postingType,
					  result => result.PostingId,
					  type => type.Id,
					  (result, type) => new OfficeWiseEmployee
					  {
						  PostingId = result.PostingId,
						  PostingName = type.PostingName,
						  EmployeeCount = result.Count
					  })
				.ToList();

            return result;
        }

        public override async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> CreateAsync(EmployeeInformation entity)
        {
            (ExecutionState executionState, EmployeeInformation entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    entity.NameEnglish = entity.NameEnglish.Trim();
                    entity.NameBangla = entity.NameBangla.Trim();
                    entity.Email = entity.Email == null ? "" : entity.Email.Trim();
                    entity.EmployeeCode = entity.EmployeeCode.Trim();
                    FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
                    filterOptions.FilterExpression = x => x.EmployeeCode == entity.EmployeeCode.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: "Email/Employee Code already exists.");
                        return createResponse;
                    }
                    if (entity.NameEnglish.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: "Please Enter English Name.");
                        return createResponse;
                    }
                    if (entity.NameBangla.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: "Please Enter Bangla Name.");
                        return createResponse;
                    }

                    (ExecutionState executionState, EmployeeInformation entity, string message) createdResponse = await UoW.CreateAsync<EmployeeInformation>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(EmployeeInformation).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }
        public override async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> UpdateAsync(EmployeeInformation entity)
        {
            (ExecutionState executionState, EmployeeInformation entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    entity.NameEnglish = entity.NameEnglish.Trim();
                    entity.NameBangla = entity.NameBangla.Trim();
                    entity.Email = entity.Email != null ? entity.Email.Trim() : "";
                    FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
                    filterOptions.FilterExpression = x => (x.Email.Trim() == entity.Email.Trim() || x.EmployeeCode == entity.EmployeeCode.Trim()) && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: "Email/Employee Code already exists.");
                        return updateResponse;
                    }
                    if (entity.NameEnglish.Trim() == "")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: "Please Enter English Name.");
                        return updateResponse;
                    }
                    if (entity.NameBangla.Trim() == "")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: "Please Enter Bangla Name.");
                        return updateResponse;
                    }
                    (ExecutionState executionState, EmployeeInformation entity, string message) updatedEntity = await UoW.UpdateAsync<EmployeeInformation>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(EmployeeInformation).Name} update.");
                }
            }

            return updateResponse;
        }
        public override async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> List(QueryOptions<EmployeeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            queryOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
            .Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
            .Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
            .Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
            .Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
            .Include(x => x.Division).Include(x => x.District).Include(x => x.PoliceStation)
            .Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).Include(x => x.EmployeeStatus).
            Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation).
            Include(y => y.LanguageInformations).ThenInclude(x => x.Language);
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public virtual async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> EmployeeList(QueryOptions<EmployeeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            queryOptions.IncludeExpression = x =>
            x.Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank)
            .Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation).
            Include(y => y.PostingRecords).ThenInclude(x => x.Rank)
            .Include(y => y.PostingRecords).ThenInclude(x => x.Designation)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.RecruitPromo)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation);
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            var emplists = entityObject.entity.ToList();
            returnResponse = entityObject;
            return returnResponse;
        }
        public override async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, EmployeeInformation entity, string message) returnResponse;

            FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
            filterOptions.FilterExpression = x => x.Id == id;
            //filterOptions.IncludeExpression = x => x
            // Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
            //.Include(j => j.ChildrenInformation).Include(t => t.Division).Include(t => t.District)
            //.Include(y => y.PermanentAddresses).ThenInclude(x => x.Division)
            //.Include(y => y.PermanentAddresses).ThenInclude(x => x.District)
            //.Include(y => y.PermanentAddresses).ThenInclude(x => x.PoliceStation)
            //.Include(y => y.PresentAddresses).ThenInclude(x => x.Division)
            //.Include(y => y.PresentAddresses).ThenInclude(x => x.District)
            //.Include(y => y.PresentAddresses).ThenInclude(x => x.PoliceStation)
            //.Include(y => y.EducationalQualification).Include(y => y.TrainingInformation)
            //.Include(y => y.ServiceHistories)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningRank)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignationClass)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningDesignationClass)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningDesg)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.PostingType)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.JoinPostingType)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.JoinPosting)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.CrntDesg)
            //.Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
            //.Include(y => y.DisciplinaryActionsAndCriminalProsecutions).ThenInclude(x => x.Category)
            //.Include(y => y.DisciplinaryActionsAndCriminalProsecutions).ThenInclude(x => x.PresentStatus)
            //.Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
            //.Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.DesignationClass)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.CurrDesignationClass)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.MainPostingType)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.DeppostingType)
            //.Include(y => y.PostingRecords).ThenInclude(y => y.DepPosting)
            //.Include(y => y.PostingRecords).ThenInclude(x => x.PostResponsibility)
            //.Include(y => y.EmployeeTransfers).
            //Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).
            //Include(y => y.LanguageInformations).ThenInclude(x => x.Language).
            /*            Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation).Include(x => x.EmployeeStatus)*/
            //;

            (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        //public override async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetAsync(long id)
        //{
        //    (ExecutionState executionState, EmployeeInformation entity, string message) returnResponse;

        //    FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
        //    filterOptions.FilterExpression = x => x.Id == id;
        //    filterOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
        //    .Include(j => j.ChildrenInformation).Include(t => t.Division).Include(t => t.District)
        //    .Include(y => y.PermanentAddresses).ThenInclude(x => x.Division)
        //    .Include(y => y.PermanentAddresses).ThenInclude(x => x.District)
        //    .Include(y => y.PermanentAddresses).ThenInclude(x => x.PoliceStation)
        //    .Include(y => y.PresentAddresses).ThenInclude(x => x.Division)
        //    .Include(y => y.PresentAddresses).ThenInclude(x => x.District)
        //    .Include(y => y.PresentAddresses).ThenInclude(x => x.PoliceStation)
        //    .Include(y => y.EducationalQualification).Include(y => y.TrainingInformation)
        //    .Include(y => y.ServiceHistories).Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningRank)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignationClass)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningDesignationClass)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.JoiningDesg)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.PostingType)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.JoinPostingType)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.JoinPosting)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.CrntDesg)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
        //    .Include(y => y.DisciplinaryActionsAndCriminalProsecutions).ThenInclude(x => x.Category)
        //    .Include(y => y.DisciplinaryActionsAndCriminalProsecutions).ThenInclude(x => x.PresentStatus)
        //    .Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
        //    .Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.DesignationClass)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.CurrDesignationClass)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.MainPostingType)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.DeppostingType)
        //    .Include(y => y.PostingRecords).ThenInclude(y => y.DepPosting)
        //    .Include(y => y.PostingRecords).ThenInclude(x => x.PostResponsibility)
        //    .Include(y => y.EmployeeTransfers).
        //    Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).
        //    Include(y => y.LanguageInformations).ThenInclude(x => x.Language).
        //    Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation).Include(x => x.EmployeeStatus);

        //    (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

        //    if (entityObject.entity != null)
        //    {
        //        returnResponse = entityObject;
        //    }
        //    else
        //    {
        //        returnResponse = entityObject;
        //    }


        //    return returnResponse;
        //}

        //public override async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetAsync(long id)
        //{
        //    (ExecutionState executionState, EmployeeInformation entity, string message) returnResponse;

        //    FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
        //    filterOptions.FilterExpression = x => x.Id == id;

        //    (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

        //    if (entityObject.entity != null)
        //    {
        //        returnResponse = entityObject;
        //    }
        //    else
        //    {
        //        returnResponse = entityObject;
        //    }


        //    return returnResponse;
        //}
        //public virtual async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetEmployeeBasicInfoById(long? id)
        //{
        //    (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

        //    EmployeeInformation queryOptions = new EmployeeInformation();
        //    queryOptions.FilterExpression = x => x.Id == id;
        //    queryOptions.IncludeExpression = x =>
        //    x.Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank)
        //    .Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.RecruitPromo)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
        //    .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation);
        //    (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync<EmployeeInformation>(queryOptions);
        //    var emplists = entityObject.entity.ToList();
        //    returnResponse = entityObject;
        //    return returnResponse;
        //}
        public virtual async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetEmployeeFullInfoById(long? id)
        {
            (ExecutionState executionState, EmployeeInformation entity, string message) returnResponse;

            FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(x => x.Division).Include(x => x.District);
            (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

            //official information
            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) returnOfficialResponse;
            QueryOptions<OfficialInformation> queryOptions;
            queryOptions = new QueryOptions<OfficialInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            queryOptions.IncludeExpression = x => x.Include(y => y.PresentRank)
            .Include(x => x.JoiningRank).Include(x => x.PresentDesignationClass)
            .Include(x => x.JoiningDesignationClass).Include(x => x.PresentDesignation)
            .Include(x => x.JoiningDesg).Include(x => x.PostingType).Include(x => x.Posting)
            .Include(x => x.JoinPostingType).Include(x => x.JoinPosting).Include(x => x.CrntDesg).Include(x => x.Depposting).Include(x => x.RecruitPromo);
            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) entityOfficialObject = await _unitOfWork.List<OfficialInformation>(queryOptions);
            returnOfficialResponse = entityOfficialObject;

            //Present Address
            (ExecutionState executionState, IQueryable<PresentAddress> entity, string message) returnPresentAddressResponse;
            QueryOptions<PresentAddress> presentAddressQueryOptions;
            presentAddressQueryOptions = new QueryOptions<PresentAddress>();
            presentAddressQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            presentAddressQueryOptions.IncludeExpression = x => x.Include(x => x.Division).Include(y => y.District).Include(x => x.PoliceStation);

            (ExecutionState executionState, IQueryable<PresentAddress> entity, string message) entityPresentAddressObject = await _unitOfWork.List<PresentAddress>(presentAddressQueryOptions);
            returnPresentAddressResponse = entityPresentAddressObject;

            //Permanent Address
            (ExecutionState executionState, IQueryable<PermanentAddress> entity, string message) returnPermanentAddressResponse;
            QueryOptions<PermanentAddress> PermanentAddressQueryOptions;
            PermanentAddressQueryOptions = new QueryOptions<PermanentAddress>();
            PermanentAddressQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            PermanentAddressQueryOptions.IncludeExpression = x => x.Include(x => x.Division).Include(y => y.District).Include(x => x.PoliceStation);
            (ExecutionState executionState, IQueryable<PermanentAddress> entity, string message) entityPermanentAddressObject = await _unitOfWork.List<PermanentAddress>(PermanentAddressQueryOptions);
            returnPermanentAddressResponse = entityPermanentAddressObject;

            //Spouse Information
            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) returnSpouseInformationResponse;
            QueryOptions<SpouseInformation> SpouseInformationQueryOptions;
            SpouseInformationQueryOptions = new QueryOptions<SpouseInformation>();
            SpouseInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            SpouseInformationQueryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District);

            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) entitySpouseInformationObject = await _unitOfWork.List<SpouseInformation>(SpouseInformationQueryOptions);
            returnSpouseInformationResponse = entitySpouseInformationObject;

            //Children Information
            (ExecutionState executionState, IQueryable<ChildrenInformation> entity, string message) returnChildrenInformationResponse;
            QueryOptions<ChildrenInformation> ChildrenInformationQueryOptions;
            ChildrenInformationQueryOptions = new QueryOptions<ChildrenInformation>();
            ChildrenInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            SpouseInformationQueryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District);

            (ExecutionState executionState, IQueryable<ChildrenInformation> entity, string message) entityChildrenInformationObject = await _unitOfWork.List<ChildrenInformation>(ChildrenInformationQueryOptions);
            returnChildrenInformationResponse = entityChildrenInformationObject;

            //EducationalQualification
            (ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) returnEducationalQualificationResponse;
            QueryOptions<EducationalQualification> EducationalQualificationQueryOptions;
            EducationalQualificationQueryOptions = new QueryOptions<EducationalQualification>();
            //EducationalQualificationQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;

            (ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) entityEducationalQualificationObject = await _unitOfWork.List<EducationalQualification>(EducationalQualificationQueryOptions);
            returnEducationalQualificationResponse = entityEducationalQualificationObject;

            //TrainingInformation
            (ExecutionState executionState, IQueryable<TrainingInformation> entity, string message) returnTrainingInformationResponse;
            QueryOptions<TrainingInformation> TrainingInformationQueryOptions;
            TrainingInformationQueryOptions = new QueryOptions<TrainingInformation>();
            TrainingInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;

            (ExecutionState executionState, IQueryable<TrainingInformation> entity, string message) entityTrainingInformationObject = await _unitOfWork.List<TrainingInformation>(TrainingInformationQueryOptions);
            returnTrainingInformationResponse = entityTrainingInformationObject;

            //ServiceHistory
            (ExecutionState executionState, IQueryable<ServiceHistory> entity, string message) returnServiceHistoryResponse;
            QueryOptions<ServiceHistory> ServiceHistoryQueryOptions;
            ServiceHistoryQueryOptions = new QueryOptions<ServiceHistory>();
            ServiceHistoryQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;

            (ExecutionState executionState, IQueryable<ServiceHistory> entity, string message) entityServiceHistoryObject = await _unitOfWork.List<ServiceHistory>(ServiceHistoryQueryOptions);
            returnServiceHistoryResponse = entityServiceHistoryObject;

            //PromotionPartculars
            (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) returnPromotionPartcularsResponse;
            QueryOptions<PromotionPartculars> PromotionPartcularsQueryOptions;
            PromotionPartcularsQueryOptions = new QueryOptions<PromotionPartculars>();
            PromotionPartcularsQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            PromotionPartcularsQueryOptions.IncludeExpression = x => x.Include(x => x.Rank).Include(x => x.Designation);
            (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) entityPromotionPartcularsObject = await _unitOfWork.List<PromotionPartculars>(PromotionPartcularsQueryOptions);
            returnPromotionPartcularsResponse = entityPromotionPartcularsObject;

            //DisciplinaryActionsAndCriminalProsecution
            (ExecutionState executionState, IQueryable<DisciplinaryActionsAndCriminalProsecution> entity, string message) returnDisciplinaryActionsAndCriminalProsecutionResponse;
            QueryOptions<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecutionQueryOptions;
            DisciplinaryActionsAndCriminalProsecutionQueryOptions = new QueryOptions<DisciplinaryActionsAndCriminalProsecution>();
            DisciplinaryActionsAndCriminalProsecutionQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            DisciplinaryActionsAndCriminalProsecutionQueryOptions.IncludeExpression = x => x.Include(x => x.Category).Include(x => x.PresentStatus);
            (ExecutionState executionState, IQueryable<DisciplinaryActionsAndCriminalProsecution> entity, string message) entityDisciplinaryActionsAndCriminalProsecutionObject = await _unitOfWork.List<DisciplinaryActionsAndCriminalProsecution>(DisciplinaryActionsAndCriminalProsecutionQueryOptions);
            returnDisciplinaryActionsAndCriminalProsecutionResponse = entityDisciplinaryActionsAndCriminalProsecutionObject;

            //PostingRecords
            (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) returnPostingRecordsResponse;
            QueryOptions<PostingRecords> PostingRecordsQueryOptions;
            PostingRecordsQueryOptions = new QueryOptions<PostingRecords>();
            PostingRecordsQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            PostingRecordsQueryOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(j => j.Designation)
            .Include(y => y.DesignationClass).Include(y => y.CrntDesg).Include(y => y.CurrDesignationClass)
            .Include(y => y.MainPostingType).Include(y => y.Posting).Include(y => y.DeppostingType)
            .Include(y => y.DepPosting).Include(x => x.PostResponsibility);
            (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) entityPostingRecordsObject = await _unitOfWork.List<PostingRecords>(PostingRecordsQueryOptions);
            returnPostingRecordsResponse = entityPostingRecordsObject;

            //LanguageInformation
            (ExecutionState executionState, IQueryable<LanguageInformation> entity, string message) returnLanguageInformationResponse;
            QueryOptions<LanguageInformation> LanguageInformationQueryOptions;
            LanguageInformationQueryOptions = new QueryOptions<LanguageInformation>();
            LanguageInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
            LanguageInformationQueryOptions.IncludeExpression = x => x.Include(x => x.Language);
            (ExecutionState executionState, IQueryable<LanguageInformation> entity, string message) entityLanguageInformationObject = await _unitOfWork.List<LanguageInformation>(LanguageInformationQueryOptions);
            returnLanguageInformationResponse = entityLanguageInformationObject;

            //final output 
            returnResponse.entity = entityObject.entity;
            var spouseData = entitySpouseInformationObject.entity == null ? new List<SpouseInformation>() : new List<SpouseInformation>(entitySpouseInformationObject.entity);
            returnResponse.entity.SpouseInformation = spouseData;

            var officialData = entityOfficialObject.entity == null ? new List<OfficialInformation>() : new List<OfficialInformation>(entityOfficialObject.entity);
            returnResponse.entity.OfficialInformation = officialData;


            var presentAddressData = entityPresentAddressObject.entity == null ? new List<PresentAddress>() : new List<PresentAddress>(entityPresentAddressObject.entity);
            returnResponse.entity.PresentAddresses = presentAddressData;
            var permanentAddressData = entityPermanentAddressObject.entity == null ? new List<PermanentAddress>() : new List<PermanentAddress>(entityPermanentAddressObject.entity);
            returnResponse.entity.PermanentAddresses = permanentAddressData;
            var childrenInformationData = entityChildrenInformationObject.entity == null ? new List<ChildrenInformation>() : new List<ChildrenInformation>(entityChildrenInformationObject.entity);
            returnResponse.entity.ChildrenInformation = childrenInformationData;


            //var educationalData = entityEducationalQualificationObject.entity == null ? new List<EducationalQualification>() : new List<EducationalQualification>(entityEducationalQualificationObject.entity);
            //returnResponse.entity.EducationalQualification = educationalData;


            var trainingData = entityTrainingInformationObject.entity == null ? new List<TrainingInformation>() : new List<TrainingInformation>(entityTrainingInformationObject.entity);
            returnResponse.entity.TrainingInformation = trainingData;
            var promotionData = entityPromotionPartcularsObject.entity == null ? new List<PromotionPartculars>() : new List<PromotionPartculars>(entityPromotionPartcularsObject.entity);
            returnResponse.entity.PromotionPartculars = promotionData;
            var postingData = entityPostingRecordsObject.entity == null ? new List<PostingRecords>() : new List<PostingRecords>(entityPostingRecordsObject.entity);
            returnResponse.entity.PostingRecords = postingData;
            var languageData = entityLanguageInformationObject.entity == null ? new List<LanguageInformation>() : new List<LanguageInformation>(entityLanguageInformationObject.entity);
            returnResponse.entity.LanguageInformations = languageData;
            returnResponse.message = "";
            returnResponse.executionState = ExecutionState.Retrieved;


            return returnResponse;
        }
        public virtual async Task<(ExecutionState executionState, EmployeeInformation entity, string message)> GetEmployeeBasicInfoByEmployeeCode(string EmployeeCode)
        {
            (ExecutionState executionState, EmployeeInformation entity, string message) returnResponse;

            FilterOptions<EmployeeInformation> filterOptions = new FilterOptions<EmployeeInformation>();
            filterOptions.FilterExpression = x => x.EmployeeCode == EmployeeCode;
            filterOptions.IncludeExpression = x => x.Include(x => x.Division).Include(x => x.District);
            (ExecutionState executionState, EmployeeInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

            //official information
            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) returnOfficialResponse;
            QueryOptions<OfficialInformation> queryOptions;
            queryOptions = new QueryOptions<OfficialInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            queryOptions.IncludeExpression = x => x.Include(y => y.PresentRank)
            .Include(x => x.JoiningRank).Include(x => x.PresentDesignationClass)
            .Include(x => x.JoiningDesignationClass).Include(x => x.PresentDesignation)
            .Include(x => x.JoiningDesg).Include(x => x.PostingType).Include(x => x.Posting)
            .Include(x => x.JoinPostingType).Include(x => x.JoinPosting).Include(x => x.CrntDesg).Include(x => x.Depposting).Include(x => x.RecruitPromo);
            (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) entityOfficialObject = await _unitOfWork.List<OfficialInformation>(queryOptions);
            returnOfficialResponse = entityOfficialObject;

            //Present Address
            (ExecutionState executionState, IQueryable<PresentAddress> entity, string message) returnPresentAddressResponse;
            QueryOptions<PresentAddress> presentAddressQueryOptions;
            presentAddressQueryOptions = new QueryOptions<PresentAddress>();
            presentAddressQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            presentAddressQueryOptions.IncludeExpression = x => x.Include(x => x.Division).Include(y => y.District).Include(x => x.PoliceStation);

            (ExecutionState executionState, IQueryable<PresentAddress> entity, string message) entityPresentAddressObject = await _unitOfWork.List<PresentAddress>(presentAddressQueryOptions);
            returnPresentAddressResponse = entityPresentAddressObject;

            //Permanent Address
            (ExecutionState executionState, IQueryable<PermanentAddress> entity, string message) returnPermanentAddressResponse;
            QueryOptions<PermanentAddress> PermanentAddressQueryOptions;
            PermanentAddressQueryOptions = new QueryOptions<PermanentAddress>();
            PermanentAddressQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            PermanentAddressQueryOptions.IncludeExpression = x => x.Include(x => x.Division).Include(y => y.District).Include(x => x.PoliceStation);
            (ExecutionState executionState, IQueryable<PermanentAddress> entity, string message) entityPermanentAddressObject = await _unitOfWork.List<PermanentAddress>(PermanentAddressQueryOptions);
            returnPermanentAddressResponse = entityPermanentAddressObject;

            //Spouse Information
            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) returnSpouseInformationResponse;
            QueryOptions<SpouseInformation> SpouseInformationQueryOptions;
            SpouseInformationQueryOptions = new QueryOptions<SpouseInformation>();
            SpouseInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            SpouseInformationQueryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District);

            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) entitySpouseInformationObject = await _unitOfWork.List<SpouseInformation>(SpouseInformationQueryOptions);
            returnSpouseInformationResponse = entitySpouseInformationObject;

            //Children Information
            (ExecutionState executionState, IQueryable<ChildrenInformation> entity, string message) returnChildrenInformationResponse;
            QueryOptions<ChildrenInformation> ChildrenInformationQueryOptions;
            ChildrenInformationQueryOptions = new QueryOptions<ChildrenInformation>();
            ChildrenInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            SpouseInformationQueryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District);

            (ExecutionState executionState, IQueryable<ChildrenInformation> entity, string message) entityChildrenInformationObject = await _unitOfWork.List<ChildrenInformation>(ChildrenInformationQueryOptions);
            returnChildrenInformationResponse = entityChildrenInformationObject;

            //EducationalQualification
            (ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) returnEducationalQualificationResponse;
            QueryOptions<EducationalQualification> EducationalQualificationQueryOptions;
            EducationalQualificationQueryOptions = new QueryOptions<EducationalQualification>();
            EducationalQualificationQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;

            (ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) entityEducationalQualificationObject = await _unitOfWork.List<EducationalQualification>(EducationalQualificationQueryOptions);
            returnEducationalQualificationResponse = entityEducationalQualificationObject;

            //TrainingInformation
            (ExecutionState executionState, IQueryable<TrainingInformation> entity, string message) returnTrainingInformationResponse;
            QueryOptions<TrainingInformation> TrainingInformationQueryOptions;
            TrainingInformationQueryOptions = new QueryOptions<TrainingInformation>();
            TrainingInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;

            (ExecutionState executionState, IQueryable<TrainingInformation> entity, string message) entityTrainingInformationObject = await _unitOfWork.List<TrainingInformation>(TrainingInformationQueryOptions);
            returnTrainingInformationResponse = entityTrainingInformationObject;

            //ServiceHistory
            (ExecutionState executionState, IQueryable<ServiceHistory> entity, string message) returnServiceHistoryResponse;
            QueryOptions<ServiceHistory> ServiceHistoryQueryOptions;
            ServiceHistoryQueryOptions = new QueryOptions<ServiceHistory>();
            ServiceHistoryQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;

            (ExecutionState executionState, IQueryable<ServiceHistory> entity, string message) entityServiceHistoryObject = await _unitOfWork.List<ServiceHistory>(ServiceHistoryQueryOptions);
            returnServiceHistoryResponse = entityServiceHistoryObject;

            //PromotionPartculars
            (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) returnPromotionPartcularsResponse;
            QueryOptions<PromotionPartculars> PromotionPartcularsQueryOptions;
            PromotionPartcularsQueryOptions = new QueryOptions<PromotionPartculars>();
            PromotionPartcularsQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            PromotionPartcularsQueryOptions.IncludeExpression = x => x.Include(x => x.Rank).Include(x => x.Designation);
            (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) entityPromotionPartcularsObject = await _unitOfWork.List<PromotionPartculars>(PromotionPartcularsQueryOptions);
            returnPromotionPartcularsResponse = entityPromotionPartcularsObject;


            //DisciplinaryActionsAndCriminalProsecution
            (ExecutionState executionState, IQueryable<DisciplinaryActionsAndCriminalProsecution> entity, string message) returnDisciplinaryActionsAndCriminalProsecutionResponse;
            QueryOptions<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecutionQueryOptions;
            DisciplinaryActionsAndCriminalProsecutionQueryOptions = new QueryOptions<DisciplinaryActionsAndCriminalProsecution>();
            DisciplinaryActionsAndCriminalProsecutionQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            DisciplinaryActionsAndCriminalProsecutionQueryOptions.IncludeExpression = x => x.Include(x => x.Category).Include(x => x.PresentStatus);
            (ExecutionState executionState, IQueryable<DisciplinaryActionsAndCriminalProsecution> entity, string message) entityDisciplinaryActionsAndCriminalProsecutionObject = await _unitOfWork.List<DisciplinaryActionsAndCriminalProsecution>(DisciplinaryActionsAndCriminalProsecutionQueryOptions);
            returnDisciplinaryActionsAndCriminalProsecutionResponse = entityDisciplinaryActionsAndCriminalProsecutionObject;

            //PostingRecords
            (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) returnPostingRecordsResponse;
            QueryOptions<PostingRecords> PostingRecordsQueryOptions;
            PostingRecordsQueryOptions = new QueryOptions<PostingRecords>();
            PostingRecordsQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            PostingRecordsQueryOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(j => j.Designation)
            .Include(y => y.DesignationClass).Include(y => y.CrntDesg).Include(y => y.CurrDesignationClass)
            .Include(y => y.MainPostingType).Include(y => y.Posting).Include(y => y.DeppostingType)
            .Include(y => y.DepPosting).Include(x => x.PostResponsibility);
            (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) entityPostingRecordsObject = await _unitOfWork.List<PostingRecords>(PostingRecordsQueryOptions);
            returnPostingRecordsResponse = entityPostingRecordsObject;

            //LanguageInformation
            (ExecutionState executionState, IQueryable<LanguageInformation> entity, string message) returnLanguageInformationResponse;
            QueryOptions<LanguageInformation> LanguageInformationQueryOptions;
            LanguageInformationQueryOptions = new QueryOptions<LanguageInformation>();
            LanguageInformationQueryOptions.FilterExpression = x => x.EmployeeInformationId == entityObject.entity.Id;
            LanguageInformationQueryOptions.IncludeExpression = x => x.Include(x => x.Language);
            (ExecutionState executionState, IQueryable<LanguageInformation> entity, string message) entityLanguageInformationObject = await _unitOfWork.List<LanguageInformation>(LanguageInformationQueryOptions);
            returnLanguageInformationResponse = entityLanguageInformationObject;

            //final output 
            returnResponse.entity = entityObject.entity;
            var spouseData = entitySpouseInformationObject.entity == null ? new List<SpouseInformation>() : new List<SpouseInformation>(entitySpouseInformationObject.entity);
            returnResponse.entity.SpouseInformation = spouseData;
            var officialData = entityOfficialObject.entity == null ? new List<OfficialInformation>() : new List<OfficialInformation>(entityOfficialObject.entity);
            returnResponse.entity.OfficialInformation = officialData;
            var presentAddressData = entityPresentAddressObject.entity == null ? new List<PresentAddress>() : new List<PresentAddress>(entityPresentAddressObject.entity);
            returnResponse.entity.PresentAddresses = presentAddressData;
            var permanentAddressData = entityPermanentAddressObject.entity == null ? new List<PermanentAddress>() : new List<PermanentAddress>(entityPermanentAddressObject.entity);
            returnResponse.entity.PermanentAddresses = permanentAddressData;
            var childrenInformationData = entityChildrenInformationObject.entity == null ? new List<ChildrenInformation>() : new List<ChildrenInformation>(entityChildrenInformationObject.entity);
            returnResponse.entity.ChildrenInformation = childrenInformationData;
            var educationalData = entityEducationalQualificationObject.entity == null ? new List<EducationalQualification>() : new List<EducationalQualification>(entityEducationalQualificationObject.entity);
            returnResponse.entity.EducationalQualification = educationalData;
            var trainingData = entityTrainingInformationObject.entity == null ? new List<TrainingInformation>() : new List<TrainingInformation>(entityTrainingInformationObject.entity);
            returnResponse.entity.TrainingInformation = trainingData;
            var promotionData = entityPromotionPartcularsObject.entity == null ? new List<PromotionPartculars>() : new List<PromotionPartculars>(entityPromotionPartcularsObject.entity);
            returnResponse.entity.PromotionPartculars = promotionData;
            var postingData = entityPostingRecordsObject.entity == null ? new List<PostingRecords>() : new List<PostingRecords>(entityPostingRecordsObject.entity);
            returnResponse.entity.PostingRecords = postingData;
            var languageData = entityLanguageInformationObject.entity == null ? new List<LanguageInformation>() : new List<LanguageInformation>(entityLanguageInformationObject.entity);
            returnResponse.entity.LanguageInformations = languageData;
            returnResponse.message = "";
            returnResponse.executionState = ExecutionState.Retrieved;


            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetFilterData(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;
            returnResponse.executionState = ExecutionState.Failure;
            returnResponse.message = "";
            returnResponse.entity = null;
            if (entity.Id > 0 && entity.RankId == null && entity.DesignationId == null)
            {
                //(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

                queryOptions = new QueryOptions<EmployeeInformation>();
                queryOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
                .Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
                .Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
                .Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
                .Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
                .Include(x => x.Division).Include(x => x.District).Include(x => x.PoliceStation)
                .Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).Include(x => x.EmployeeStatus).
                Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
                .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
                .Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
                .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
                .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation).
                Include(y => y.LanguageInformations).ThenInclude(x => x.Language);
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
                returnResponse = entityObject;

            }
            else if (entity.Id == 0 && (entity.RankId != null || entity.DesignationId != null))
            {
                //official information
                (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) returnOfficialResponse;
                QueryOptions<OfficialInformation> officialQueryOptions;
                officialQueryOptions = new QueryOptions<OfficialInformation>();

                (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) returnPromotionPartcularsResponse;
                QueryOptions<PromotionPartculars> PromotionPartcularsQueryOptions;
                PromotionPartcularsQueryOptions = new QueryOptions<PromotionPartculars>();

                (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) returnPostingRecordsResponse;
                QueryOptions<PostingRecords> PostingRecordsQueryOptions;
                PostingRecordsQueryOptions = new QueryOptions<PostingRecords>();

                if (entity.RankId != null && entity.DesignationId != null)
                {
                    officialQueryOptions.FilterExpression = x => x.PresentRankId == entity.RankId && x.PresentDesignationId == entity.DesignationId;
                    PromotionPartcularsQueryOptions.FilterExpression = x => x.RankId == entity.RankId && x.DesignationId == entity.DesignationId;
                    PostingRecordsQueryOptions.FilterExpression = x => x.RankId == entity.RankId && x.DesignationId == entity.DesignationId && x.IfEmployeeContinuing == true;
                }
                else if (entity.RankId != null && entity.DesignationId == null)
                {
                    officialQueryOptions.FilterExpression = x => x.PresentRankId == entity.RankId;
                    PromotionPartcularsQueryOptions.FilterExpression = x => x.RankId == entity.RankId;
                    PostingRecordsQueryOptions.FilterExpression = x => x.RankId == entity.RankId && x.IfEmployeeContinuing == true;
                }
                else if (entity.RankId == null && entity.DesignationId != null)
                {
                    officialQueryOptions.FilterExpression = x => x.CrntDesgId == entity.DesignationId;
                    PromotionPartcularsQueryOptions.FilterExpression = x => x.DesignationId == entity.DesignationId;
                    PostingRecordsQueryOptions.FilterExpression = x => x.DesignationId == entity.DesignationId && x.IfEmployeeContinuing == true;
                }

                //official information
                //officialQueryOptions.IncludeExpression = x => x.Include(y => y.PresentRank)
                //.Include(x => x.JoiningRank).Include(x => x.PresentDesignationClass)
                //.Include(x => x.JoiningDesignationClass).Include(x => x.PresentDesignation)
                //.Include(x => x.JoiningDesg).Include(x => x.PostingType).Include(x => x.Posting)
                //.Include(x => x.JoinPostingType).Include(x => x.JoinPosting).Include(x => x.CrntDesg).Include(x => x.Depposting);
                (ExecutionState executionState, IQueryable<OfficialInformation> entity, string message) entityOfficialObject = await _unitOfWork.List<OfficialInformation>(officialQueryOptions);
                returnOfficialResponse = entityOfficialObject;

                //PromotionPartculars


                // PromotionPartcularsQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
                PromotionPartcularsQueryOptions.IncludeExpression = x => x.Include(x => x.Rank).Include(x => x.Designation);
                (ExecutionState executionState, IQueryable<PromotionPartculars> entity, string message) entityPromotionPartcularsObject = await _unitOfWork.List<PromotionPartculars>(PromotionPartcularsQueryOptions);
                returnPromotionPartcularsResponse = entityPromotionPartcularsObject;


                //PostingRecords

                //PostingRecordsQueryOptions.FilterExpression = x => x.EmployeeInformationId == id;
                //PostingRecordsQueryOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(j => j.Designation)
                //.Include(y => y.DesignationClass).Include(y => y.CrntDesg).Include(y => y.CurrDesignationClass)
                //.Include(y => y.MainPostingType).Include(y => y.Posting).Include(y => y.DeppostingType)
                //.Include(y => y.DepPosting).Include(x => x.PostResponsibility);
                (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) entityPostingRecordsObject = await _unitOfWork.List<PostingRecords>(PostingRecordsQueryOptions);
                returnPostingRecordsResponse = entityPostingRecordsObject;

                //(ExecutionState executionState, EmployeeInformation entity, string message) employeeReturnResponse;

                QueryOptions<EmployeeInformation> employeeReturnResponseFilterOptions = new QueryOptions<EmployeeInformation>();
                //filterOptions.FilterExpression = x => x.Id == id;
                //filterOptions.IncludeExpression = x => x.Include(x => x.Division).Include(x => x.District);
                (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(employeeReturnResponseFilterOptions);

                List<long> employeeIds = new List<long>();
                //foreach(var official in returnOfficialResponse.entity)
                //{
                //    employeeIds.Add(official.EmployeeInformationId);
                //}
                foreach (var posting in returnPostingRecordsResponse.entity)
                {
                    employeeIds.Add(posting.EmployeeInformationId);
                }
                foreach (var promotion in returnPromotionPartcularsResponse.entity)
                {
                    employeeIds.Add(promotion.EmployeeInformationId);
                }
                var distinctEmployeeIds = employeeIds.Distinct();

                var filterEmployeeList = entityObject.entity.Where(x => distinctEmployeeIds.Contains(x.Id));

                //var data = (from emp in filterEmployeeList
                //            join postingRecord in returnPostingRecordsResponse.entity on emp.Id equals postingRecord.EmployeeInformationId
                //            into pr from pRcord in pr.DefaultIfEmpty()
                //            join promotionParticular in returnPromotionPartcularsResponse.entity on emp.Id equals promotionParticular.EmployeeInformationId
                //            into pp from pParticular in pp.DefaultIfEmpty()
                //            join officialInformation in returnOfficialResponse.entity on emp.Id equals officialInformation.EmployeeInformationId
                //            into oi from officialInformation in oi.DefaultIfEmpty()
                //            select new {
                //                OfficialInformation  = officialInformation
                //            }
                //            );

                //(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;
                //var officialInformations = 
                //queryOptions = new QueryOptions<EmployeeInformation>();
                //queryOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
                //.Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
                //.Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
                //.Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
                //.Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
                //.Include(x => x.Division).Include(x => x.District).Include(x => x.PoliceStation)
                //.Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).Include(x => x.EmployeeStatus).
                //Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
                //.Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
                //.Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
                //.Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
                //.Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation).
                //Include(y => y.LanguageInformations).ThenInclude(x => x.Language);
                //(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entity2Object = await _unitOfWork.List<EmployeeInformation>(queryOptions);
                returnResponse = entityObject;

            }
            //queryOptions = new QueryOptions<EmployeeInformation>();
            //queryOptions.FilterExpression = x => x.Id == entity.Id;

            //queryOptions.IncludeExpression = x => x.Include(i => i.District).Include(x => x.Division).Include(x=>x.Division);

            //(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            //returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeFilterData(QueryOptions<EmployeeInformation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            queryOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
            .Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
            .Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
            .Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
            .Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
            .Include(x => x.Division).Include(x => x.District).Include(x => x.PoliceStation)
            .Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).Include(x => x.EmployeeStatus).
            Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation).
            Include(y => y.LanguageInformations).ThenInclude(x => x.Language);
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeList(QueryOptions<EmployeeInformation> queryOptions)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            //queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            //queryOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x => x.EmployeeInformation);

            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeByEmail(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            queryOptions.FilterExpression = x => x.Email == entity.Email;
            //queryOptions.IncludeExpression = x => x.Include(i => i.LeaveTypeInformation).Include(x => x.EmployeeInformation);

            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message)> GetEmployeeByEmailWithAllIncluding(QueryOptions<EmployeeInformation> queryOptions, EmployeeInformationFilterVM entity)
        {
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EmployeeInformation>();
            queryOptions.FilterExpression = x => x.Email == entity.Email;
            queryOptions.IncludeExpression = x => x.Include(i => i.SpouseInformation).ThenInclude(t => t.Division).Include(i => i.SpouseInformation).ThenInclude(x => x.District)
            .Include(y => y.PostingRecords).ThenInclude(i => i.Rank)
            .Include(y => y.PostingRecords).ThenInclude(j => j.Designation)
            .Include(y => y.PostingRecords).ThenInclude(y => y.CrntDesg)
            .Include(y => y.PostingRecords).ThenInclude(y => y.Posting)
            .Include(x => x.Division).Include(x => x.District).Include(x => x.PoliceStation)
            .Include(y => y.PromotionPartculars).ThenInclude(x => x.Rank).Include(x => x.EmployeeStatus)
            .Include(y => y.PromotionPartculars).ThenInclude(x => x.Designation)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Posting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.Depposting)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentRank)
            .Include(y => y.OfficialInformation).ThenInclude(x => x.PresentDesignation).
            Include(y => y.LanguageInformations).ThenInclude(x => x.Language);
            (ExecutionState executionState, IQueryable<EmployeeInformation> entity, string message) entityObject = await _unitOfWork.List<EmployeeInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        //public async Task<(ExecutionState executionState, string message)> UpdateExistingEmployeeData()
        //{

        //    using (var context = new DgFoodWriteOnlyCtx())
        //    {

        //        context.SaveChanges();
        //    }

        //    (ExecutionState executionState, string message) createResponse;

        //    await using (IDbContextTransaction transaction = UoW.Begin())
        //    {
        //        try
        //        {
        //            EmployeeInformation entity = new EmployeeInformation();
        //            entity.NameEnglish = entity.NameEnglish.Trim();
        //            entity.NameBangla = entity.NameBangla.Trim();
        //            entity.Email = entity.Email == null ? "" : entity.Email.Trim();
        //            entity.EmployeeCode = entity.EmployeeCode.Trim();

        //            (ExecutionState executionState,EmployeeInformation entity,  string message) createdResponse = await UoW.CreateAsync<EmployeeInformation>(entity);

        //            if (createdResponse.executionState == ExecutionState.Failure)
        //            {
        //                if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid validTransactionGuid))
        //                {
        //                    UoW.Complete(transaction, CompletionState.Failure);
        //                }

        //                createResponse.message = createdResponse.message;
        //                createResponse.executionState = createdResponse.executionState;
        //            }
        //            else
        //            {
        //                (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

        //                bool success = (saveResponse.executionState == ExecutionState.Success);

        //                #region Post validation
        //                if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
        //                {
        //                    UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

        //                    createResponse.message = success ? createdResponse.message :  saveResponse.message;
        //                    createResponse.executionState = success ? createdResponse.executionState :  saveResponse.executionState ;

        //                }
        //                else
        //                {
        //                    createResponse = (executionState: ExecutionState.Failure,  message: "Transaction not found.");
        //                }
        //                #endregion
        //            }
        //        }
        //        catch
        //        {
        //            if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
        //            {
        //                UoW.Complete(transaction, CompletionState.Failure);
        //            }

        //            createResponse = (executionState: ExecutionState.Failure,  message: $"Problem on {typeof(EmployeeInformation).ToString()} creation.");
        //        }
        //    }
        //    //}

        //    return createResponse;
        //}
    }

    public class PostingTypeCount
    {
        public long PostingId { get; set; }
        public int Count { get; set; }
    }
}
