using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public interface IRoutesService : IBaseService<RoutesVM, Routes>
    {
        Task<(ExecutionState executionState, RoutesVM entity, string message)> RoutesByUserId(Routes model);
        Task<(ExecutionState executionState, IList<RoutesVM> entity, string message)> GetFilterData(QueryOptions<Routes> queryOptions, RoutesVM entity);

    }
}
