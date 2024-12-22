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
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class LanguageInformationBusiness : BaseBusiness<LanguageInformation>, ILanguageInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public LanguageInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, LanguageInformation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, LanguageInformation entity, string message) returnResponse;

            FilterOptions<LanguageInformation> filterOptions = new FilterOptions<LanguageInformation>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Language);


            (ExecutionState executionState, LanguageInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, List<LanguageInfoListVM> entity, string message)> GetFilterData(QueryOptions<LanguageInformation> queryOptions, LanguageInformationFilterVM entity)
        {
            (ExecutionState executionState, List<LanguageInfoListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<LanguageInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.Language);
            (ExecutionState executionState, IQueryable<LanguageInformation> entity, string message) entityObject = await _unitOfWork.List<LanguageInformation>(queryOptions);
            List<LanguageInfoListVM> entityData = new List<LanguageInfoListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    LanguageInfoListVM tempData = new LanguageInfoListVM();
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.Language = data.Language != null ? data.Language.LanguageName : "";
                    tempData.Listening = data.Listening;
                    tempData.Reading = data.Reading;
                    tempData.Writing = data.Writing;
                    entityData.Add(tempData);
                }
            }
            returnResponse.entity = entityData;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }

        //public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        //{
        //    (ExecutionState executionState, string message) returnResponse;

        //    FilterOptions<DisciplinaryActionsAndCriminalProsecution> filterOptions = new FilterOptions<DisciplinaryActionsAndCriminalProsecution>();
        //    filterOptions.FilterExpression = x => x.LanguageInformationId == id;
        //    //filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.PoliceStations);
        //    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
        //    returnResponse = entityObject;
        //    return returnResponse;
        //}

    }
}
