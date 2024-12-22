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
    public class DisciplinaryActionsAndCriminalProsecutionService : BaseService<DisciplinaryActionsAndCriminalProsecutionVM, DisciplinaryActionsAndCriminalProsecution>, IDisciplinaryActionsAndCriminalProsecutionService
    {
        public readonly IDisciplinaryActionsAndCriminalProsecutionBusiness _DisciplinaryActionsAndCriminalProsecutionBusiness;
        public IMapper _mapper;
        public DisciplinaryActionsAndCriminalProsecutionService(IDisciplinaryActionsAndCriminalProsecutionBusiness DisciplinaryActionsAndCriminalProsecutionBusiness, IMapper mapper) : base(DisciplinaryActionsAndCriminalProsecutionBusiness)
        {
            _DisciplinaryActionsAndCriminalProsecutionBusiness = DisciplinaryActionsAndCriminalProsecutionBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, IList<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message)> GetFilterData(QueryOptions<DisciplinaryActionsAndCriminalProsecution> queryOptions, DisciplinaryActionsAndCriminalProsecutionFilterVM entity)
        {
            (ExecutionState executionState, IList<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IList<DisciplinaryActionsAndCriminalProsecutionListVM> entity, string message) Getentity = await _DisciplinaryActionsAndCriminalProsecutionBusiness.GetFilterData(queryOptions, entity);

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
        public override DisciplinaryActionsAndCriminalProsecution CastModelToEntity(DisciplinaryActionsAndCriminalProsecutionVM model)
        {
            try
            {
                return _mapper.Map<DisciplinaryActionsAndCriminalProsecution>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DisciplinaryActionsAndCriminalProsecutionVM CastEntityToModel(DisciplinaryActionsAndCriminalProsecution entity)
        {
            try
            {
                DisciplinaryActionsAndCriminalProsecutionVM model = _mapper.Map<DisciplinaryActionsAndCriminalProsecutionVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DisciplinaryActionsAndCriminalProsecutionVM> CastEntityToModel(IQueryable<DisciplinaryActionsAndCriminalProsecution> entity)
        {
            try
            {
                //IQueryable<DisciplinaryActionsAndCriminalProsecutionVM> DisciplinaryActionsAndCriminalProsecutionList = _mapper.Map<IQueryable<DisciplinaryActionsAndCriminalProsecutionVM>>(entity).ToList();
                IList<DisciplinaryActionsAndCriminalProsecutionVM> DisciplinaryActionsAndCriminalProsecutionList = _mapper.Map<IList<DisciplinaryActionsAndCriminalProsecutionVM>>(entity).ToList();
                return DisciplinaryActionsAndCriminalProsecutionList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<EmployeeInformationByDisciplinaryVM> entity, string message)> GetEmployeeByFilter(DisciplinaryActionsAndCriminalProsecutionGetEmployeeFilterVM model)
        {
            (ExecutionState executionState, IList<EmployeeInformationByDisciplinaryVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IList<EmployeeInformationByDisciplinaryVM> entity, string message) Getentity = await _DisciplinaryActionsAndCriminalProsecutionBusiness.GetEmployeeByFilter(model);

                if (Getentity.executionState == ExecutionState.Success)
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
    }
}
