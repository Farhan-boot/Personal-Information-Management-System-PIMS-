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
    public class EducationalQualificationService : BaseService<EducationalQualificationVM, EducationalQualification>, IEducationalQualificationService
    {
        public readonly IEducationalQualificationBusiness _EducationalQualificationBusiness;
        public IMapper _mapper;
        public EducationalQualificationService(IEducationalQualificationBusiness EducationalQualificationBusiness, IMapper mapper) : base(EducationalQualificationBusiness)
        {
            _EducationalQualificationBusiness = EducationalQualificationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<EducationalQualificationListVM> entity, string message)> GetFilterData(QueryOptions<EducationalQualification> queryOptions, EducationalQualificationFilterVM entity)
        {
            (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) Getentity = await _EducationalQualificationBusiness.GetFilterData(queryOptions, entity);

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
        public override EducationalQualification CastModelToEntity(EducationalQualificationVM model)
        {
            try
            {
                return _mapper.Map<EducationalQualification>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override EducationalQualificationVM CastEntityToModel(EducationalQualification entity)
        {
            try
            {
                EducationalQualificationVM model = _mapper.Map<EducationalQualificationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<EducationalQualificationVM> CastEntityToModel(IQueryable<EducationalQualification> entity)
        {
            try
            {
                //IQueryable<EducationalQualificationVM> EducationalQualificationList = _mapper.Map<IQueryable<EducationalQualificationVM>>(entity).ToList();
                IList<EducationalQualificationVM> EducationalQualificationList = _mapper.Map<IList<EducationalQualificationVM>>(entity).ToList();
                return EducationalQualificationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
