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
    public class EducationalQualificationBusiness : BaseBusiness<EducationalQualification>, IEducationalQualificationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public EducationalQualificationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, EducationalQualification entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, EducationalQualification entity, string message) returnResponse;

            FilterOptions<EducationalQualification> filterOptions = new FilterOptions<EducationalQualification>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Degree);
            (ExecutionState executionState, EducationalQualification entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public async Task<(ExecutionState executionState, List<EducationalQualificationListVM> entity, string message)> GetFilterData(QueryOptions<EducationalQualification> queryOptions, EducationalQualificationFilterVM entity)
        {
            (ExecutionState executionState, List<EducationalQualificationListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<EducationalQualification>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            //(ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) entityObject = await _unitOfWork.List<EducationalQualification>(queryOptions);

            (ExecutionState executionState, IQueryable<EducationalQualification> entity, string message) entityObject = await _unitOfWork.List<EducationalQualification>();


            List<EducationalQualificationListVM> entityData = new List<EducationalQualificationListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity.Where(x=>x.EmployeeInformationId == entity.EmployeeInformationId))
                {
                    EducationalQualificationListVM tempdata = new EducationalQualificationListVM();
                    tempdata.Distinction = data.Distinction;
                    tempdata.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempdata.GpaOrCGPA = data.GPAOrCGPA;
                    tempdata.Id = data.Id;
                    tempdata.NameOfTheInstitute = data.NameOfTheInstitute;
                    tempdata.PrincipalSubject = data.PrincipalSubject;
                    entityData.Add(tempdata);
                }
            }

            returnResponse.entity = entityData;
            returnResponse.executionState = entityObject.executionState;
            returnResponse.message = entityObject.message;

            return returnResponse;
        }

    }
}
