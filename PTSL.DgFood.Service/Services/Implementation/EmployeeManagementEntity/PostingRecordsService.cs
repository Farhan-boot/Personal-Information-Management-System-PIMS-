using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Business;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Business.Businesses.Implementation;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;

namespace PTSL.DgFood.Service.Services
{
    public class PostingRecordsService : BaseService<PostingRecordsVM, PostingRecords>, IPostingRecordsService
    {
        public readonly IPostingRecordsBusiness _PostingRecordsBusiness;
        public IMapper _mapper;
        public PostingRecordsService(IPostingRecordsBusiness PostingRecordsBusiness, IMapper mapper) : base(PostingRecordsBusiness)
        {
            _PostingRecordsBusiness = PostingRecordsBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public virtual async Task<(ExecutionState executionState, List<PostingRecordsListVM> entity, string message)> GetFilterData(QueryOptions<PostingRecords> queryOptions, PostingRecordsFilterVM entity)
        {
            (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<PostingRecordsListVM> entity, string message) Getentity = await _PostingRecordsBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity:  Getentity.entity, message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public override PostingRecords CastModelToEntity(PostingRecordsVM model)
        {
            try
            {
                return _mapper.Map<PostingRecords>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PostingRecordsVM CastEntityToModel(PostingRecords entity)
        {
            try
            {
                PostingRecordsVM model = _mapper.Map<PostingRecordsVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PostingRecordsVM> CastEntityToModel(IQueryable<PostingRecords> entity)
        {
            try
            {
                //IQueryable<PostingRecordsVM> PostingRecordsList = _mapper.Map<IQueryable<PostingRecordsVM>>(entity).ToList();
                IList<PostingRecordsVM> PostingRecordsList = _mapper.Map<IList<PostingRecordsVM>>(entity).ToList();
                return PostingRecordsList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
