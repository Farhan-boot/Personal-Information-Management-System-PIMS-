using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class LanguageInformationService : BaseService<LanguageInformationVM, LanguageInformation>, ILanguageInformationService
    {
        public readonly ILanguageInformationBusiness _LanguageInformationBusiness;
        public IMapper _mapper;
        public LanguageInformationService(ILanguageInformationBusiness LanguageInformationBusiness, IMapper mapper) : base(LanguageInformationBusiness)
        {
            _LanguageInformationBusiness = LanguageInformationBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here
        public virtual async Task<(ExecutionState executionState, List<LanguageInfoListVM> entity, string message)> GetFilterData(QueryOptions<LanguageInformation> queryOptions, LanguageInformationFilterVM entity)
        {
            (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) Getentity = await _LanguageInformationBusiness.GetFilterData(queryOptions, entity);

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

        public override LanguageInformation CastModelToEntity(LanguageInformationVM model)
        {
            try
            {
                return _mapper.Map<LanguageInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override LanguageInformationVM CastEntityToModel(LanguageInformation entity)
        {
            try
            {
                LanguageInformationVM model = _mapper.Map<LanguageInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<LanguageInformationVM> CastEntityToModel(IQueryable<LanguageInformation> entity)
        {
            try
            {
                IList<LanguageInformationVM> colorList = _mapper.Map<IList<LanguageInformationVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
