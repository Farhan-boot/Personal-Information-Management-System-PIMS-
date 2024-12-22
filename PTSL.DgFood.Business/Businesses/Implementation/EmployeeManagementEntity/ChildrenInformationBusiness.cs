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
    public class ChildrenInformationBusiness : BaseBusiness<ChildrenInformation>, IChildrenInformationBusiness
    {
        public readonly DgFoodUnitOfWork _unitOfWork;
        public ChildrenInformationBusiness(DgFoodUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message)> GetFilterData(QueryOptions<ChildrenInformation> queryOptions, ChildrenInformationFilterVM entity)
        {
            (ExecutionState executionState, IList<ChildrenInformationListVM> entity, string message) returnResponse;

            queryOptions = new QueryOptions<ChildrenInformation>();
            queryOptions.FilterExpression = x => x.EmployeeInformationId == entity.EmployeeInformationId;

            (ExecutionState executionState, IQueryable<ChildrenInformation> entity, string message) entityObject = await _unitOfWork.List<ChildrenInformation>(queryOptions);
            List<ChildrenInformationListVM> childrenLists = new List<ChildrenInformationListVM>();
            if (entityObject.entity != null)
            {
                foreach (var data in entityObject.entity)
                {
                    ChildrenInformationListVM tempData = new ChildrenInformationListVM();
                    tempData.Id = data.Id;
                    tempData.EmpoloyeeInformationId = data.EmployeeInformationId;
                    tempData.NameInBangla = data.NameInBangla;
                    tempData.NameInEnglish = data.NameInEnglish;
                    tempData.DOB = data.DateOfBirth;
                    childrenLists.Add(tempData);
                }
            }
            returnResponse.entity = childrenLists;
            returnResponse.message = entityObject.message;
            returnResponse.executionState = entityObject.executionState;

            return returnResponse;
        }
    }
}
