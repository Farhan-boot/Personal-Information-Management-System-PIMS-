using PTSL.DgFood.Common.Entity;
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
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public interface ILanguageInformationService : IBaseService<LanguageInformationVM, LanguageInformation>
    {
        Task<(ExecutionState executionState, List<LanguageInfoListVM> entity, string message)> GetFilterData(QueryOptions<LanguageInformation> queryOptions, LanguageInformationFilterVM entity);
    } 
}
