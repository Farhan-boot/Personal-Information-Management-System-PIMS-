using Microsoft.EntityFrameworkCore;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class PostingRecordsBusiness : BaseBusiness<PostingRecords>, IPostingRecordsBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public PostingRecordsBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, PostingRecords entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, PostingRecords entity, string message) returnResponse;

            FilterOptions<PostingRecords> filterOptions = new FilterOptions<PostingRecords>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Rank)
            .Include(z=>z.TransferFromDivision).Include(z=>z.TransferToDivision)
            .Include(z => z.TransferFromDistrict).Include(z => z.TransferToDistrict)
            .Include(y => y.DesignationClass).Include(j => j.Designation)
            .Include(y => y.CurrDesignationClass).Include(y => y.CrntDesg)
            .Include(y => y.MainPostingType).Include(y => y.Posting)
            .Include(y => y.DeppostingType).Include(y => y.DepPosting).Include(x => x.PostResponsibility);
             
            (ExecutionState executionState, PostingRecords entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, List<PostingRecordsListVM> entity, string message)> GetFilterData(QueryOptions<PostingRecords> queryOptions, PostingRecordsFilterVM entity)
        {
            (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<PostingRecords>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.Rank).Include(x => x.Designation).Include(x=>x.PostResponsibility).Include(x=>x.Posting);

            (ExecutionState executionState, IQueryable<PostingRecords> entity, string message) entityObject = await _unitOfWork.List<PostingRecords>(queryOptions);

            List<PostingRecordsListVM> entityList = new List<PostingRecordsListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    PostingRecordsListVM tempData = new PostingRecordsListVM();
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.EmployeeTransferId = data.EmployeeTransferId;
                    tempData.Rank = data.Rank != null ? data.Rank.RankName : "";
                    tempData.Designation = data.Designation != null ? data.Designation.DesignationName : "";
                    tempData.PostResponsibility = data.PostResponsibility != null ? data.PostResponsibility.PostResponsibilityName : "";
                    tempData.PostingPlace = data.Posting != null ? data.Posting.PostingName : "";
                    entityList.Add(tempData);
                }
            }

            returnResponse.entity = entityList;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }

    }
}
