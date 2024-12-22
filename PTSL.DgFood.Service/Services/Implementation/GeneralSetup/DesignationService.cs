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

namespace PTSL.DgFood.Service.Services
{
    public class DesignationService : BaseService<DesignationVM, Designation>, IDesignationService
    {
        public readonly IDesignationBusiness _DesignationBusiness;
        public IMapper _mapper;
        public DesignationService(IDesignationBusiness DesignationBusiness, IMapper mapper) : base(DesignationBusiness)
        {
            _DesignationBusiness = DesignationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Designation CastModelToEntity(DesignationVM model)
        {
            try
            {
                return _mapper.Map<Designation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DesignationVM CastEntityToModel(Designation entity)
        {
            try
            {
                DesignationVM model = _mapper.Map<DesignationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DesignationVM> CastEntityToModel(IQueryable<Designation> entity)
        {
            try
            {
                //IQueryable<DesignationVM> DesignationList = _mapper.Map<IQueryable<DesignationVM>>(entity).ToList();
                IList<DesignationVM> DesignationList = _mapper.Map<IList<DesignationVM>>(entity).ToList();
                return DesignationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<DesignationVM> entity, string message)> GetByRankAndDesignationClass(long? rankId, long? designationClassId)
        {
            (ExecutionState executionState, IList<DesignationVM> entity, string message) error = (ExecutionState.Failure, null, "Failed to retrieve data.");

            try
            {
                (ExecutionState executionState, IQueryable<Designation> entity, string message) result = await _DesignationBusiness.GetByRankAndDesignationClass(rankId, designationClassId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    return (result.executionState, CastEntityToModel(result.entity), result.message);
                }
                return (result.executionState, null, result.message);
            }
            catch (Exception ex)
            {
                return error;
            }
        }
    }
}
