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
    public class SpouseInformationBusiness : BaseBusiness<SpouseInformation>, ISpouseInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public SpouseInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<(ExecutionState executionState, IQueryable<SpouseInformation> entity, string message)> List(QueryOptions<SpouseInformation> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) returnResponse;

            queryOptions = new QueryOptions<SpouseInformation>();
            queryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x=> x.District);

            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) entityObject = await _unitOfWork.List<SpouseInformation>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, IList<SpouseInformationListVM> entity, string message)> GetFilterData(QueryOptions<SpouseInformation> queryOptions, SpouseInformationFilterVM entity)
        {
            (ExecutionState executionState, List<SpouseInformationListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<SpouseInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;
            queryOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x=>x.District);
            (ExecutionState executionState, IQueryable<SpouseInformation> entity, string message) entityObject = await _unitOfWork.List<SpouseInformation>(queryOptions);
            List<SpouseInformationListVM> spouseLists = new List<SpouseInformationListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    SpouseInformationListVM tempData = new SpouseInformationListVM();
                    tempData.Designation = data.Designation;
                    tempData.DistrictName = data.District.DistrictName;
                    tempData.DivisionName = data.Division.DivisionName;
                    tempData.EmployeeInformationId = data.EmployeeInformationId;
                    tempData.Id = data.Id;
                    tempData.Location = data.Location;
                    tempData.NameInBangla = data.NameInBangla;
                    tempData.NameInEnglish = data.NameInEnglish;
                    tempData.Occupation = data.Occupation;
                    spouseLists.Add(tempData);
                }
            }
            returnResponse.entity = spouseLists;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }        
        public override async Task<(ExecutionState executionState, SpouseInformation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, SpouseInformation entity, string message) returnResponse;

            FilterOptions<SpouseInformation> filterOptions = new FilterOptions<SpouseInformation>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Division).Include(x => x.District);
            (ExecutionState executionState, SpouseInformation entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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
    }
}
