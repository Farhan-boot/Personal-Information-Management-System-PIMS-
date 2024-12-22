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
    public class DivisionService : BaseService<DivisionVM, Division>, IDivisionService
    {
        public readonly IDivisionBusiness _DivisionBusiness;
        public IMapper _mapper;
        public DivisionService(IDivisionBusiness DivisionBusiness, IMapper mapper) : base(DivisionBusiness)
        {
            _DivisionBusiness = DivisionBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        //public override async Task<(ExecutionState executionState, DivisionVM entity, string message)> GetAsync(long id)
        //{
        //    (ExecutionState executionState, DivisionVM entity, string message) returnResponse;
        //    try
        //    {
        //        (ExecutionState executionState, Division entity, string message) Getentity = await _DivisionBusiness.GetAsync(id);

        //        if (Getentity.executionState == ExecutionState.Retrieved)
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: CastEntityToModel(Getentity.entity), message: Getentity.message);
        //        }
        //        else
        //        {
        //            returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
        //    }

        //    return returnResponse;
        //}

        public override Division CastModelToEntity(DivisionVM model)
        {
            try
            {
                return _mapper.Map<Division>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DivisionVM CastEntityToModel(Division entity)
        {
            try
            {
                DivisionVM model = _mapper.Map<DivisionVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
         

        public override IList<DivisionVM> CastEntityToModel(IQueryable<Division> entity)
        {
            try
            {
                //IQueryable<DivisionVM> DivisionList = _mapper.Map<IQueryable<DivisionVM>>(entity).ToList();
                IList<DivisionVM> DivisionList = _mapper.Map<IList<DivisionVM>>(entity).ToList();
                return DivisionList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
