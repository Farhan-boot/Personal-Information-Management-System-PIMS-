using AutoMapper;
using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Implementation.EmployeeManagementEntity
{
    public class PRLService : BaseService<PRL_VM, PRL>, IPRLService
    {
        public readonly IPRLBusiness _prlBusiness;
        public IMapper _mapper;
        public PRLService(IPRLBusiness business, IMapper mapper) : base(business)
        {
            _prlBusiness = business;
            _mapper = mapper;
        }
        public override PRL CastModelToEntity(PRL_VM model)
        {
            try
            {
                return _mapper.Map<PRL>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PRL_VM CastEntityToModel(PRL entity)
        {
            try
            {
                PRL_VM model = _mapper.Map<PRL_VM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PRL_VM> CastEntityToModel(IQueryable<PRL> entity)
        {
            try
            {
                IList<PRL_VM> PRL_List = _mapper.Map<IList<PRL_VM>>(entity).ToList();
                return PRL_List;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IList<OfficialInformationVM> CastEntityToModelPRL(IQueryable<OfficialInformation> entity)
        {
            try
            {
                IList<OfficialInformationVM> PRL_List = _mapper.Map<IList<OfficialInformationVM>>(entity).ToList();
                return PRL_List;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override async Task<(ExecutionState executionState, PRL_VM entity, string message)> GetAsync(long key)
        {
            (ExecutionState executionState, PRL entity, string message) Getentity = await _prlBusiness.GetAsync(key);
            return (ExecutionState.Success, CastEntityToModel(Getentity.entity), "Sucessfully loaded employee information.");
        }

        public async Task<(ExecutionState executionState, IList<OfficialInformationVM> prlList, string message)> PRLList()
        {
            (ExecutionState executionState, IList<OfficialInformation> prlList, string message) getListResponse =  await _prlBusiness.List();
            if (getListResponse.executionState == ExecutionState.Success)
            {
                var list = _mapper.Map<List<OfficialInformationVM>>(getListResponse.prlList);
                return (executionState :ExecutionState.Retrieved, prlList: list, message: "PRL List get successfully.");
            }
            else
            {
                return (executionState: ExecutionState.Failure, prlList: null, message: "PRL List not found");
            }
        }

        public async Task<(ExecutionState executionState, IList<PRL_VM> entitys, string[] prlSendingWay, string message)> CreateAsync(IList<PRL_VM> model, string noticeType)
        {
            (ExecutionState executionState, IList<PRL_VM> entitys, string[] prlSendingWay, string message) returnResponse;
            try
            {
                var prlList = new List<PRL>();
                foreach(var prl in model)
                {
                    prlList.Add(CastModelToEntity(prl));
                }
                var returnResult = await _prlBusiness.CreateAsync(prlList, noticeType);

                if (returnResult.executionState == ExecutionState.Created)
                {
                    returnResponse = (executionState: ExecutionState.Success, entitys: CastEntityToModel(returnResult.entity.AsQueryable()), returnResult.empsendingWay, message: "Created successfully.");
                }
                else
                {
                    returnResponse = (executionState: ExecutionState.Failure, entitys: null, prlSendingWay :null, message: "Created not successfully.");
                }
            }
            catch (Exception)
            {
                returnResponse = (executionState: ExecutionState.Failure, entitys: null, prlSendingWay: null, message: $"Problem on {typeof(PRL).Name}.");
            }
            return returnResponse;
        }
    }
}