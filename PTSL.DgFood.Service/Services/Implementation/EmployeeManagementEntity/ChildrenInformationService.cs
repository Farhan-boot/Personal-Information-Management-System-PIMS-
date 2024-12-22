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
    public class ChildrenInformationService : BaseService<ChildrenInformationVM, ChildrenInformation>, IChildrenInformationService
    {
        public readonly IChildrenInformationBusiness _ChildrenInformationBusiness;
        public IMapper _mapper;
        public ChildrenInformationService(IChildrenInformationBusiness ChildrenInformationBusiness, IMapper mapper) : base(ChildrenInformationBusiness)
        {
            _ChildrenInformationBusiness = ChildrenInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public virtual async Task<(ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message)> GetFilterData(QueryOptions<ChildrenInformation> queryOptions, ChildrenInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) Getentity = await _ChildrenInformationBusiness.GetFilterData(queryOptions, entity);

                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: Getentity.entity, message: Getentity.message);
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

        public override ChildrenInformation CastModelToEntity(ChildrenInformationVM model)
        {
            try
            {
                return _mapper.Map<ChildrenInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override ChildrenInformationVM CastEntityToModel(ChildrenInformation entity)
        {
            try
            {
                ChildrenInformationVM model = _mapper.Map<ChildrenInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<ChildrenInformationVM> CastEntityToModel(IQueryable<ChildrenInformation> entity)
        {
            try
            {
                //IQueryable<ChildrenInformationVM> ChildrenInformationList = _mapper.Map<IQueryable<ChildrenInformationVM>>(entity).ToList();
                IList<ChildrenInformationVM> ChildrenInformationList = _mapper.Map<IList<ChildrenInformationVM>>(entity).ToList();
                return ChildrenInformationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
