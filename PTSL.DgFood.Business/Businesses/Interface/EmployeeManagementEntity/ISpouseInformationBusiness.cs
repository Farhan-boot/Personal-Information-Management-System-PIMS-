using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.Businesses.Interface
{
    public interface ISpouseInformationBusiness : IBaseBusiness<SpouseInformation>
    {
        //public Task<(ExecutionState executionState, SpouseInformation entity, string message)> GetEmployeeInfoByEmployeIdAsync(long id);
        Task<(ExecutionState executionState, IList<SpouseInformationListVM> entity, string message)> GetFilterData(QueryOptions<SpouseInformation> queryOptions, SpouseInformationFilterVM entity);
    }
}
